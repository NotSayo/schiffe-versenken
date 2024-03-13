namespace ShipDLL;

public interface IBattleships
{
    public int Round { get; }
    public List<IPlayer> Players { get; }
    public IPlayer ActivePlayer { get; }
    public EPhase GamePhase { get; }
    
    public void CreateGame();
    public bool GameOver(); 
    public bool SetShip(IPlayer player, List<IShip> ships);
    public void ChangeTurns();
    
    public bool StartGame();

    public void EndGame();

    public void Surrender();

    public void Draw();
}