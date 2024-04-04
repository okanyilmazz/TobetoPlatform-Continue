<p align="center" dir="auto">
<a href="https://github.com/okanyilmazz/TobetoPlatform-Continue/graphs/contributors"><img src="https://camo.githubusercontent.com/01001d20d4cf399c23a92bbf1afc9c96a767f064e2602c59d864bca4f1529a2e/68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f636f6e7472696275746f72732f61686d65742d636574696e6b6179612f72656e74616361722d70726f6a6563742d6261636b656e642d646f746e65742e7376673f7374796c653d666f722d7468652d6261646765" data-canonical-src="https://img.shields.io/github/contributors/okanyilmazz/TobetoPlatform-Continue.svg?style=for-the-badge" style="max-width: 100%;"></a>
 <a href="https://github.com/okanyilmazz/TobetoPlatform-Continue/network/members"><img src="https://camo.githubusercontent.com/a1402fce04f7cc43af20ca0d11a7c741cc528856c91686e8db4086d79b072ddd/68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f666f726b732f61686d65742d636574696e6b6179612f72656e74616361722d70726f6a6563742d6261636b656e642d646f746e65742e7376673f7374796c653d666f722d7468652d6261646765" data-canonical-src="https://img.shields.io/github/forks/okanyilmazz/TobetoPlatform-Continue.svg?style=for-the-badge" style="max-width: 100%;"></a>
<a href="https://github.com/okanyilmazz/TobetoPlatform-Continue/stargazers"><img src="https://img.shields.io/github/stars/okanyilmazz/TobetoPlatform-Continue?style=for-the-badge" data-canonical-src="https://img.shields.io/github/stars/okanyilmazz/TobetoPlatform-Continue?style=for-the-badge" style="max-width: 100%;"></a>
<a href="https://github.com/okanyilmazz/TobetoPlatform-Continue/issues"><img src="https://camo.githubusercontent.com/087ab3915b0027119576a0764cdf3de1ef1d010e847bb02f230180bba44c1ccb/68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f6973737565732f61686d65742d636574696e6b6179612f72656e74616361722d70726f6a6563742d6261636b656e642d646f746e65742e7376673f7374796c653d666f722d7468652d6261646765" data-canonical-src="https://img.shields.io/github/issues/okanyilmazz/TobetoPlatform-Continue.svg?style=for-the-badge" style="max-width: 100%;"></a>
</p>
<p align="center" dir="auto">
  <img src="https://www.scnsoft.com/education-industry/elearning-portal/elearning-portals-cover-picture.svg" width="300px" height="300px" />
</p>

#### <p align="center">This repository contains the latest version of the [Tobeto Platform Backend](https://github.com/okanyilmazz/TobetoPlatform) project.</p>
<p> 
  <p align="center" dir="auto">
    <br>
    <br>
    <a href="https://github.com/okanyilmazz/TobetoPlatform-Continue/issues">Report Bug</a>
    ·
    <a href="https://github.com/okanyilmazz/TobetoPlatform-Continue/issues">Request Feature</a>
  </p>
</p>

# Tobeto Platform

  Tobeto Platform is an educational platform designed to provide users with access to a wide range of courses, class assignments, exams, and live lessons. Whether you're a student looking to enhance your skills or an educator seeking to facilitate learning, Tobeto Platform offers a versatile and user-friendly environment. It is a .NET Core-based application developed using the N-Tier architecture. Tobeto Platform provides services through RESTful APIs and ensures security using JWT Security Token. Entity Framework Core is utilized for database operations, and a caching mechanism is integrated to enhance performance.

## Features

- **Course Catalog:** Browse through our extensive catalog of courses covering various subjects and topics.
- **Class Assignments:** Enroll in classes and get assigned to specific courses to streamline your learning journey.
- **Examinations:** Take exams to assess your understanding and progress in the courses you're enrolled in.
- **Live Lessons:** Join live lessons conducted by instructors to engage in interactive learning experiences.
- **User Management:** Manage user profiles, track progress, and monitor performance through intuitive user management tools.

## Getting Started

To get started with Tobeto Platform, follow these steps:

1. **Sign Up:** Create an account on Tobeto Platform to access all features.
2. **Browse Courses:** Explore the course catalog to find topics of interest.
3. **Enroll in Classes:** Enroll in classes to gain access to course materials and assignments.
4. **Participate in Learning:** Complete assignments, take exams, and attend live lessons to enhance your knowledge and skills.

## Contributing

We welcome contributions from the community to improve Tobeto Platform. If you have suggestions, bug reports, or would like to contribute code, please follow these guidelines:

- Fork the repository and create your branch from `main`.
- Make your contributions.
- Submit a pull request, detailing the changes you've made and their significance.

## Technologies Used
- **.NET Core:** The main framework used for the application infrastructure.
- **N-Tier Architecture:** Employed to create a modular structure within the project.
- **RESTful API:** Utilized for creating and communicating with web services.
- **JWT Security Token:** Used for authentication and authorization purposes.
- **Entity Framework:** Serves as the ORM (Object-Relational Mapping) tool for database operations.
- **Caching:** Implemented to improve performance and reduce repeated data access.
- **Validation (FluentValidation):** Used for validating input data.
- **Logging:** Integration of FileLogger and MSSQL Logger for managing application logs.
- **Clean Code:** Followed coding standards for readable, maintainable, and understandable code.
- **Design Patterns:** Employed common software design patterns.
- **AutoMapper:** Used for object-to-object mapping operations.
- **LINQ:** Utilized for simplifying data querying and operations.
- **Middleware:** Used for processing HTTP requests and responses.
- **Global Exception Handling:** Implemented for centralized exception handling.
- **MSSQL:** Employed Microsoft SQL Server as the database management system.
- **Authorization:** Used for user authentication and access control.
- **SMTP:** Used for password reset operations. When users request a password reset, an email is sent securely via SMTP, allowing users to reset their passwords

## Dependencies

Below are the main dependencies used in Tobeto Platform along with their versions:

![Static Badge](https://img.shields.io/badge/v7.0.14-EntityFrameworkSqlServer?style=for-the-badge&label=EntityFrameworkSqlServer&color=F0B354)

![Static Badge](https://img.shields.io/badge/v7.0.14-JwtBearer?style=for-the-badge&label=Authentication.JwtBearer&color=F0B354)

![Static Badge](https://img.shields.io/badge/v7.0.14-EntityFrameworkCore?style=for-the-badge&label=EntityFrameworkCore&color=F0B354)

![Static Badge](https://img.shields.io/badge/v12.0.1-DependencyInjection?style=for-the-badge&label=DependencyInjection&color=F0B354)

![Static Badge](https://img.shields.io/badge/v11.9.0-FluentValidation?style=for-the-badge&label=FluentValidation&color=F0B354)

![Static Badge](https://img.shields.io/badge/v13.0.3-Newtonsoft?style=for-the-badge&label=Newtonsoft.Json&color=F0B354)

![Static Badge](https://img.shields.io/badge/v12.0.1-AutoMapper?style=for-the-badge&label=AutoMapper&color=F0B354)

![Static Badge](https://img.shields.io/badge/v11.0.3-AspNetCore?style=for-the-badge&label=AspNetCore&color=F0B354)

![Static Badge](https://img.shields.io/badge/v3.1.1-Serilog?style=for-the-badge&label=Serilog&color=F0B354)
