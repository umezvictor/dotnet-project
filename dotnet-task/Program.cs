using dotnet_task.Middleware;
using dotnet_task.Repository;
using dotnet_task.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));


var cosmosSettings = configuration.GetSection("CosmosDB");
var endpointUri = cosmosSettings["EndpointUri"];
var primaryKey = cosmosSettings["PrimaryKey"];
var databaseName = cosmosSettings["DatabaseName"];
var containerName = cosmosSettings["ContainerName"];


builder.Services.AddSingleton<IProgramRepository>((provider) =>
{
    var cosmosClient = new CosmosClient(endpointUri, primaryKey);
    return new ProgramRepository(cosmosClient, databaseName, containerName);
});


builder.Services.AddSingleton<IApplicationRepository>((provider) =>
{
    var cosmosClient = new CosmosClient(endpointUri, primaryKey);
    return new ApplicationRepository(cosmosClient, databaseName, containerName);
});

builder.Services.AddTransient<IApplicationService, ApplicationService>();
builder.Services.AddTransient<IProgramService, ProgramService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
