namespace ShipDLL;

public interface IBattleships
{
    public List<IPlayer> Players { get; }
    public IPlayer ActivePlayer { get; }
    public EPhase GamePhase { get; }
    public void CreateGame();
    public void GameOver();
    public void Attack();
    public void SetShips(IPlayer player, List<IShip> ships);
}