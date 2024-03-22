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
    public IAbility Ability { get; set; }
    public Point MiddlePoint { get; set; }
    public int turningThreshhold { get; set; }

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
        SetPositions();
        SetAbility();
        ShipParts = new List<ShipPart>();
        this.turningThreshhold = (int)Math.Abs((double)Type / 2);
        this.MiddlePoint = new Point((int)Math.Floor((double)(-StartPoint.X + EndPoint.X) / 2), (int)Math.Floor((double)(-StartPoint.Y + EndPoint.Y) / 2));

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

    public void SetPositions()
    {
        if (this.Type == EShip.OceanGate_Submarine)
        {
            this.Positions[1] = EndPoint;
            this.Positions[0] = StartPoint;

        }
        else if (this.Type == EShip.GorlockTheDestroyer)
        {
            this.Positions[4] = EndPoint;
            this.Positions[0] = StartPoint;
            if (this.Direction == EShipDirection.HorizontalLeft)
            {
                for (int i = 1; i < 4; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X - i, StartPoint.Y);
                }
            }
            if (this.Direction == EShipDirection.VerticalDown)
            {
                for (int i = 1; i < 4; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X, StartPoint.Y + 1);
                }
            }
            if (this.Direction == EShipDirection.VerticalUp)
            {
                for (int i = 1; i < 4; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X, StartPoint.Y - i);
                }
            }
            if (this.Direction == EShipDirection.HorizontalRight)
            {
                for (int i = 1; i < 4; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X + i, StartPoint.Y );
                }
            }
        }
        else if (this.Type == EShip.CruiseShip)
        {
            this.Positions[2] = EndPoint;
            this.Positions[0] = StartPoint;
            if (this.Direction == EShipDirection.HorizontalLeft)
            {
                for (int i = 1; i < 2; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X - i, StartPoint.Y);
                }
            }
            if (this.Direction == EShipDirection.VerticalDown)
            {
                for (int i = 1; i < 2; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X, StartPoint.Y + 1);
                }
            }
            if (this.Direction == EShipDirection.VerticalUp)
            {
                for (int i = 1; i < 2; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X, StartPoint.Y - i);
                }
            }
            if (this.Direction == EShipDirection.HorizontalRight)
            {
                for (int i = 1; i < 2; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X + i, StartPoint.Y );
                }
            }
        }
        else if (this.Type == EShip.Battleship)
        {
            this.Positions[3] = EndPoint;
            this.Positions[0] = StartPoint;
            if (this.Direction == EShipDirection.HorizontalLeft)
            {
                for (int i = 1; i < 3; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X - i, StartPoint.Y);
                }
            }
            if (this.Direction == EShipDirection.VerticalDown)
            {
                for (int i = 1; i < 3; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X, StartPoint.Y + 1);
                }
            }
            if (this.Direction == EShipDirection.VerticalUp)
            {
                for (int i = 1; i < 3; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X, StartPoint.Y - i);
                }
            }
            if (this.Direction == EShipDirection.HorizontalRight)
            {
                for (int i = 1; i < 3; i++)
                {
                    this.Positions[i] = new Point(StartPoint.X + i, StartPoint.Y );
                }
            }
        }
    }

    private void SetAbility()
    {
        switch (Type)
        {
            case EShip.GorlockTheDestroyer:
                Ability = new GorlockAbility();
                break;
            case EShip.Battleship:
                Ability = new BattleshipAbility();
                break;
            case EShip.CruiseShip:
                Ability = new CruiseAbility();
                break;
            case EShip.OceanGate_Submarine:
                Ability = new SubAbility();
                break;
                
        }
    }
    
}