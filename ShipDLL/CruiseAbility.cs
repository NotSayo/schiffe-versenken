namespace ShipDLL;

public class CruiseAbility :IAbility
{
    public int RechargeState { get; set; }
    public int RechargeTime { get; }
    public void Use()
    {
        throw new NotImplementedException();
    }
}