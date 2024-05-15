"# dotnet-project" 

Installation
clone the repository

Database Configuration
Add this section to your appsettings.json file and enter your Cosmos DB credentials

"CosmosDB": { "EndpointUri": "", "PrimaryKey": "", "DatabaseName": "", "ContainerName": "" }

#Note: question type must be exactly any of the following. Please note it is case sensitive. 
Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number

#Sample payload for creating a program

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

#Sample payload for applying for a program as a candidate

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

#Sample payload for editing a question

 {
  "programId": "011f9f43-91a9-42f4-84c2-dd413062a2ec",
  "questionId": "d335fcfc-8465-4de0-a29a-6097d3970b48",
  "title": "Do you have a bachelors degree?",
  "type": "YesNo",
  }

#Author - Chibuzor Umezuruike
