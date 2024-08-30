# SchoolSystem

![SchoolSystem](https://img.shields.io/badge/SchoolSystem-1.0.0-blue.svg)
![Docker](https://img.shields.io/badge/Docker-Ready-blue.svg)
![MongoDB](https://img.shields.io/badge/Database-MongoDB-green.svg)
![PostgreSQL](https://img.shields.io/badge/Database-PostgreSQL-green.svg)

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Project](#running-the-project)

## Introduction

**SchoolSystem** is a backend project designed to manage various aspects of a school's operations, such as student enrollment and grading. It is built using .NET 8, MongoDB, and PostgreSQL, and provides a flexible and scalable system for managing school data. The project also includes a frontend developed with Node.js to interact with the backend APIs.

## Features

- Student registration and management
- Enrollment in subjects with automatic grade tracking
- Integration with PostgreSQL for relational data
- Integration with MongoDB for non-relational data
- Dockerized environment for easy deployment and scalability

## Technologies

- **Backend:** .NET 8
- **Frontend:** React.js with Typescript
- **Databases:** PostgreSQL, MongoDB
- **Containerization:** Docker
- **Version Control:** GitHub

## Setup

### Prerequisites

- **Docker:** Make sure Docker is installed on your machine.
- **.NET SDK:** .NET 8 SDK should be installed if you plan to run the backend outside Docker.
- **Node.js:** Required for running the frontend outside Docker.

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/vagnerwentz/SchoolSystem.git
    cd SchoolSystem
    ```

2. **Clone the repository for the frontend:**

    Before building and running the project, you need to clone the frontend repository:

    ```bash
    git clone https://github.com/vagnerwentz/SchoolSystemWeb.git
    ```

   This command will build and start the API, frontend, MongoDB, and PostgreSQL services.

3. **Update the Dockerfile path for the frontend:**

    In the `docker-compose.yml` file, you will find the following section:

    ```yaml
    school-system-frontend:
      build:
        context: /Users/vagnerwentz/Documents/Projects/school-system
        dockerfile: Dockerfile
      ports:
        - "3000:3000"
      networks:
        - app-network
      depends_on:
        - schoolsystem-api
    ```

    You need to replace the `context:` path with the directory where your frontend project is located. 

    - **macOS and Linux:** You can find the correct path by running the command `pwd` in the terminal while in the frontend project directory.
    - **Windows:** Navigate to the frontend project directory in the file explorer, click on the address bar, and copy the full path.

4. **Build and run the services using Docker Compose:**

    ```bash
    docker-compose up --build
    ```

   This command will build and start the API, frontend, MongoDB, and PostgreSQL services.

### Running the Project

- The backend API will be available at `http://localhost:8080`.
- The frontend will be available at `http://localhost:3000`.
- MongoDB will be accessible at `mongodb://localhost:27017`.
- PostgreSQL will be accessible at `localhost:5432` with the default credentials provided in the `docker-compose.yml`.
