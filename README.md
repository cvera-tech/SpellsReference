# Spells Reference

## Software Requirements Specification

This application will be based on the following specification:
https://docs.google.com/document/d/1QQo-dhErNQ8DJSQbAtPT0Wth5EPCCTH-Rm08W0K1jUo/edit?usp=sharing

Since that document was written with a desktop application in mind, certain aspects of the specification must be modified.

### Data Persistence
The original specification relies on saving spells and spellbook data into JSON files on the user's computer. For this project, we will use SQL Server and Entity Framework.

### User Interface
The original specification provides an example GUI mockup that features tabbed pages. For this project, we will build the tabs as separate actions in ASP.NET MVC that have their own Views. In the future, we can transfer to a React interface backed by Web API controllers.

### Scope
The original specification's data persistence scheme allows for easy duplication and copying of spells between spellbooks. For this project, the minimum viable program will contain only the basic CRUD operations.
- Spellbook
    - Create
    - List
    - Get
    - Delete
- Spell
    - Create
    - List
    - Get
    - Delete
    - AddToSpellbook

## Team Responsibilities

### John Vera
- Initial concept and design
- Authentication and authorization

### Bill Lawlor
- Entity modeling and database design