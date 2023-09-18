
# Freelance Assessment

This project is a list of freelancers. Such that they could have a directory of contact get people for their job.


## Features

- GET list of registered user name
- register a new user, delete an user, update an user details


## Tech Stack

**Database:** MSSQL

**Backend:** .Net, Web API 2, Entity Framework

**Frontend:** Bootstrap, Knockout.js


## Appendix

- The code start with the models where the attributes is defined.
- And then create Web API 2 controller to set the routes and manipulate on how the models data going to be use which in this case it will be use as restful api.
- Then create database through migration. The database can be access either through VS studio Server Explorer or MSSQL.
- Then create the javascript client to bind the data to the frontend.
- In the javascript we use the restful api to register/delete/update/get.
- Then we create UI and bind with the javascript client function.


## Demo

[link](https://freelanceassessment20230919041559.azurewebsites.net)

