namespace ShipDLL;

public interface IShip
{
    public int HP { get; }
    public EShip Type { get; set; }
    public bool IsAlive { get; set; }
    public EShipDirection Direction { get; set; }
    public Point[] Positions { get; set; }
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
    public int UpdateHP();
    
    public List<ShipPart> ShipParts { get; set; }
}