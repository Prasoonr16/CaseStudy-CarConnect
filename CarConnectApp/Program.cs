using HelperLibrary;
using Entity;
using ExceptionLibrary;
using System.Data;

class Program
{
    public static void Main(string[] args)
    {
        AuthenticationServiceHelper authService = new AuthenticationServiceHelper();
        AdminServiceHelper adminService = new AdminServiceHelper();
        CustomerServiceHelper customerService = new CustomerServiceHelper();
        Admin admin = new Admin();
        Customer customer = new Customer();

        bool exit = false;

        while(!exit)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\tWelcome to CarConnect!");
            Console.WriteLine("\t1. Admin Login");
            Console.WriteLine("\t2. Customer Login");
            Console.WriteLine("\t3. Register as Admin");
            Console.WriteLine("\t4. Register as Customer");
            Console.WriteLine("\t5. Exit");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            bool status = false;

            switch (choice)
            {
                case 1:
                    AdminLogin(authService);
                    break;
                case 2:
                    CustomerLogin(authService);
                    break;
                case 3:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter First name : ");
                    admin.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Last name : ");
                    admin.LastName = Console.ReadLine();
                    Console.WriteLine("Enter email : ");
                    admin.Email = Console.ReadLine();
                    Console.WriteLine("Enter Phone number : ");
                    admin.PhoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter Username : ");
                    admin.Username = Console.ReadLine();
                    Console.WriteLine("Enter Password : ");
                    admin.Password = Console.ReadLine();
                    Console.WriteLine("Enter Role : ");
                    admin.Role = Console.ReadLine();
                    admin.JoinDate = DateTime.Now;
                    try
                    {
                        status = adminService.registerAdmin(admin);
                        if (status)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Admin registration successfull.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Admin registration failed.");
                            Console.ReadLine();
                        }
                    }
                    catch (Exception)
                    {
                        throw new InvalidInputException("Invalid input. Try again");
                    }

                    break;
                case 4:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter First name : ");
                    customer.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Last name : ");
                    customer.LastName = Console.ReadLine();
                    Console.WriteLine("Enter Email : ");
                    customer.Email = Console.ReadLine();
                    Console.WriteLine("Enter Phone number : ");
                    customer.PhoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter Address : ");
                    customer.Address = Console.ReadLine();
                    Console.WriteLine("Enter Username : ");
                    customer.Username = Console.ReadLine();
                    Console.WriteLine("Enter Password : ");
                    customer.Password = Console.ReadLine();
                    customer.RegistrationDate = DateTime.Now;

                    try
                    {
                        status = customerService.registerCustomer(customer);

                        if (status)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Customer registration successfull.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Customer registration failed.");
                            Console.ReadLine() ;
                        }
                    }
                    catch (Exception)
                    {
                        throw new InvalidInputException("Invalid input. Try again");
                    }

