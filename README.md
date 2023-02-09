# Spells Reference

***This repository was archived on 2023-02-08***

This is a web application for displaying and organizing information about spells from the 5th edition of the tabletop roleplaying game *Dungeons & Dragons*. Currently it is written as an ASP.NET MVC 5 application with a React front end communicating with a SQL Server database via ASP.NET Web API 2. Work is underway to port the application to ASP.NET Core 3 and the database to AWS DynamoDB.

## Software Requirements Specification

This application is based on the following specification:
https://docs.google.com/document/d/1QQo-dhErNQ8DJSQbAtPT0Wth5EPCCTH-Rm08W0K1jUo/edit?usp=sharing

Since that document was written with a desktop application in mind, certain aspects of the specification must be modified to work for a web application.

| | Original | Modified |
| --- | --- | --- |
| Data Persistence | Spells and spellbook data are modeled as Java objects and saved in JSON files on the user's computer. | Spells and spellbook data are modeled in Entity Framework and stored in SQL Server. |
| Interface | The GUI features a single application window with tabbed pages made in JavaFX. | Using ASP.NET MVC, each action has a corresponding view. A shared layout view provides a menu bar that is common to all views. |
| Concurrency | Only one user can use the application at a time. | Multiple users are supported, so concurrency conflicts must be handled. 

## Team Responsibilities
The original version of this web application was created in collaboration with [Bill Lawlor](https://github.com/wjlawlor) as the final project for an 11 week coding boot camp taught by App Academy. 

### Cordelia Vera
- Initial concept and specification
- Authentication and authorization
- Web API design and implementation
- React Router set up and React components for spell pages

### Bill Lawlor
- Entity modeling and database set up
- Styling and overall UI design
- React components for spellbook pages and interactive tables
