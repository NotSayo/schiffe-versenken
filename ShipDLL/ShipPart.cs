namespace ShipDLL;

public class ShipPart
{
    public Point Position { get; set; }
    public IShip Parent { get; set; }
    public int NumberInSequence { get; set; }
    public bool IsAlive { get; set; }

    public void OnHit()
    {
        IsAlive = false;
        Parent.UpdateHP();
    }

    
    public ShipPart(IShip parent, int numberInSequence)
    {
        Parent = parent;
        NumberInSequence = numberInSequence;
        IsAlive = true;
    }
}