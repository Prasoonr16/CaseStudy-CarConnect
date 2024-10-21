CREATE DATABASE CarConnect;

USE CarConnect;

CREATE TABLE Customers(
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) ,
    LastName VARCHAR(50) ,
    Email VARCHAR(50) ,
    PhoneNumber VARCHAR(10),
    [Address] VARCHAR(255),
    Username VARCHAR(25) UNIQUE NOT NULL,
    Password VARBINARY(64) NOT NULL,
    RegistrationDate DATETIME,
	CONSTRAINT CK_Email CHECK (Email LIKE '%@%.%'),
);

CREATE TABLE Vehicles(
VehicleID INT PRIMARY KEY IDENTITY(1,1),
Model VARCHAR(25),
Make VARCHAR(30),
[Year] INT,
Color VARCHAR(20),
RegistrationNumber NVARCHAR(15) UNIQUE NOT NULL,
[Availability] BIT  ,         -- (0 : Not Available  , 1: Available) 
DailyRate DECIMAL(10,2)
);


CREATE TABLE Reservations(
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT ,
    VehicleID INT ,
    StartDate DATETIME ,
    EndDate DATETIME ,
    TotalCost DECIMAL(10, 2) ,
    Status VARCHAR(20) ,
    CONSTRAINT FK_Reservation_Customer FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE,
    CONSTRAINT FK_Reservation_Vehicle FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID) ON DELETE CASCADE
);

CREATE TABLE Admin (
    AdminID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100) ,
    PhoneNumber VARCHAR(10),
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARBINARY(64) NOT NULL,
    Role VARCHAR(30) NOT NULL,
    JoinDate DATETIME ,
	CONSTRAINT CK_Email_Adm CHECK (Email LIKE '%@%.%'),
);


INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, [Address], UserName, Password, RegistrationDate)
VALUES 
('Aarav', 'Sharma', 'aarav.sharma@email.com', '9876543210', '123 MG Road, Mumbai, Maharashtra', 'aarav.sharma',CONVERT(VARBINARY(64), 'aarav@123'), '2024-01-01 10:30:00'),
('Isha', 'Gupta', 'isha.gupta@email.com', '9876543211', '45 Lajpat Nagar, Delhi', 'isha.gupta',CONVERT(VARBINARY(64),'isha@g'), '2024-01-15 11:45:00'),
('Aditya', 'Patel', 'aditya.patel@email.com', '9876543212', '22 Nehru Street, Ahmedabad, Gujarat', 'aditya.patel', CONVERT(VARBINARY(64),'adi22'), '2024-02-20 09:15:00'),
('Sneha', 'Rao', 'sneha.rao@email.com', '9876543213', '78 Residency Road, Bangalore, Karnataka', 'sneha.rao', CONVERT(VARBINARY(64),'sneha@rao'), '2024-03-05 14:50:00'),
('Rohan', 'Verma', 'rohan.verma@email.com', '9876543214', '90 Churchill Road, Pune, Maharashtra', 'rohan.verma',CONVERT(VARBINARY(64),'verma@45'), '2024-04-10 08:20:00'),
('Priya', 'Singh', 'priya.singh@email.com', '9876543215', '33 Sector-16, Chandigarh', 'priya.singh', CONVERT(VARBINARY(64),'p@singh'), '2024-05-01 13:35:00'),
('Rahul', 'Mishra', 'rahul.mishra@email.com', '9876543216', '12 Vijay Nagar, Jaipur, Rajasthan', 'rahul.mishra',CONVERT(VARBINARY(64),'rahul18'),'2024-06-12 16:40:00'),
('Meera', 'Kumar', 'meera.kumar@email.com', '9876543217', '56 Park Avenue, Chennai, Tamil Nadu', 'meera.kumar',CONVERT(VARBINARY(64),'meera@123'), '2024-07-23 19:00:00'),
('Siddharth', 'Joshi', 'siddharth.joshi@email.com', '9876543218', '10 Gariahat Road, Kolkata, West Bengal', 'sid.joshi', CONVERT(VARBINARY(64),'joshi@123'), '2024-08-19 12:10:00'),
('Ananya', 'Desai', 'ananya.desai@email.com', '9876543219', '4 Marine Drive, Mumbai, Maharashtra', 'ananya.desai', CONVERT(VARBINARY(64),'ananyaD'), '2024-09-30 15:25:00');


