Automated Voting System
This repository contains the source code and documentation for an Automated Voting System, an election management system that facilitates the registration of contenders and voters, and allows administrators to manage the entire election process. The system ensures secure access, authentication, data encryption, and traceability of votes.

Project Scope
The Automated Voting System includes the following modules:

Contender Registration: Individuals or political parties can register contenders for the elections.
Political Parties Registration: Political parties must register themselves before registering contenders.
Voter Registration: Eligible voters can register themselves to participate in the elections.
Admin Module: Administrators manage contenders, political parties, and voters. They verify user eligibility, create election categories, manage user roles, and oversee the voting process.
Voting Module: Registered voters can access this module to cast their votes.
Queries Module: Provides various queries for users with different levels of access to monitor the election process.
Authentication and Authorization: Strong authentication mechanisms, including multi-factor and biometric authentication, ensure only legitimate voters can participate.
Data Encryption: Sensitive data, such as voter information and voting results, is encrypted during storage and transmission to prevent unauthorized access.
Access Control: Well-defined access controls ensure only authorized users can manage the election process. The admin module has different roles and permissions, and access to sensitive functions is limited.
Verification: Validates user registration for voting or contender eligibility at the time of registration.
Security: Implements strong authentication, authorization mechanisms, data encryption, and access controls to prevent unauthorized access.
Traceability: Each vote is traced using a unique identifier to ensure vote authenticity and integrity.
Audit: Logs all system actions to identify discrepancies or errors and provide evidence in case of election result challenges.
Features
The Automated Voting System includes the following features:

Contender registration: Allows individuals or political parties to register contenders for the elections.
Political Parties Registration: Enables political parties to register themselves before registering contenders.
Voter registration: Provides a registration process for eligible voters.
Admin module: Allows administrators to manage contenders, political parties, and voters. They can create election categories, manage user roles, and oversee the voting process.
Voting Module: Enables registered voters to cast their votes securely.
Queries Module: Offers various queries for users with different levels of access to monitor the election process.
Authentication and Authorization: Ensures secure access to the system and data, using strong authentication mechanisms such as multi-factor and biometric authentication.
Data Encryption: Encrypts sensitive data during storage and transmission to prevent unauthorized access or modification.
Access Control: Implements well-defined access controls to restrict system management to authorized users. The admin module has different roles and permissions.
Verification: Validates user registrations to ensure eligibility for voting or contender positions.
Security: Implements security measures, including strong authentication, authorization mechanisms, data encryption, and access controls.
Traceability: Ensures the authenticity and integrity of votes through a unique identifier for each user.
Audit: Logs all system actions for identifying discrepancies, errors, and providing evidence if needed.
End Users
The Automated Voting System caters to three types of users:

Contenders (Individuals or political parties)
Voters
Administrators
Each user type has a defined user role that determines their level of access to the system.

User Stories
The following user stories illustrate the integration of end-users with the project:

As a Contender, I want to register myself for the elections.
As a Contender, I want to register multiple contenders for several positions.
As a Contender, I want to view the statistics of the contest.
As a voter, I want to register myself to vote in the elections.
As a voter, I want to vote from any place or any device.
As a voter, I want to know the progress of the elections.
As a voter, I want my vote to remain secret.
As an administrator, I want to manage contenders' and users' registrations.
As an administrator, I want to verify the identity of voters and contenders.
As an administrator, I want the system to be secure.
As an administrator, I want access to all statistics.
As an administrator, I want to create reports.
As an administrator, I want the system to handle a large number of users effectively.
Project Areas Covered
This project covers the following areas:

Contender registration: Handles the enrollment of contenders for the elections.
Voter registration: Manages the registration of voters for participation in the elections.
Admin module: Allows administrators to manage contender and voter registrations, the voting module, and queries. The admin module also manages the election's timing and creates pools (categories) for the elections.
Voting Module: Enables registered voters to cast their votes.
Query Module: Provides various queries based on the user's access level.
Project Users, Actors, Vendors, Actuators
i. Users:

Contenders (Individuals, political parties)
Voters
ii. Actors:

Administrators
iii. Vendors:

Microsoft Azure: Cloud computing platform that hosts the application and database of the Automated Voting System, providing services such as virtual machines, storage, and networking.
Power BI: Business analytics service used to create reports and visualizations of election data for administrators.
iv. Actuators:

Automated Voting System: The central software application that facilitates contender and voter registration, manages information, and conducts the voting process.
Project Properties
The Automated Voting System is developed using the following technologies and tools:

Programming Language: C#
Database: Microsoft SQL Server 16.x
Front-end Technologies: HTML, CSS, JavaScript
Framework: .NET Framework 4.8, Bootstrap 5.3.0
Web Framework: ASP.NET
Unit Testing: NUnit
Deployment Environment: Microsoft Azure
The use of C# and Microsoft SQL Server 16.x, along with the .NET Framework 4.8, ensures a robust and secure platform for development. The repository is hosted on GitHub for easy collaboration and version control.
