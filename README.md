# AsyncInn
AsyncInn is a web application implamenting a database in order to manage hotel rooms in a hotel chain. With this application, the user should be able to create Hotels, Rooms, and Amenities, and connect those objects together appropriately.   

## Changes
Current Version: 0.1.0  
 > Application currently has the ability to render the index page for each table within the Async Inn's database. Basic css styling and html scaffolding has been implamented. The database has been created using the model first method, but is currently empty. The ability to add, edit, delete and view the table has been scaffolded, but has not been completely implamented.
 

## Database Schema
![AsyncInn Database Schema](Assets/SchemaAsyncInn.png)

### Relationships
#### Hotel
The Hotel has many Hotel Rooms within it. It has a one to many relationship with Hotel Rooms. 
#### Hotel Room
There are many Hotel Rooms in a hotel. Each HotelRoom has a RoomID, which when Combined with the HotelID foriegn key creates a composite key. A HotelRoom has a many to one relationship with Rooms.
#### Room
A room has a Layout(enum) and Room Amenities. Room has a one to many relationship with HotelRoom and a one to many relationship with Room Amenities. Each room may have many amenities.
#### Room Amenities
A Room Amenity has a many to one relationship with Amenities. A Room Amenity only holds one Amenitiy. But Room Amenities have a many to one relationship with Room. Many amenities go to a single room.
#### Amenities
One amenity goes to many Room Amenties. 

## Resources


## Instructions


