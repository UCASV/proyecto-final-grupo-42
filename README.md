# Official documentation

## Software used and its versions:

Microsoft.EntityFrameworkCore.SqlServer  version 5.0.7 .

Microsoft.EntityFrameworkCore            version 5.0.7 .

Microsoft.EntityFrameworkCore.Design     version 5.0.7 .

Microsoft.EntityFrameworkCore.Tools      version 5.0.7 .

Visual Studio Community 2019             version 16.9.31205.134 .

## Operating system: Wimdows 10

## patterns used: Microservices Architecture and Event Sourcing

Microservices Architecture: Implemented in login and data logs, Because the application is easy to understand and modify,
enables rapid and frequent development and deployment, allows a team to deploy its service without having to coordinate with other Equipments.

Event Sourcing: to start performing the associated actions, Because it delegates the information to the module in charge of processing this data.

## Installation
in the folder "Programación orientada a objetos", then double-clic on the folder "Instalador" there will be a file called setup double-click on and accept the permissions so that it can be installed. 

## framework version used: 5.0

## it is necessary to have an existing BDD 

## BDD manager used : Microsoft SQL Server Management Studio 18

# User Manual:

## software overview:
The following software has been developed for managing employees, so that they can have a control of the high priority citizens who will be in the vaccination process, as well as appointment data and relevant information during the vaccination process.
# Forms
![Login](https://user-images.githubusercontent.com/62577396/123874710-cfcf7980-d8f5-11eb-8414-cceeaf1a050c.png)
To be able to access the application the login is shown, in which the managing employee will have to type the username and password and the cabin from which he accesses.

![Home1](https://user-images.githubusercontent.com/62577396/123874777-e70e6700-d8f5-11eb-8ccb-96fbd49fa2ad.png)
Shows the series of steps to follow for the vaccination process

![Home2](https://user-images.githubusercontent.com/62577396/123874787-ebd31b00-d8f5-11eb-9c5d-4b5ef5388ccf.png)
A form is shown to be filled out to register and be able to get an appointment

![Home3](https://user-images.githubusercontent.com/62577396/123874801-f097cf00-d8f5-11eb-9cde-469ff7f5e6d0.png)
Displays the form to save an appointment in the database with put the DUI

![Home4](https://user-images.githubusercontent.com/62577396/123874830-f988a080-d8f5-11eb-9399-2533442133d2.png)
Displays information about the employee, who manage the cabin

![Home5](https://user-images.githubusercontent.com/62577396/123874840-fc839100-d8f5-11eb-8e12-849e44ff63da.png)
Displays information about the cabin and the name of the manager

![pre-check](https://user-images.githubusercontent.com/62577396/123875415-dc080680-d8f6-11eb-9653-40d76b59d4ca.png) 
Displays information about the appointment and gives you the option to add it to the wait row

![Observation](https://user-images.githubusercontent.com/62577396/123874925-14f3ab80-d8f6-11eb-9177-487de1d22656.png)
Displays information about the vaccination proces and you can add the symptoms the person has and the time it takes to present them

# possible errors

![LoginError](https://user-images.githubusercontent.com/62577396/123875591-3a34e980-d8f7-11eb-915d-e1a100c4a84e.png)
Wrong data in Login, respect capitalization and miniscular when typing data and fill all data

![Dui](https://user-images.githubusercontent.com/62577396/123875663-4d47b980-d8f7-11eb-8ae9-8202ff8af22d.png)
in the "prechequeo", if you put an invalid DUI show you an error, try to don't write letters or hyphens and put the correct DUI.

![citizen](https://user-images.githubusercontent.com/62577396/123875751-75371d00-d8f7-11eb-90e3-624607ec8f6a.png)
if you write an invalid data or don't fill all the necessary data, show that error, so introduce valid data and fill all.(the dui does not have to carry hyphens)

![Appointment](https://user-images.githubusercontent.com/62577396/123875629-44ef7e80-d8f7-11eb-9376-4e964d3e1faf.png)
in make an appointment, if you put an invalid DUI show you an error, try to don't write letters or hyphens and put the correct DUI.

![symptom](https://user-images.githubusercontent.com/62577396/123875829-9b5cbd00-d8f7-11eb-882a-578eb1ec6778.png)
 add symptom without write nothing, if you want to add a symptom fill the necessary fields
