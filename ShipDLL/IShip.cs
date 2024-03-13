namespace ShipDLL;

public interface IShip
{
    public int HP { get; set; }
    public EShip Type { get; set; }
    public bool IsAlive { get; set; }
    public Point[] Positions { get; set; }
}