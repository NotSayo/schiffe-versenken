namespace ShipDLL;

public class Battleships :IBattleships
{
    public int Round { get; set; }
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
       bool result = ActivePlayer.SetShip(ship, startPoint.CalculateBetweenPoints(endPoint));
       if (ActivePlayer.UnplacedShips.Count() == 0 && ActivePlayer == Players[0]) 
           ChangeActivePlayer();
       StartGame();
        
        return result;
    }

    private IPlayer GetInactivePlayer()
    {
        return Players.Where(p => p != ActivePlayer).First();
    }

    public void ChangeTurns()
    {
        ChangeActivePlayer();
        if (ActivePlayer == Players[0])
            Round++;
    }

    private void ChangeActivePlayer()
    {
        ActivePlayer =  GetInactivePlayer();
    }

    public void StartGame()
    {
        if (this.GamePhase == EPhase.PlacingShips && Players[0].Field.Ships.Count == 4 && Players[1].Field.Ships.Count == 4 && Players[0].UnplacedShips.Count == 0 && Players[1].UnplacedShips.Count == 0)
        {
            this.GamePhase = EPhase.Playing;
            ShowMyField(Players[1]);
            ChangeTurns();
            ShowMyField(Players[0]);
           

        }
    }

    public void EndGame()
    {
        if (this.GamePhase == EPhase.GameOver) 
            this.GamePhase = EPhase.NotStarted;
        
    }

    public void Surrender()
    {
        var SurrenderedPlayer = GetInactivePlayer();
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
    public bool Attack(Point point)
    {
        if(GetInactivePlayer().Field.FieldArr[point.GetIndex()].Status != EPositionStatus.Empty && GetInactivePlayer().Field.FieldArr[point.GetIndex()].Status != EPositionStatus.Ship)
            return false;
        if (GetInactivePlayer().Field.FieldArr[point.GetIndex()].ShipPart == null)
        {
            GetInactivePlayer().Field.FieldArr[point.GetIndex()].Status = EPositionStatus.Miss;
            ActivePlayer.EnemyField.FieldArr[point.GetIndex()] = GetInactivePlayer().Field.FieldArr[point.GetIndex()];
            ChangeTurns();
            return false;
        }
        else
        {
            GetInactivePlayer().Field.FieldArr[point.GetIndex()].Status = EPositionStatus.Hit;
            GetInactivePlayer().Field.FieldArr[point.GetIndex()].ShipPart.OnHit();
            ActivePlayer.EnemyField.FieldArr[point.GetIndex()] = GetInactivePlayer().Field.FieldArr[point.GetIndex()];
            ChangeTurns();
            return true;
        }
        
    }
    
    public bool ShowMyField(IPlayer player)
    {
        if(GamePhase != EPhase.Playing) return false;
        if(player != ActivePlayer) return false;
        
        player.ShowMyField = !player.ShowMyField;
        return player.ShowMyField;
    }

    public void Draw()
    {
        this.Result = EResult.Draw;
        this.GamePhase = EPhase.GameOver;
        Console.WriteLine("Game has been drawn");
    }
}