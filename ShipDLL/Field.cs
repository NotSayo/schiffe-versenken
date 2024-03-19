namespace ShipDLL;

public class Field :IField
{
    public IShip[] FieldArr { get; set; }
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
        FieldArr = new Ship[100];

        Ships = new List<IShip>();
    }
    
    
}