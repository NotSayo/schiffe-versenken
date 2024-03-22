namespace ShipDLL;

public class WrongMovementError : Exception
{
    public WrongMovementError()  {throw new Exception("Wrong movement");}
    public WrongMovementError(string message) { throw new Exception(message); }

}