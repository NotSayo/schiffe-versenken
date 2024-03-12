namespace ShipDLL;

public class Field :IField
{
    public List<IShip> Ships { get; set; }
    public int LeftHP { get; set; }
    public int LeftShips { get; set; }
    
    private void CalculateLeftHP()
    {
        LeftHP = 0;
        foreach (var ship in Ships)
        {
            LeftHP += ship.HP;
        }
    }
    private void CalculateLeftShips()
    {
        LeftShips = 0;
        foreach (var ship in Ships)
        {
            if (ship.IsAlive)
            {
                LeftShips++;
            }
        }
    }
    
    
}