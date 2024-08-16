# Team Management System

## Overview

This application is a basic team management system built using .NET 6 MVC technology. It allows for the creation of activities and tasks, assigning tasks to users, and updating the status of tasks. The application also includes a real-time component using SignalR to update the task list dynamically on the frontend when a new task is Created.

## Folder Structure

The application is organized using the Clean Architecture pattern. Here is the folder structure:
```bash
/src
    /Core
        /Entities
        /Enums
        /Interfaces
    /Application
        /DTOs
        /Services
        /Events
        /Mapping
    /Infrastructure
        /Data
    /WebUI
        /Controllers
        /Hubs
        /EventHandlers
        /Models
        /wwwroot
        /Views
```

## Core Functionalities

## Database Schema

The database schema is represented in the following Entity-Relationship Diagram (ERD):

![ERD Diagram](Database%20Schema.PNG)

### Backend

The backend consists of three controllers to handle entities and tasks:

#### 1. `ActivityController`

- **Purpose**: Manages activities.
- **Endpoints**:
  - `GET /api/activity/{id}`: Retrieve an activity by ID.
  - `GET /api/activity`: Retrieve all activities.
  - `POST /api/activity`: Add a new activity.


#### 2. `TaskController`

- **Purpose**: Manages tasks.
- **Endpoints**:
  - `POST /api/task`: Add a new task.
  - `GET /api/task/{id}`: Retrieve a task by ID.
  - `GET /api/task/status/{status}`: Retrieve tasks by status.
  - `PUT /api/task/{id}/status`: Update task status.


#### 3. `UserController`

- **Purpose**: Manages users.
- **Endpoints**:
  - `GET /api/user/{id}`: Retrieve a user by ID.
  - `GET /api/user`: Retrieve all users.
  - `POST /api/user`: Add a new user.

## Frontend

- **Pages**:
  - **Task Management Page**: Displays tasks assigned to the user and updates in real-time.

## Setup Instructions

1. **Create Solution and Projects**:
   - Use Visual Studio to create a new solution with the specified projects and folders.

2. **Configure In-Memory Database**:
   - The application uses an in-memory database to avoid connection string issues. No migrations are required.

3. **Configure SignalR**:
   - SignalR is used to push updates to the frontend when tasks are created.

4. **Add and Display Tasks**:
   - Tasks can be added through the API and displayed on the frontend page.

## Running the Application

1. **Start the Application**:
   - Run the application from Visual Studio or using `dotnet run` from the command line.

2. **Access the Application**:
   - Open a browser and navigate to `http://localhost:5288`.

## Testing SignalR Functionality

To test the SignalR functionality and see real-time updates, you can use Postman or `cURL` to add a new task. Use the following command:

### cURL Command

```bash
curl --location --request POST 'http://localhost:5288/api/task' \
--header 'Content-Type: application/json' \
--data-raw '{
    "id": 1,
    "title": "New Task",
    "description": "Description of the new task.",
    "status": 1,
    "userId": 1,
    "activityId": 1
}'
```

## Known Issues and Recommendations

While the application provides the core functionalities, it currently lacks comprehensive error handling and validation. Here are some key areas for improvement:

1. **Error Handling**:
   - The application does not have robust error handling implemented. It's essential to add try-catch blocks and proper error responses to handle unexpected issues gracefully.

2. **Fluent Validation**:
   - Fluent validation is not yet incorporated. Implementing Fluent Validation would provide more control and flexibility in validating input data and ensure that data integrity is maintained.

3. **Database Migration**:
   - The application currently uses an in-memory database for simplicity. It is recommended to switch to SQL Server or another persistent database for production use. This change will require implementing Entity Framework migrations.

4. **Validation for Task Assignment**:
   - Before assigning tasks to users, it is crucial to ensure that the user exists and is valid. Implement necessary validations to check the existence and state of users before proceeding with task assignments.

## Recommendations

- **Implement Error Handling**: Add comprehensive error handling to capture and manage exceptions effectively.
- **Integrate Fluent Validation**: Use Fluent Validation to enforce rules and constraints on DTOs and entities.
- **Switch to Persistent Database**: Transition from an in-memory database to SQL Server or another relational database for better data management and persistence.
- **Add Pre-Assignment Validation**: Ensure validations are in place for checking user existence and other constraints before assigning tasks.

