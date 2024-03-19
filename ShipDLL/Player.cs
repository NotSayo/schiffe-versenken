namespace ShipDLL;

public class Player:IPlayer
{
    
    public int ID { get; set; }
    public List<IShip> UnplacedShips { get; set; }
    public IField Field { get; set; }
    public bool HasMoved { get; set; }
    public IField EnemyField { get; set; }
    public bool HasWon { get; set; }
    public bool AcceptDraw { get; set; }

    public Player()
    {
        UnplacedShips = new List<IShip>()
        {
            new Ship(EShip.Battleship), new Ship(EShip.Destroyer), new Ship(EShip.Submarine), new Ship(EShip.CruiseShip)
        };
        HasWon = false; 
    }

    public void CreateField()
    {
        this.Field = new Field();
        this.EnemyField = new Field();
    }

    public bool SetShip(IShip ship, List<Point> Points)
    { 
        if (UnplacedShips.Where(s => s.Type == ship.Type).Count() == 0)
            return false;
        if (Points.Count() != ship.HP)
            return false;
        int i = 1;
        foreach (var point in Points)
        {
            if(Field.FieldArr[point.GetIndex()] != null)
                return false;
            ShipPart part = new ShipPart(ship, i);
            ship.ShipParts.Add(part);
            Field.FieldArr[point.GetIndex()] = part;
            i++;
        }
        Field.Ships.Add(ship);
        UnplacedShips.Remove(ship);
        
        return true;
    }
    
    public bool Attack(Point point)
    {
        // foreach (var ship in EnemyField.Ships)
        // {
        //     if (ship.Positions.Contains(point))
        //     {
        //         ship.HP--;
        //         point.Status = EPositionStatus.Hit;
        //         if (ship.HP == 0)
        //         {
        //             ship.IsAlive = false;
        //         }
        //     }
        //     else
        //     {
        //         point.Status = EPositionStatus.Miss;
        //     }
        // }

        return false; // TODO fix this
    }
}