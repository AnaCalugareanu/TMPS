# Employee Management System

## Table of Contents
1. [Introduction](#introduction)
2. [Project Structure](#project-structure)
3. [Design Patterns Used](#design-patterns-used)
4. [Functionality](#functionality)
5. [Installation](#installation)
6. [Usage](#usage)
7. [License](#license)

## Introduction
The **Employee Management System** is a console-based application designed to manage employee records for a company's HR department. It enables the creation, tracking, and management of employees in different departments, offering core HR functionalities such as employee information storage, department management, and employee reviews. This application leverages several object-oriented design patterns to enhance flexibility, modularity, and maintainability.

## Project Structure
The project is organized into the following structure:

- **Models**: Contains the core classes defining employee types, the factory for creating employees, and the HR manager implementing the Singleton pattern.
- **Program.cs**: Entry point for the console application, containing the main loop and user interface.

## Design Patterns Used
This project implements three creational design patterns:

1. **Factory Method Pattern**: Used in `EmployeeFactory` to create instances of different employee types (Full-Time and Contractor).
2. **Prototype Pattern**: Each employee has a `Clone()` method, allowing duplication for quick onboarding of similar employees.
3. **Singleton Pattern**: `HRManager` uses the Singleton pattern to maintain a single instance of the HR manager, centralizing control of employee data.

## Functionality
The system provides the following functionalities:

- **Add Department**: Creates a new department.
- **Add Employee**: Allows the HR manager to add a full-time employee or a contractor and set the appropriate salary or hourly rate.
- **Clone Employee**: Duplicates an existing employee's details, creating a new record with a unique ID.
- **Show All Employees**: Displays a list of all employees, showing details like name, ID, type (Full-Time or Contractor), and department.
- **Add Review**: Adds a performance review for an employee.
- **Display Department Counts**: Shows the number of employees in each department.
- **Display Annual Salary**: Calculates and displays the annual salary for full-time employees.
- **Search Employees**: Searches for employees based on criteria like name, department, or employee type.

## Installation
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/EmployeeManagementSystem.git

2. **Navigate to Project Directory**:
   ```bash
   cd EmployeeManagementSystem

3. **Compile and Run: Ensure you have .NET SDK installed, then use:**:
   ```bash
   dotnet run


## Usage
Once the application is running, follow the prompts in the console to interact with the system. The main menu provides a list of actions, including adding employees, cloning, displaying employee details, and managing reviews.

Example usage:

1. **Add a Full-Time Employee**:
   - Choose the "Add Employee" option.
   - Select "FullTime".
   - Enter the employee's details, including monthly salary.

   ```plaintext
   Enter employee type (FullTime/Contractor): FullTime
   Enter employee name: John Doe
   Enter department: Engineering
   Enter monthly salary: 5000
   Employee added with ID: 123e4567-e89b-12d3-a456-426614174000


## License
This project is licensed under the MIT License.
