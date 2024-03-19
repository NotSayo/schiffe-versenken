namespace ShipDLL;

public class Battleships :IBattleships
{
    public int Round { get; }
    public List<IPlayer> Players { get; set; }
    public IPlayer ActivePlayer { get; private set; }
    public EPhase GamePhase { get; set; }
    public EResult Result { get; set; }

    public Battleships()
    {
        Players = new List<IPlayer>();
        Players.Add(new Player() {ID = 1});
        Players.Add(new Player() {ID = 2});
        GamePhase = EPhase.NotStarted;
        Result = EResult.Draw;
        
        ActivePlayer = Players[0];
    }

    public bool StartPlacingShips()
    {
        if(GamePhase != EPhase.NotStarted) return false;
        GamePhase = EPhase.PlacingShips;
        return true;
    }

    public void CreateGame()
    {
        Players[0].CreateField();
        Players[1].CreateField();

        Players[0].CreateEnemyField(Players[1]);
        Players[1].CreateEnemyField(Players[0]);
    }
    

    public bool GameOver()
    {
        if (Players[0].Field.LeftHP == 0 || Players[1].Field.LeftHP == 0)
        {
            GamePhase = EPhase.GameOver;
            GetWonPlayer();
            return true;
        }
           
        return false;
    }
    private void GetWonPlayer()
    {
        if (Players[0].Field.LeftHP == 0)
        {
            Players[1].HasWon = true;
            Result = EResult.Player2Win;
            return;
        }
        if (Players[1].Field.LeftHP == 0)
        {
            Players[0].HasWon = true;
            Result = EResult.Player1Win;
            return;
        }
    }

    public bool SetShip(IShip ship, Point startPoint ,Point endPoint)
    {
        return ActivePlayer.SetShip(ship, startPoint.CalculateBetweenPoints(endPoint));
        throw new TooManyShipsExeption();
    }

    public void ChangeTurns()
    {
        if(ActivePlayer.HasMoved) ChangeActivePlayer();
    }

    private void ChangeActivePlayer()
    {
        foreach (var player in Players)
        {
            if (player != ActivePlayer)
            {
                ActivePlayer = player;
                return;
            }
        }
    }

    public void StartGame()
    {
        if(this.GamePhase == EPhase.PlacingShips && Players[0].Field.Ships.Count == 4 && Players[1].Field.Ships.Count == 4 && Players[0].UnplacedShips.Count == 0 && Players[1].UnplacedShips.Count == 0)
            this.GamePhase = EPhase.Playing;
        
    }

    public void EndGame()
    {
        if (this.GamePhase == EPhase.GameOver) 
            this.GamePhase = EPhase.NotStarted;
        
    }

    public void Surrender()
    {
        var SurrenderedPlayer = Players.Where(p => p != ActivePlayer).First();
        if (SurrenderedPlayer == Players[0])
        {
            Result = EResult.Player1Win;
            
        }
        else
        {
            Result = EResult.Player2Win;
        }
        SurrenderedPlayer.HasWon = false;
        GamePhase = EPhase.GameOver;
            
    }

    public void Draw()
    {
        if(this.GamePhase == EPhase.GameOver)
        {  
            this.Result = EResult.Draw;
            this.GamePhase = EPhase.NotStarted;
        }
    }
}