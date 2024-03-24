namespace ShipDLL;

public interface IBattleships
{
    public int Round { get; set; }
    public List<IPlayer> Players { get; set; }
    public IPlayer ActivePlayer { get; }
    public EPhase GamePhase { get; set; }
    public ModalData Modal { get; set; }
    
    public bool ShowMyField(IPlayer player);
    
    public void CreateGame();
    public bool SetShip(IShip ship, Point startPoint ,Point endPoint);
    public void ChangeTurns();
    public bool StartPlacingShips();
    public void StartGame();
    public bool Attack(Point point);
    public void EndGame();
    public bool CheckGameOver();
    public void DisplayModal(string title, string lead, string desc, string extraInfo, bool isVisible, EModalButtons buttons);
    public void GameOver(IPlayer player);

    public void Surrender(IPlayer player);

    public void Draw();
}