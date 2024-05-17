# Teste Stefanini

Name: Douglas Wender Antunes Isidoro

## Introduction

This is a back-end API project in .Net Core 6.0, where it is possible to perform CRUD operations on Products and Orders, with their relationship being managed by a third entity called Items, which exists but is not accessible for CRUD operations.

Techs: .NET 6.0, C#, Entity Framwork, in memory database, DDD.

## How to run

To run this application you must have Docker in your machine.

1) Open StefaniniTest folder

2) Open PowerShell in this folder

3) Run "docker build -t api ."

4) Run "docker run --rm -it -p 5000:80 api"

## Useful informations

1) The documentation of the endpoints can be checked in http://localhost:5000/swagger/index.html


