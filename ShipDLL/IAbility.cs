namespace ShipDLL;

public interface IAbility
{
    public int RechargeState { get; set; }

    public int RechargeTime { get; }
    
       
        
    

    public void Use();
}