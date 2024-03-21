namespace ShipDLL;

public interface IBattleships
{
    public int Round { get; set; }
    public List<IPlayer> Players { get; set; }
    public IPlayer ActivePlayer { get; }
    public EPhase GamePhase { get; set; }
    
    public bool ShowMyField(IPlayer player);
    
    public void CreateGame();
    public bool GameOver(); 
    public bool SetShip(IShip ship, Point startPoint ,Point endPoint);
    public void ChangeTurns();
    public bool StartPlacingShips();
    public void StartGame();
    public bool Attack(Point point);
    public void EndGame();

    public void Surrender();

    public void Draw();
}