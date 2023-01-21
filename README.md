# Lsoc: A Social Media Concept

###### Please note that this project is currently a work-in-progress, and does not currently reflect the full functionality intended for the final version

## Project Purpose

This project was created as a way for me to learn how to use newer Vue 3-based technologies, as my prior experience in Vue is surrounding Vue 2, and I have not yet used Vue 3 beyond basic example code in an actual project, and I wanted to be able to learn by use.

This project aims to implement a basic social media message board-style forum that can be hosted on a server for both local wifi messaging, all the way up to being scalable to intranet application-level uses.

## Running

To execute the application, the backend and frontend need to both be running, then navigate to the frontend URL (http://localhost:8080/):

### Backend

There are two ways to run the backend (depending on intent for running it):

1. Open the Web API solution in either JetBrains Rider (what I used for development), or Visual Studio, then run the Lsoc.API project
2. Run the shell script provided in order to run the backend headless (ideal if only the frontend is your focus, or if you intend on hosting the app):

```bash
$ chmod +x ./lsoc.hostapi.sh
$ ./lsoc.hostapi.sh
```

### Frontend

To host the frontend, simply run the following command within the Lsoc.UI folder after starting the backend:

```bash
$ yarn run dev
```

## Technology Used

For the frontend of the project, the stack of Vue 3, Pinia, Vue Router, and Prime Flex was used. As described above, I was aiming to create this project in an ideal Vue 3 environment, and as a result mostly stuck to the typical stack of components to reduce frontend complexity.

On top of these, TypeScript was used for its static typing, which I believed would help out significantly in reducing type-related bugs, and overall giving a more stable and structured codebase.

On the backend side, a slightly less orthodox stack was used for a Vue project: .NET Core 7 with Entity Framework, AutoMapper, and a Sqlite 3 database.

Throughout previous projects, I have had extensive experience utilizing .NET for Web API design, so it seemed like the natural choice, as it is cross platform, and handles auto-generating REST API documentation without user intervention (reducing time needed to write documentation).

For the ORM, Entity Framework was used since it fits into the typical MVC development pattern, and abstracts away much of the SQL that would need to be created in order to facilitate normal CRUD interactions with the database (eliminating a range of potential errors).

AutoMapper was used to map the raw models used for entity framework to and from user-presentable view models; this is necessary due to it not making sense from both a security and a simplicity perspective, to have the frontend client need to understand the database structure, as this will be handled within the business logic layer of the backend.

A Sqlite 3 database was used for 2 main reasons:

1. Simplicity: The database can be set up as a single file (localDB) for development, or changed to be on a database server for production systems.
2. Compatibility: Entity Framework has a package, designed by Microsoft, in order to easily connect to and interact with a Sqlite 3 database. Combined with all of these technologies, this application was able to be created without unneeded complexity, and is maintainable and extensible for future maintainance and expansion.
