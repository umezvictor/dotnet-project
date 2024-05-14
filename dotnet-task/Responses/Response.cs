namespace dotnet_task.Responses
{
   
    public class Response<T>
    {
        public Response()
        {
        }


        public Response(T data)
        {
            Succeeded = true;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = true;
            Message = message;
        }


        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
        public T? Data { get; set; }
    }
}
