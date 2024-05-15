<h1 align="center" id="title">dotnet task</h1>

<p id="description">CRUD APIs for programs</p>

<h2>🛠️ Installation Steps:</h2>

<p>1. clone the repository to get started</p>

```
https://github.com/umezvictor/dotnet-project.git
```

<p>2. Database configuration (add this to your appsettings.json and enter your cosmos db credentials)</p>

```
"CosmosDB": {
  "EndpointUri": "",
  "PrimaryKey": "",
  "DatabaseName": "",
  "ContainerName": ""
}

```

<p>3. Question types (case sensitive)</p>

```
Paragraph YesNo Dropdown MultipleChoice Date Number
```

<p>4. Sample payload for creating program</p>

```
{
  "title": "Winter Scholarship Program",
  "description": "A scholarship for college graduates",
  "personalInformation": {
    "Paragraph": [
      {
        
        "title": "tell us about yourself?"
      }
    ],
    "YesNo": [
      {
        
        "title": "Have you graduated from college?"
      }
    ],
    "Date": [
      {       
        "title": "Date of birth"
      }
    ]
  },
  "additionalQuestions": {
    "Paragraph": [
      {
        
        "title": "Why are you interested in this program?"
      },
      {
        
        "title": "Tell us other things you feel we should know"
      },
      {       
        "title": "Nationality"
      }
    ]   
  }
}

```

<p>5. Sample payload for applying for a program</p>

```
{
  "programTitle": "Winter Scholarship Program",
  "description": "A scholarship for college graduates",
  "personalInformation": {
    "Paragraph": [
      {
        "question": "tell us about yourself?",
        "response": "My name is Chibuzor Umezuruike"
      }     
    ],
    "YesNo": [
      {
        "question": "Have you graduated from college?",
        "response": "yes"
      }
    ],
    "Date": [
      {
        "question": "Date of birth",
        "response": "12/07/1989"
      }
    ]
  },
  "additionalQuestions": {
    "Paragraph": [
      {
        "question": "Why are you interested in this program?",
        "response": "I love this program"
      },
      {
        "question": "Tell us other things you feel we should know",
        "response": "I am a great guy"
      },
      {
        "question": "Nationality",
        "response": "Nigeria"
      }
    ]   
  }
}


```

<p>6. Sample payload for editing a question</p>

```
{
  "programId": "011f9f43-91a9-42f4-84c2-dd413062a2ec",
  "questionId": "d335fcfc-8465-4de0-a29a-6097d3970b48",
  "title": "Do you have a bachelors degree?",
  "type": "YesNo",
  }
```

  
  
<h2>💻 Built with</h2>

Technologies used in the project:

*   .Net 8.0
*   Cosmos DB SDK

<h2>Built with 💖 by Chibuzor Umezuruike</h2>
