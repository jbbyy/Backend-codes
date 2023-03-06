
## ASP.Net FlightInfo Web API Case Study

## Requirements
You are required to create an ASP.Net Web API for flight information for a particular Airlines. The API should allow user to perform basic CRUD operations and some additional operations based on system requirements. Below mentioned is the list of operations.

1. User should be able to add, modify & delete flight details
2. User should be able to search flight details based on source and destinations
3. User should be able to search flight details based on flight information such as flight number.
4. User should be able to search flight details based on flight schedule date.
5. User should be able to see how many flights are operational based on specific date.

Below is the list of some expected endpoints which needs to be created in API.

- POST https://localhost:`port`/api/flights
- PUT https://localhost:`port`/api/flights/`flight_number`
- DELETE https://localhost:`port`/api/flights/`flight_number`
- GET https://localhost:`port`/api/flights?source=`source`&dest=`dest`  (use query string for taking parameters)
- GET https://localhost:`port`/api/flights/`flight_number`
- GET https://localhost:`port`/api/flights/bydate/`flight_date`
- GET https://localhost:`port`/api/flights/operational/`flight_date`

The model for the API should have below properties
1. FlightId/FlightNumber
2. FlightSource
3. FlightDestination
4. FlightDateTime

```
- Application data must be stored in SQL Server Database.
- Application should use Entity Framework as ORM.
- Application should use swagger as API documentation tool.
- Application should have seperate data access layer (Repository) which performs all database related operations.
- Application should have seperate service layer (Services) which performs other business operations such as handling exceptions.
- Application should have only one controller.
```
