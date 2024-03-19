namespace ShipDLL;

public class Player:IPlayer
{
    
    public int ID { get; set; }
    public List<IShip> UnplacedShips { get; set; }
    public IField Field { get; set; }
    public bool HasMoved { get; set; }
    public IField EnemyField { get; set; }

    public Player()
    {
        UnplacedShips = new List<IShip>()
        {
            new Ship(EShip.Battleship), new Ship(EShip.Destroyer), new Ship(EShip.Submarine), new Ship(EShip.CruiseShip)
        };
    }

    public void CreateField()
    {
        this.Field = new Field();
    }

    public bool SetShip(IShip ship, List<Point> Points)
    {
        if (UnplacedShips.Where(s => s.Type == ship.Type).Count() == 0)
            return false;
        if (Points.Count() != ship.HP)
            return false;
        int i = 1;
        Field.Ships.Add(ship);
        UnplacedShips.Remove(ship);
        foreach (var point in Points)
        {
            ship.NumberInSequence = i;
            Field.FieldArr[point.GetIndex()] = ship;
        }
        
        return true;
    }
    
    public void CreateEnemyField(IPlayer player)
    {
        this.EnemyField =  player.Field;
    }
    public bool Attack(Point point)
    {
        foreach (var ship in EnemyField.Ships)
        {
            if (ship.Positions.Contains(point))
            {
                ship.HP--;
                point.Status = EPositionStatus.Hit;
                if (ship.HP == 0)
                {
                    ship.IsAlive = false;
                }
            }
            else
            {
                point.Status = EPositionStatus.Miss;
            }
        }

        return false; // TODO fix this
    }
}