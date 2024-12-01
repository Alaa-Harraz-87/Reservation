# ReservationSystem
#please follow the steps to run and test the project 
#step1: clone the repo in the visual studio 
#step2: change the connection string from app settings or set it in user secrets 
    # connection string sample : "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;"
#step3: run the project directly from Visual Studio or use the command (it needs .Net6 framework ) 
#step4: download the Postman collection from the attached email 
#step5: confirm that the application runs on the same URL & port. maybe you need to change the postman baseUrl variable if you changed the application launch Url 
#step6: now you can use the endpoints to add new reservations => please follow the postman sample payload maybe there are some changes from the original assignment 
        # Once the application is started in the development environment. DB will be created by EF core code first migration 
#step7: SQL view will be created by migration to get analytics for each user reservations 
#step8: you can run the unit test project to validate the main business cases 


#Application Architecture 
# mainly the application contains four projects
# Reservation.Core
      # domain entities 
      # domain services
# Reservation.Infrastructure 
     # repository to access the database 
     # migration files 
# Reservation.API 
    # web APIs 

    
     
