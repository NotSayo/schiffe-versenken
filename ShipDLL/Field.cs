namespace ShipDLL;

public class Field :IField
{
    public Point[] FieldArr { get; set; }
    public List<IShip> Ships { get; set; }

    public int LeftHP
    {
        get
        {
            int lives = 0;
            foreach (var ship  in Ships)
            {
                lives += ship.HP;
            }

            return lives;
        }
    }

    public int LeftShips
    {
        get => Ships.Where(s => s.IsAlive).Count();
    }

    public Field()
    {
        FieldArr = new Point[100];
        for (int i = 0; i < 100; i++)
        {
            FieldArr[i] = new Point(i % 10, i / 10) {Status = EPositionStatus.Empty};
        }

        Ships = new List<IShip>();
    }
    
    
}