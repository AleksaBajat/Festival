# Development of Multi-Layer Applications - Festival

Project created for a class in the Faculty of Technical Sciences. 

## Table of Contents
* [General](#general)
* [Technologies](#technologies)
* [Run](#run)


## General

This is MVVM (Model View ViewModel) Client/Server application in WCF (Windows Communication Foundation) and WPF (Windows Presentation Foundation). It is mostly a project for faculty but since we had a few projects that led into the same stack and the same problems I decided to create an ultimate boilerplate that will essentially satisfy almost any scenario if it comes to using these technologies again. It uses Castle Windsor as a dependency injection library. It features very simple transitions from one view to another using an event. The views are decoupled from the actions they can call using a command pattern. Those calls are propagated to services and services communicate with the server application using WCF. Since the command pattern is implemented undo/redo is available and there are a few different types of commands that those brave enough to venture into the boilerplate will notice. Async commands are key to making the user interface non-blocking while communicating with the server. There can be multiple clients with one server, however, the goal of this application was for them to share the same data. Having that in mind if a conflict with some user were to happen the prompt would be opened and the user would be asked which action would they like to perform (Cancel, Override). The server uses Entity Framework code-first approach with SQL Server. Also, there is a very simple authentication layer between them.

## Technologies

* .NET Framework
* T-SQL (SQL Server)
* Entity Framework
* WCF (Windows Communication Foundation)
* WPF (Windows Presentation Foundation)

## Run

Open the solution using Visual Studio. Run both projects (Optionally you can set them to start at the same time).
