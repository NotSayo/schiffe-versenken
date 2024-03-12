namespace ShipDLL;

public class Ship : IShip
{
    public int HP { get; set; }
    public EShip Type { get; set; }
    public bool IsAlive { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public Point[] Positions { get; set; }
    
    
}