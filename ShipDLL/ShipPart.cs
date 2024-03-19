namespace ShipDLL;

public class ShipPart
{
    public IShip Parent { get; set; }
    public int NumberInSequence { get; set; }
    public bool IsAlive { get; set; }
    
    public ShipPart(IShip parent, int numberInSequence)
    {
        Parent = parent;
        NumberInSequence = numberInSequence;
    }
}