                    break;
                case 5:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("\tThank you for using CarConnect!");
                    //Environment.Exit(0);
                    exit = true;
                    break;
                default:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
            //Console.WriteLine("Do You want to continue (Y/N) : ");
            //ch = Convert.ToChar(Console.ReadLine());
        } 
        //Console.ReadLine();
    }
    static void AdminLogin(AuthenticationServiceHelper authService)
    {
        try
        {
            Console.WriteLine("------------------------------------");
            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

            if (authService.authenticateAdmin(username, password))
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Welcome Admin");
                AdminMenu();
            }
        }
        catch (AuthenticationException ex)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Authentication failed: {ex.Message}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"An unexpected error occurred : {ex.Message}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }

    static void CustomerLogin(AuthenticationServiceHelper authService)
    {
        try
        {
            Console.WriteLine("------------------------------------");
            Console.Write("Enter Customer Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Customer Password: ");
            string password = Console.ReadLine();

            if (authService.authenticateCustomer(username, password))
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Welcome Customer");
                CustomerMenu();
            }
        }
        catch (AuthenticationException ex)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Authentication failed: {ex.Message}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"An unexpected error occurred : {ex.Message}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }

    static void AdminMenu()
    {
        AdminServiceHelper adminService = new AdminServiceHelper();
        VehicleServiceHelper vehicleService = new VehicleServiceHelper();
        CustomerServiceHelper customerService = new CustomerServiceHelper();
        ReportGeneratorHelper reportGenerator = new ReportGeneratorHelper();
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer(); 

        bool backToMainMenu = false;
        bool status = false;
        int id;
        DataTable report;

        while (!backToMainMenu)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\tAdmin Menu:");
            Console.WriteLine("\t1. Add Vehicle");
            Console.WriteLine("\t2. Update Vehicle");
            Console.WriteLine("\t3. Remove Vehicle");
            Console.WriteLine("\t4. View  All Vehicles");
            Console.WriteLine("\t5. View Vehicle by ID");
            Console.WriteLine("\t6. View All Customers");
            Console.WriteLine("\t7. View Customer by ID");
            Console.WriteLine("\t8. Remove Customer");
            Console.WriteLine("\t9. Generate Reservation History Report");
            Console.WriteLine("\t10. Generate Vehicle Utilization Report");
            Console.WriteLine("\t11. Generate Revenue Report");
            Console.WriteLine("\t12. Log out");
            Console.WriteLine("------------------------------------");
            Console.Write("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter Model : ");
                    vehicle.Model = Console.ReadLine();
                    Console.WriteLine("Enter Make : ");
                    vehicle.Make = Console.ReadLine();
                    Console.WriteLine("Enter Year : ");
                    vehicle.Year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Color : ");
                    vehicle.Color = Console.ReadLine();
                    Console.WriteLine("Enter Registration Number : ");
                    vehicle.RegistrationNumber = Console.ReadLine();
                    Console.WriteLine("Availability(True - Available, False - Unavailable) : ");
                    vehicle.Availability = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("Enter Daily rate : ");
                    vehicle.DailyRate = Convert.ToDecimal(Console.ReadLine());

                    try
                    {
                        status = vehicleService.addVehicle(vehicle);

                        if (status)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Vehicle added successfully.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Vehicle addition failed.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : "+ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter Vehicle ID to Update : ");
                    vehicle.VehicleId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Model : ");
                    vehicle.Model = Console.ReadLine();
                    Console.WriteLine("Enter Make : ");
                    vehicle.Make = Console.ReadLine();
                    Console.WriteLine("Enter Year : ");
                    vehicle.Year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Color : ");
                    vehicle.Color = Console.ReadLine();
                    Console.WriteLine("Enter Registration Number : ");
                    vehicle.RegistrationNumber = Console.ReadLine();
                    Console.WriteLine("Availability(1 - Available, 0 - Unavailable) : ");
                    int availabilityInput = Convert.ToInt32(Console.ReadLine());
                    vehicle.Availability = (availabilityInput == 1);
                    Console.WriteLine("Enter Daily rate : ");
                    vehicle.DailyRate = Convert.ToDecimal(Console.ReadLine());

                    try
                    {
                        status = vehicleService.updateVehicle(vehicle.VehicleId, vehicle);

                        if (status)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Vehicle updated successfully.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Vehicle updation failed.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                    }
                    catch (VehicleNotFoundException ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Updation failed : "+ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : " + ex.Message);
                        Console.ReadLine();
                    }

                    break;
                case 3:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter Vehicle ID to remove : ");
                    id = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        status = vehicleService.removeVehicle(id);

                        if (status)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Vehicle removed successfully.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Vehicle deletion failed.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                    }
                    catch (VehicleNotFoundException ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Deletion failed : " + ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : " + ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }

                    break;
                 
                case 4:
                    try
                    {
                        List<Vehicle> vehicleList = new List<Vehicle>();
                        vehicleList = vehicleService.GetAllVehicles();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("VehicleID\tModel\tMake\tColor\tRegistrationNumber\tAvailability\tDailyRate");
                        foreach (Vehicle v in vehicleList)
                        {
                            Console.WriteLine($"{v.VehicleId}\t{v.Model}\t{v.Make}\t{v.Color}\t{v.RegistrationNumber}\t{v.Availability}\t{v.DailyRate}");
                        }
                        Console.ReadKey();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Press enter to continue...");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : " + ex.Message);
                    }
                    break;

                case 5:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter Vehicle Id to view vehicle : ");
                    id = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        vehicle = vehicleService.getVehicleById(id);
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"Vehicle ID : {vehicle.VehicleId}");
                        Console.WriteLine($"Model : {vehicle.Model}");
                        Console.WriteLine($"Make : {vehicle.Make}");
                        Console.WriteLine($"Year : {vehicle.Year}");
                        Console.WriteLine($"Color : {vehicle.Color}");
                        Console.WriteLine($"Registration Number : {vehicle.RegistrationNumber}");
                        Console.WriteLine($"Availability : {vehicle.Availability}");
                        Console.WriteLine($"Daily Rate : {vehicle.DailyRate}");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadKey();

                    }
                    catch (VehicleNotFoundException ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Vehicle not found : " + ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : "+ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    break;

                case 6:
                    try
                    {
                        List<Customer> customerList = new List<Customer>();
                        customerList = customerService.getAllCustomers();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("CustomerID\tFirstName\tLastName\tEmail\tPhoneNumber\tAddress\tRegistrationDate");
                        foreach (Customer c in customerList)
                        {
                            Console.WriteLine($"{c.CustomerId}\t{c.FirstName}\t{c.LastName}\t{c.Email}\t{c.PhoneNumber}\t{c.Address}\t{c.RegistrationDate}");
                        }
                        Console.ReadKey();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Press enter to continue...");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : " + ex.Message);
                    }
                    break;
                case 7:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter Customer ID to view customer : ");
                    id = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        customer = customerService.getCustomerByID(id);
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"Customer ID : {customer.CustomerId}");
                        Console.WriteLine($"First name : {customer.FirstName}");
                        Console.WriteLine($"Last name : {customer.LastName}");
                        Console.WriteLine($"Email : {customer.Email}");
                        Console.WriteLine($"Phone number : {customer.PhoneNumber}");
                        Console.WriteLine($"Username : {customer.Username}");
                        Console.WriteLine($"Registration date : {customer.RegistrationDate}");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadKey();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : " + ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    break;
                case 8:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter Customer ID to remove : ");
                    id = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        status = customerService.deleteCustomer(id);

                        if (status)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Customer removed successfully.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Customer deletion failed.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : " + ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }

                    break;
                
                case 9:
                    report = reportGenerator.generateReservationHistoryReport();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("\n\t\t--- Reservation History Report ---");
                    Console.WriteLine("ReservationID\tStartDate\tEndDate\tTotalCost\tCustomer\tVehicle");

                    foreach (DataRow row in report.Rows)
                    {
                        Console.WriteLine($"{row["ReservationID"]}\t{row["StartDate"]}\t{row["EndDate"]}\t{row["TotalCost"]}\t{row["CustomerName"]}\t{row["VehicleDetails"]}");
                    }
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();

                    break;
                case 10:
                    report = reportGenerator.generateVehicleUtilizationReport();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("\n\t\t--- Vehicle Utilization Report ---");
                    Console.WriteLine("VehicleID\tMake\tModel\tTimes Rented");

                    foreach (DataRow row in report.Rows)
                    {
                        Console.WriteLine($"{row["VehicleID"]}\t{row["Make"]}\t{row["Model"]}\t{row["TimesRented"]}");
                    }
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();

                    break;
                case 11:
                    report = reportGenerator.generateRevenueReport();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("\n\t\t--- Revenue Report ---");
                    foreach (DataRow row in report.Rows)
                    {
                        Console.WriteLine($"Total Revenue: {row["TotalRevenue"]}");
                    }
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();

                    break;
                case 12:
                    backToMainMenu = true;
                    break;
                default:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Invalid option, please try again.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
    static void CustomerMenu()
    {
        CustomerServiceHelper customerService = new CustomerServiceHelper();
        ReservationServiceHelper reservationService = new ReservationServiceHelper();
        VehicleServiceHelper vehicleService = new VehicleServiceHelper();

        Customer customer = new Customer();
        Vehicle vehicle = new Vehicle();
        Reservation reservation = new Reservation();
        
        bool backToMainMenu = false;
        bool status = false;
        int id;

        while (!backToMainMenu)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\tCustomer Menu:");
            Console.WriteLine("\t1. View Available Vehicles");
            Console.WriteLine("\t2. Make a Reservation");
            Console.WriteLine("\t3. View My Reservations");
            Console.WriteLine("\t4. Cancel Reservation");
            Console.WriteLine("\t5. Log out");
            Console.WriteLine("------------------------------------");
            Console.Write("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    try
                    {
                        List<Vehicle> vehicleList = new List<Vehicle>();
                        vehicleList = vehicleService.getAvailableVehicles();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("VehicleID\tModel\tMake\tColor\tRegistrationNumber\tAvailability\tDailyRate");
                        foreach(Vehicle v in vehicleList)
                        {
                            Console.WriteLine($"{v.VehicleId}\t{v.Model}\t{v.Make}\t{v.Color}\t{v.RegistrationNumber}\t{v.Availability}\t{v.DailyRate}");
                        }
                        Console.ReadKey();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Press enter to continue...");

                    }
                    catch (Exception ex) {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : " + ex.Message);
                    }
                    break;
                case 2:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter Customer ID : ");
                    reservation.CustomerID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Vehicle ID : ");
                    reservation.VehicleID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Start date : ");
                    reservation.StartDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter End date : ");
                    reservation.EndDate = Convert.ToDateTime(Console.ReadLine());
                    reservation.Status = "Confirmed";
                    Console.WriteLine("Enter Total cost : ");
                    reservation.TotalCost = Convert.ToInt32(Console.ReadLine());    

                    try
                    {
                        status = reservationService.createReservation(reservation);
                        if (status)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Reservation successful.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Reservation failed.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : " + ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    break;
                case 3:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter Customer ID : ");
                    id = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        List<Reservation> myReservations = reservationService.getReservationByCustomerId(id);
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("ReservationID\tCustomerID\tVehicleID\tStartDate\tEndDate\tTotalCost\tStatus");

                        foreach (Reservation r in myReservations)
                        {
                            Console.WriteLine($"{r.ReservationID}\t{r.CustomerID}\t{r.VehicleID}\t{r.StartDate}\t{r.EndDate}\t{r.TotalCost}\t{r.Status}");
                        }
                        Console.ReadKey();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Press enter to continue...");

                    }
                    catch (ReservationException ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Reservation not found : " + ex.Message);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : "+ex.Message);
                    }
                    break;
                case 4:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter ReservationID to cancel reservation : ");
                    id = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        status = reservationService.cancelReservation(id);

                        if (status)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Reservation cancelled successfully.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Reservation cancellation failed.");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                    }
                    catch (ReservationException ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Reservation cancellation failed : " + ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("An error occurred : " + ex.Message);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }

                    break;
                case 5:
                    backToMainMenu = true;
                    break;
                default:
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Invalid option, please try again.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}