# Student Portal Web Application

## Overview

This project is a comprehensive web application designed to manage student information, courses, and departments within a university setting. The application is built using .NET CORE with an N-Tier architecture, employing Entity Framework Core for database operations. It demonstrates proficiency in database design, functionality implementation, user interface design, and efficient navigation.

## Contributors

- [Navjot Kaur](https://github.com/navjot0210)
- [Evan Kennedy](https://github.com/evanckennedy)
- [Joseph Adoga](https://github.com/josephadoga)
- [Saad Alddine](https://github.com/MrAlameddine)

## Features

- **User Authentication**: Secure login and registration functionality with role-based access.
  - **Roles**: 
    - *Student*: Can only view their profile and list of enrolled courses.
    - *Admin*: Has full CRUD (Create, Read, Update, Delete) access to Students, Courses, and Departments.

- **Student Management**: Register, update, view, and delete student information.
- **Course Management**: Create, update, view, and delete course details.
- **Department Management**: Manage departments, including creating, updating, and deleting departments.
- **Enrollment Management**: View student course enrollments.
- **User Interface**: Intuitive and responsive UI designed using HTML and CSS.

## Database Design

The application uses a relational database with three main tables:
1. **Students**
2. **Courses**
3. **Departments**

## Installation

### Clone the repository:
```bash
git clone https://github.com/evanckennedy/student-portal.git
```

### Navigate to the project directory:
```bash
cd StudentPortal
```

### Restore the dependencies:
```bash
dotnet restore
```

### Set up the database:
```bash
dotnet ef database update
```

### Run the application:
```bash
dotnet run
```

## Admin Login Details

For testing purposes, you can use the following credentials to log in to the application as an admin:

- **Email**: `admin@admin.com`
- **Password**: `Test1234`

## Usage

- Navigate to the main page and use the navigation bar to access different features such as managing students, courses, and departments.
- Register as a student or log in as either a student or an admin.
  - **Students**: View profile and enrolled courses.
  - **Admins**: Manage students, courses, and departments with full CRUD functionality.
- View detailed information on students, courses, and departments, including enrollment details.