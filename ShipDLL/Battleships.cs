namespace ShipDLL;

public class Battleships :IBattleships
{
    public int Round { get; }
    public List<IPlayer> Players { get; }
    public IPlayer ActivePlayer { get; }
    public EPhase GamePhase { get; }

    public void CreateGame()
    {
        Players[0].CreateField();
        
        Players[1].CreateField();
        
        Players[0].CreateEnemyField(Players[1]);
        
        Players[1].CreateEnemyField(Players[0]);
        
    }

    public bool GameOver()
    {
        if(Players[0].Field.LeftHP == 0 || Players[1].Field.LeftHP == 0)
            return true;

        return false;
    }
    
    
    

    public void SetShips(IPlayer player, List<IShip> ships)
    {
        throw new NotImplementedException();
    }

    public void ChangeTurns()
    {
        throw new NotImplementedException();
    }
}