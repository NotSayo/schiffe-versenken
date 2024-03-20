namespace ShipDLL;

public class BattleshipAbility : IAbility
{
    public int RechargeState { get; set; }
    public int RechargeTime { get; }
    public void Use()
    {
        throw new NotImplementedException();
    }
}