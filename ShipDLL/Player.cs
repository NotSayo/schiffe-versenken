namespace ShipDLL;

public class Player:IPlayer
{
    public int ID { get; set; }
    public IField Field { get; set; }
    
    public IField EnemyField { get; set; }


    public void CreateField()
    {
        this.Field = new Field();
        
    }
    public void CreateEnemyField(IPlayer player)
    {
        this.EnemyField = new Field();
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
                //TODO: Change Player function to change turn
            }
        }

        return false; // TODO fix this
    }
}