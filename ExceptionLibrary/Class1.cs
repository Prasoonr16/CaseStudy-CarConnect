namespace ExceptionLibrary
{

	[Serializable]
	public class VehicleNotFoundException : Exception
	{
		public VehicleNotFoundException() { }
		public VehicleNotFoundException(string message) : base(message) { }
		public VehicleNotFoundException(string message, Exception inner) : base(message, inner) { }
		protected VehicleNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}


	[Serializable]
	public class ReservationException : Exception
	{
		public ReservationException() { }
		public ReservationException(string message) : base(message) { }
		public ReservationException(string message, Exception inner) : base(message, inner) { }
		protected ReservationException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}


	[Serializable]
	public class AuthenticationException : Exception
	{
		public AuthenticationException() { }
		public AuthenticationException(string message) : base(message) { }
		public AuthenticationException(string message, Exception inner) : base(message, inner) { }
		protected AuthenticationException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}


	[Serializable]
	public class AdminNotFoundException : Exception
	{
		public AdminNotFoundException() { }
		public AdminNotFoundException(string message) : base(message) { }
		public AdminNotFoundException(string message, Exception inner) : base(message, inner) { }
		protected AdminNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}


	[Serializable]
	public class InvalidInputException : Exception
	{
		public InvalidInputException() { }
		public InvalidInputException(string message) : base(message) { }
		public InvalidInputException(string message, Exception inner) : base(message, inner) { }
		protected InvalidInputException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}


	[Serializable]
	public class DatabaseConnectionException : Exception
	{
		public DatabaseConnectionException() { }
		public DatabaseConnectionException(string message) : base(message) { }
		public DatabaseConnectionException(string message, Exception inner) : base(message, inner) { }
		protected DatabaseConnectionException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
