using DAO;
using Entity;
using ExceptionLibrary;
using NUnit.Framework;

[TestFixture]
public class AuthenticationServiceTests
{
    private AuthenticationService _authService;

    [SetUp]
    public void Setup()
    {
        _authService = new AuthenticationService();
    }

    [Test]
    public void AuthenticateCustomer_InvalidCredentials_ShouldThrowAuthenticationException()
    {
        // Arrange
        string username = "invalidUser";
        string password = "wrongPassword";

        // Act & Assert
        var ex = Assert.Throws<ExceptionLibrary.AuthenticationException>(() => _authService.AuthenticateCustomer(username, password));
        Assert.That(ex.Message, Is.EqualTo("Customer not found."));
    }
}

[TestFixture]
public class CustomerServiceTests
{
    private CustomerService _customerService;

    [SetUp]
    public void Setup()
    {
        _customerService = new CustomerService();
    }

    [Test]
    public void UpdateCustomer_ValidCustomerData_ShouldReturnTrue()
    {
        // Arrange
        var customer = new Customer { CustomerId = 4, FirstName = "Sneha", LastName = "Rao", Email = "sneha@gmail.com", PhoneNumber = "9424858562", 
        Address = "78 Residency Road, Bangalore, Karnataka"
        };

        // Act
        bool result = _customerService.UpdateCustomer(customer.CustomerId, customer);

        // Assert
        Assert.IsTrue(result);
    }
}

[TestFixture]
public class VehicleServiceTests
{
    private VehicleService _vehicleService;

    [SetUp]
    public void Setup()
    {
        _vehicleService = new VehicleService();
    }

    [Test]
    public void AddVehicle_ValidVehicleData_ShouldReturnTrue()
    {
        // Arrange
        var vehicle = new Vehicle { Model = "Selyos", Make = "Kia", Year = 2020, Color = "White", RegistrationNumber = "MH01CA4545",Availability = true, DailyRate = 1500 };

        // Act
        bool result = _vehicleService.AddVehicle(vehicle);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void UpdateVehicle_ValidVehicleId_ShouldReturnTrue()
    {
        // Arrange
        var vehicle = new Vehicle { VehicleId = 1, Model = "Nexon", Make = "Tata", Year = 2022, Color = "Grey",
        RegistrationNumber = "DL20JK525204", Availability = true, DailyRate = 2000 };

        // Act
        bool result = _vehicleService.UpdateVehicle(vehicle.VehicleId, vehicle);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void GetAvailableVehicles_ShouldReturnAvailableVehicles()
    {
        // Act
        var availableVehicles = _vehicleService.GetAvailableVehicles();

        // Assert
        Assert.IsNotNull(availableVehicles);
        Assert.IsTrue(availableVehicles.All(v => v.Availability == true));
    }

    [Test]
    public void GetAllVehicles_ShouldReturnAllVehicles()
    {
        // Act
        var allVehicles = _vehicleService.GetAllVehicles();

        // Assert
        Assert.IsNotNull(allVehicles);
    }
}



