namespace ShipDLL;

public class Field :IField
{
    public Point[,] FieldArr { get; set; }
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

    public int LeftShips => Ships.Count;

    public Field()
    {
        FieldArr = new Point[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                FieldArr[i, j] = new Point() {X = i, Y = j};
            }
        }

        Ships = new List<IShip>();
    }
    
    
}