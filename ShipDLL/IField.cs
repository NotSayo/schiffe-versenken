namespace ShipDLL;

public interface IField
{
    public List<IShip> Ships { get; set; }
    public int LeftHP { get; set; }
    public int LeftShips { get; set; }
    
    public Point[,] FieldArr { get; set; }
}