namespace ShipDLL;

public class Ship : IShip
{
    public int HP { get; set; }
    public EShip Type { get; set; }
    public bool IsAlive { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public Point[] Positions { get; set; }
    public int NumberInSequence { get; set; }

    public Ship(EShip type)
    {
        this.Type = type;
        IsAlive = true;

        switch (type)
        {
            case EShip.Destroyer:
                HP = 5;
                break;
            case EShip.Battleship:
                HP = 4;
                break;
            case EShip.CruiseShip:
                HP = 3;
                break;
            case EShip.Submarine:
                HP = 2;
                break;
                
        }
        
    }
    
}