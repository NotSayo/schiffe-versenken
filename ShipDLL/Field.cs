namespace ShipDLL;

public class Field :IField
{
    private Point[,] _field;
    public List<IShip> Ships { get; set; }
    public int LeftHP { get; set; }
    public int LeftShips { get; set; }
    
    public Field()
    {
        CalculateLeftShips();
        CalculateLeftHP();
        _field = new Point[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _field[i, j] = new Point();
                _field[i, j].X = i;
                _field[i, j].Y = j;
            }
        }
    }
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