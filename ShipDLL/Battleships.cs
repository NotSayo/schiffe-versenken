namespace ShipDLL;

public class Battleships :IBattleships
{
    public List<IPlayer> Players { get; }
    public IPlayer ActivePlayer { get; }
    public EPhase GamePhase { get; }

    public void CreateGame()
    {
        throw new NotImplementedException();
    }

    public void GameOver()
    {
        throw new NotImplementedException();
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }
    

    public void SetShips(IPlayer player, List<IShip> ships)
    {
        throw new NotImplementedException();
    }

    public Field CreateField()
    {
        throw new NotImplementedException();
    }

    public void SetShips()
    {
        throw new NotImplementedException();
    }
}