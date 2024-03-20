using System.Net;

namespace ShipDLL;

public class Ship : IShip
{
    public IAbility Ability { get; set; }
    public int HP { get; set; }
    public EShip Type { get; set; }
    public bool IsAlive { get; set; }
    public Point[] Positions { get; set; }
    
    public List<ShipPart> ShipParts { get; set; }

    public Ship(EShip type)
    {
        this.Type = type;
        IsAlive = true;
        
        HP = (int) type;
        ShipParts = new List<ShipPart>();

        switch (type)
        {
            case EShip.Destroyer:
                Ability = new GorlockAbility();
                break;
            case EShip.Battleship:
                Ability = new BattleshipAbility();
                break;
            case EShip.CruiseShip:
                Ability = new CruiseAbility();
                break;
            case EShip.Submarine:
                Ability = new SubAbility();
                break;
                
        }

    }
    
}