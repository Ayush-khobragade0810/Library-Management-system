# Library Management System

This is a **Library Management System** desktop application built using **C#**, **.NET**, and **MySQL**. The system allows users to log in, manage library book records, and perform basic library functions such as adding, updating, and searching for books.

## Features

### 1. **Login Form**
- **User Authentication**: The login form allows registered users to log in by entering their email and password.
- **Data Storage**: User credentials (email, username, and password) are stored securely in a MySQL database.

### 2. **Library Form**
- **Book Management**: The library form allows administrators to add, update, and view books. Book data includes title, author, genre, and other relevant information.
- **Database Integration**: Book details are stored in a MySQL database for effective management.

### 3. **Search Functionality**
- **Book Search**: Users can search for books by title, author, or genre.

### 4. **Transaction Tracking**
- **Issued Books**: Track issued books and their return status.

## Tech Stack

- **Frontend**: C# (Windows Forms)
- **Backend**: .NET Framework
- **Database**: MySQL
- **Database Connectivity**: ADO.NET for MySQL

## Database Setup

1. Create a MySQL database (e.g., `library_db`).
2. Create the following tables in your database:
   - **users**: For storing user credentials (username, email, password).
   - **books**: For storing book details (title, author, genre, etc.).

```sql
CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    password VARCHAR(100)
);

CREATE TABLE books (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255),
    author VARCHAR(255),
    genre VARCHAR(100),
    publish_date DATE,
    isbn VARCHAR(20) UNIQUE
);
Update the connection string in the application to match your MySQL server configuration.

Installation

1.Install Required Software
MySQL Server: Ensure MySQL is installed and running on your system.
Visual Studio: Download and install Visual Studio with the .NET desktop development workload.
MySQL Connector for .NET: Install the MySQL Connector to enable communication between the application and the MySQL database.

2. Build the Project
Open the project in Visual Studio.
Build the project to ensure all dependencies are resolved.
Run the application by pressing F5 or selecting Start in Visual Studio.

3. Database Configuration
Ensure your MySQL server is running and the connection string in the App.config file is correct.
Create the necessary database and tables as described above.

4.Usage
Login Form: Users can log in by entering their email and password. If the credentials are valid, users are granted access to the main system.
Library Form: Administrators can manage books in the library by adding, updating, or viewing books.
Search Books: Use the search functionality to find books by title, author, or genre.
Project Structure

├── App.config              # Application configuration (database connection settings)
├── MainForm.cs              # Main UI form (for user interaction)
├── LoginForm.cs             # Login form for user authentication
├── LibraryForm.cs           # Form for managing library book data
├── Program.cs               # Entry point of the application
├── Models/                  # C# classes for interacting with data
│   ├── Book.cs
│   ├── User.cs
├── Properties/              # Application properties (e.g., settings, resources)
├── DataAccess/              # Code for connecting to and interacting with the database
     ├── DatabaseHelper.cs
     └── MySQLConnection.cs

Troubleshooting
Database Connection Errors: Verify that MySQL is running and check the connection string for accuracy.
Missing Dependencies: Ensure that all required libraries, such as MySql.Data, are referenced in your project.
UI Issues: Run the application in debug mode to identify any exceptions or issues in the UI.