INSERT INTO Vehicles (Model, Make, Year, Color, RegistrationNumber, Availability, DailyRate)
VALUES
('Dzire', 'Maruti Suzuki', 2020, 'White', 'MH12AB1234', 1, 1200.00),
('Xcent', 'Hyundai', 2019, 'Silver', 'DL8CDE4321', 1, 1100.00),
('Amaze', 'Honda', 2021, 'Black', 'KA03FG5678', 1, 1300.00),
('Etios', 'Toyota', 2018, 'White', 'TN01JK9876', 0, 1250.00),
('Indica', 'Tata', 2017, 'Yellow', 'WB02LM6543', 1, 900.00),
('Ertiga', 'Maruti Suzuki', 2022, 'Blue', 'MH14XYZ1234', 1, 1500.00),
('Zest', 'Tata', 2020, 'Red', 'DL1AB5678', 1, 1150.00),
('Aspire', 'Ford', 2019, 'Grey', 'UP32PQ4321', 0, 1350.00),
('Innova', 'Toyota', 2021, 'White', 'KA05GH0987', 1, 1800.00),
('Vento', 'Volkswagen', 2020, 'Silver', 'MH20MN1234', 1, 1400.00);

INSERT INTO Reservations (CustomerId, VehicleId, StartDate, EndDate, TotalCost, Status)
VALUES
(1, 2, '2023-09-01 10:00:00', '2023-09-05 12:00:00', 500.00, 'Completed'),
(2, 4, '2023-10-01 09:00:00', '2023-10-03 18:00:00', 300.00, 'Cancelled'),
(3, 3, '2023-08-15 14:00:00', '2023-08-18 12:00:00', 450.00, 'Completed'),
(4, 1, '2023-09-10 11:00:00', '2023-09-14 10:00:00', 600.00, 'In Progress'),
(5, 5, '2023-11-01 08:00:00', '2023-11-07 20:00:00', 800.00, 'Pending'),
(1, 3, '2023-09-20 09:00:00', '2023-09-25 13:00:00', 750.00, 'Confirmed'),
(2, 1, '2023-07-01 15:00:00', '2023-07-05 11:00:00', 550.00, 'Completed'),
(3, 4, '2023-12-01 07:00:00', '2023-12-05 19:00:00', 400.00, 'Pending'),
(4, 2, '2023-10-15 10:00:00', '2023-10-20 17:00:00', 350.00, 'Confirmed'),
(5, 5, '2023-08-10 09:30:00', '2023-08-13 16:30:00', 475.00, 'Completed'),
(5, 6, '2023-09-22 09:00:00', '2023-09-27 15:00:00', 800.00, 'Completed'),
(6, 7, '2023-10-05 10:30:00', '2023-10-08 12:00:00', 450.00, 'Cancelled'),
(7, 8, '2023-11-10 08:00:00', '2023-11-15 18:00:00', 650.00, 'In Progress'),
(8, 9, '2023-12-01 07:30:00', '2023-12-05 17:00:00', 750.00, 'Pending'),
(9, 10, '2023-11-18 09:00:00', '2023-11-22 16:00:00', 550.00, 'Confirmed');


INSERT INTO Admin (FirstName, LastName, Email, PhoneNumber, UserName, Password, Role, JoinDate)
VALUES
('Ravi', 'Sharma', 'ravi.sharma@gmail.com', '9876543210', 'rsharma', CONVERT(varbinary(64), 'Pass@1234'), 'SuperAdmin', '2021-04-01'),
('Priya', 'Singh', 'priya.singh@gmail.com', '8765432109', 'psingh', CONVERT(varbinary(64), 'Priya!123'), 'Admin', '2020-06-12'),
('Amit', 'Kumar', 'amit.kumar@gmail.com', '7654321098', 'akumar', CONVERT(varbinary(64), 'Amit$1234'), 'FleetManager', '2019-02-20'),
('Sneha', 'Patel', 'sneha.patel@gmail.com', '6543210987', 'spatel', CONVERT(varbinary(64), 'Sneha@Secure1'), 'Admin', '2022-08-05'),
('Rahul', 'Reddy', 'rahul.reddy@gmail.com', '5432109876', 'rreddy', CONVERT(varbinary(64), 'Reddy#Best2'), 'SuperAdmin', '2018-11-15'),
('Anjali', 'Mehta', 'anjali.mehta@gmail.com', '4321098765', 'amehta', CONVERT(varbinary(64), 'Anjali$2020'), 'Admin', '2020-01-22'),
('Manish', 'Verma', 'manish.verma@gmail.com', '3210987654', 'mverma', CONVERT(varbinary(64), 'Manish@99'), 'FleetManager', '2021-09-30'),
('Neha', 'Chopra', 'neha.chopra@gmail.com', '2109876543', 'nchopra', CONVERT(varbinary(64), 'Neha@Top'), 'Admin', '2019-07-10'),
('Vikram', 'Rao', 'vikram.rao@gmail.com', '1098765432', 'vrao', CONVERT(varbinary(64), 'Vikram#01'), 'SuperAdmin', '2021-03-18'),
('Deepak', 'Joshi', 'deepak.joshi@gmail.com', '9988776655', 'djoshi', CONVERT(varbinary(64), 'Deepak@India1'), 'Admin', '2020-12-25');


select * from Customers;
select * from Vehicles;
select * from Reservations;
select * from [Admin];