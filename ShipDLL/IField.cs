namespace ShipDLL;

public interface IField
{
    public List<IShip> Ships { get; set; }
    public int LeftHP { get;  }
    public int LeftShips { get; }
    
    public IShip[] FieldArr { get; set; }
}