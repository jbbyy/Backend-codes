## Seed code - Boilerplate for step 1 - Keep Note Assignment

### Assignment Step Description

As a first step in building our Keep Note application, we will create a monolithic application. 

A monolithic application is built as a single unit. Enterprise Applications are built in three parts: 
1. A database (consisting of many tables usually in a relational database management system), 
2. A client-side user interface (consisting of HTML pages and/or JavaScript running in a browser), 
3. A server-side application. 

This server-side application will handle HTTP requests, execute some domain specific logic, retrieve and update data from the persistence storage, and populate the HTML views to be sent to the browser. 

### Problem Statement

In this case study: Keep Note Step 1, we will develop a monolithic application which will get the note Id,title,content and status from the user using a form (Razor), persist the data in List and display all notes with details such as note id,note title, note content,note status and LocalDateTime of posting in a reverse chronological order (a test note first).

**Note: For detailed clarity on the class files, kindly go thru the Project Structure**
### Expected solution
 A form containing four text fields for Note ID, Note Title, Note Content, Note Status and a submit button. Antoher view will be a tabular column with the fields Note ID, Note Title, Note Content and LocalDateTime(This will be published in reverse chronological order). 
 When the user enters the Note ID, Note Title, Note Content, Note Status and clicks on submit button, it gets stored in the List and later render in tabular column.
 
### Following are the broad tasks:
1. Display the list of notes from the list. Each note should contain Note ID, Title, Content, Status and created date. 
2. Add a new note which should contain the Note ID, Title, Content and Status.
3. Make sure to pass all the Unit test cases locally and on Hobbes.

### Steps to be followed :

    Step 1: Clone the boilerplate in a specific folder in your local machine.
    Step 2: In Note.cs file (which is considered as Model class), declare all the necessary properties for the model.
    Step 3: In NoteRepository.cs, create methods to add/retrieve/delete notes from the List. 
       Also Write a method which is used to retrieve all notes from List.
    Step 4: Run the test cases for NoteRepository(NoteRepositoryTest.cs)
    Step 5: In NoteController.cs, get NoteRepository objects using dependency Injection.
    	Define a handler method to read the existing notes from the List, to read the Note data from requested parameters and save the new note in the List and delete a note.
    Step 6: Run the testcases for NoteController (NoteControllerTest.cs)
    Step 7: Design a form with four text boxes (Note id, title, content and status) and a submit button and A table which shows Note id, title, content, status and the created date.

### Project structure

The folders and files you see in this repositories, is how it is expected to be in projects, which are submitted for automated evaluation by Hobbes

    Solution
	|
	├──Keepnote-Step1
	|	└─Controllers
	|	|	└── NoteController.cs 		        // This class is used to control all the transactions with the collection storage.
	|	└─Models
	|	|	└── Note.cs                    	// The class will be acting as the data model for the Note data in the collection storage. 
	|	└─Repository
	|	|	└── NoteRepository.cs          	// This class contains the code for data interactions and methods of this class will be used by  	|   |                                                    other parts of the applications such as Controllers and Test Cases               
	|   └── Views							//This folder contains all the views/ui required for the application.
	|
	├──Test
	|	└── NoteRepositoryTest.cs       	// All your test cases are written using XUnit.
	|	└── NoteControllerTest.cs  		   // This class contaions all the test cases related to Note Controller.
	|
	├── .hobbes   			               // Hobbes specific config options, such as type of evaluation schema, type of tech stack etc., Have saved a default values for convenience
	├── .sln			                            // This is automatically generated by Visual Studio.
	└── README.md  		                    	        // This files describes the problem of the assignment/project, you can provide as much as information and clarification you want about the project in this file


#### To use this as a boilerplate for your new project, you can follow these steps

1. Clone the base boilerplate in the folder **assignment-solution-step1** of your local machine
     
    `git clone https://gitlab-cts.stackroute.in/stack_dotnet_keep/KeepNote-Step1-Boilerplate.git`

2. Navigate to assignment-solution-step1 folder

    `cd assignment-solution-step1`

3. Remove its remote or original reference

     `git remote rm origin`

4. Create a new repo in gitlab named `assignment-solution-step1` as private repo

5. Add your new repository reference as remote

     `git remote add origin https://gitlab-cts.stackroute.in/{{yourusername}}/assignment-solution-step1.git`

     **Note: {{yourusername}} should be replaced by your username from gitlab**

5. Check the status of your repo 
     
     `git status`

6. Use the following command to update the index using the current content found in the working tree, to prepare the content staged for the next commit.

     `git add .`
 
7. Commit and Push the project to git

     `git commit -a -m "Initial commit | or place your comments according to your need"`

     `git push -u origin master`

8. Check on the git repo online, if the files have been pushed

### Important instructions for Participants
> - We expect you to write the assignment on your own by following through the guidelines, learning plan, and the practice exercises
> - The code must not be plagirized, the mentors will randomly pick the submissions and may ask you to explain the solution
> - The code must be properly indented, code structure maintained as per the boilerplate and properly commented
> - Follow through the problem statement shared with you

### MENTORS TO BEGIN REVIEW YOUR WORK ONLY AFTER ->
> - You add the respective Mentor as a Reporter/Master into your Assignment Repository
> - You have checked your Assignment on the Automated Evaluation Tool - Hobbes (Check for necessary steps in your Boilerplate - README.md file. ) and got the required score - Check with your mentor about the Score you must achieve before it is accepted for Manual Submission.
> - Intimate your Mentor on Slack and/or Send an Email to learner.support@stackroute.in - with your Git URL - Once you done working and is ready for final submission.