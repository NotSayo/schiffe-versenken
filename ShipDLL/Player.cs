﻿namespace ShipDLL;

public class Player:IPlayer
{
    
    public int ID { get; set; }
    public List<IShip> UnplacedShips { get; set; }
    public IField Field { get; set; }
    public bool HasMoved { get; set; }
    public IField EnemyField { get; set; }
    public bool HasWon { get; set; }
    public bool AcceptDraw { get; set; }


    public bool ShowMyField { get; set; } = true;

    public Player()
    {
        UnplacedShips = new List<IShip>()
        {
            new Ship(EShip.Battleship), new Ship(EShip.GorlockTheDestroyer), new Ship(EShip.OceanGate_Submarine), new Ship(EShip.CruiseShip)
        };
        UnplacedShips = UnplacedShips.OrderByDescending(s => (int)s.Type).ToList();
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
        if (Points.Count() != (int)ship.Type)
            return false;
        int i = 1;
        foreach (var point in Points)
        {
            if(Field.FieldArr[point.GetIndex()].ShipPart != null)
                return false;
            ShipPart part = new ShipPart(ship, i);
            ship.ShipParts.Add(part);
            Field.FieldArr[point.GetIndex()].ShipPart = part;
            Field.FieldArr[point.GetIndex()].Status = EPositionStatus.Ship;
            i++;
        }
        Field.Ships.Add(ship);
        UnplacedShips.Remove(ship);
        ship.UpdateHP();
        
        return true;
    }
    
}