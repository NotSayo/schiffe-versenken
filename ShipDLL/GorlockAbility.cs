namespace ShipDLL;

public class GorlockAbility : IAbility
{
    private int _rechargeTime;
    public int RechargeState { get; set; }

    public int RechargeTime
    {
        get
        {
            return _rechargeTime;
        }
    }

    public void Use()
    {
        if (_rechargeTime == RechargeState)
        {
            //if(this.)
            throw new NotImplementedException();
        }
    }
}