using System.Net;

namespace ShipDLL;

public class Ship : IShip
{

    private int hp;
    public int HP
    {
        get => hp;
        set => hp = value;

    }
    public EShip Type { get; set; }
    public bool IsAlive { get; set; }
    public Point[] Positions { get; set; }
    public EShipDirection Direction { get; set; }
    public List<ShipPart> ShipParts { get; set; }
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public int UpdateHP()
    {
        HP = ShipParts.Where(s => s.IsAlive).Count();
        if(HP == 0)
            IsAlive = false;
        return HP;
    }

    public Ship(EShip type)
    {
        this.Type = type;
        IsAlive = true;
        
        ShipParts = new List<ShipPart>();

        // switch (type)
        // {
        //     case EShip.Destroyer:
        //         HP = 5;
        //         break;
        //     case EShip.Battleship:
        //         HP = 4;
        //         break;
        //     case EShip.CruiseShip:
        //         HP = 3;
        //         break;
        //     case EShip.Submarine:
        //         HP = 2;
        //         break;
        //         
        // }

    }
    
}