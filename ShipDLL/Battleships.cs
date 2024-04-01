namespace ShipDLL;

public class Battleships :IBattleships
{
    public int Round { get; set; }
    public List<IPlayer> Players { get; set; }
    public IPlayer ActivePlayer { get; private set; }
    public EPhase GamePhase { get; set; }
    public EResult Result { get; set; }
    
    public ModalData Modal { get; set; }
    

    public Battleships()
    {
        Modal = new ModalData();
        GeneratePlayers();
        CreateGame();
        Result = EResult.Playing;
    }
    
    public void CreateGame()
    {
        GamePhase = EPhase.NotStarted;
        Result = EResult.Draw;
        ActivePlayer = Players[0];
        Round = 0;
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
    
    public bool CheckGameOver()
    {
        foreach (var player in Players)
        {
            if (player.Field.LeftHP == 0)
            {
                GameOver(Players.Where(p => p != player).First());
                return true;
            }
        }
        return false;
    }

    public void GameOver(IPlayer player)
    {
        GamePhase = EPhase.GameOver;
        GetWonPlayer();
        DisplayModal("Game Over!", "Player " + player.ID + " has won!", "Click \"Confirm\" to play again!", "", true);
    }
    
    public void EndGame()
    {
        GamePhase = EPhase.NotStarted;
        GeneratePlayers();
        CreateGame();
        Modal = new ModalData();
    }

    public void Surrender(IPlayer player)
    {
        if (player == Players[0])
        {
            Result = EResult.Player1Win;
            
        }
        else
        {
            Result = EResult.Player2Win;
        }
        player.HasWon = false;
        GamePhase = EPhase.GameOver;
        GameOver(Players.Where(p => p.ID != player.ID).First());
    }
    
    public void Draw()
    {
        this.Result = EResult.Draw;
        this.GamePhase = EPhase.GameOver;
        DisplayModal("Game Over!", "", "The game has been drawn!");
    }

    public bool StartPlacingShips()
    {
        if(GamePhase != EPhase.NotStarted) return false;
        GamePhase = EPhase.PlacingShips;
        return true;
    }

    private void GeneratePlayers()
    {
        Players = new List<IPlayer>();
        Players.Add(new Player() {ID = 1});
        Players.Add(new Player() {ID = 2});
        Players[0].CreateField();
        Players[1].CreateField();
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
           ChangeTurns();
       StartGame();
        
        return result;
    }

    private IPlayer GetInactivePlayer()
    {
        return Players.Where(p => p != ActivePlayer).First();
    }

    public void ChangeTurns()
    {
        ActivePlayer =  GetInactivePlayer();
        if (ActivePlayer == Players[0])
            Round++;
    }
    
    public bool Attack(Point point)
    {
        if (GamePhase != EPhase.Playing) return false;
        if(GetInactivePlayer().Field.FieldArr[point.GetIndex()].Status != EPositionStatus.Empty && GetInactivePlayer().Field.FieldArr[point.GetIndex()].Status != EPositionStatus.Ship)
            return false;
        if (GetInactivePlayer().Field.FieldArr[point.GetIndex()].ShipPart == null)
        {
            GetInactivePlayer().Field.FieldArr[point.GetIndex()].Status = EPositionStatus.Miss;
            ActivePlayer.EnemyField.FieldArr[point.GetIndex()] = GetInactivePlayer().Field.FieldArr[point.GetIndex()];
            ChangeTurns();
            CheckGameOver();
            return false;
        }
        else
        {
            GetInactivePlayer().Field.FieldArr[point.GetIndex()].Status = EPositionStatus.Hit;
            GetInactivePlayer().Field.FieldArr[point.GetIndex()].ShipPart.OnHit();
            ActivePlayer.EnemyField.FieldArr[point.GetIndex()] = GetInactivePlayer().Field.FieldArr[point.GetIndex()];
            ChangeTurns();
            CheckGameOver();
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

    public void DisplayModal(string title = "", string lead = "", string desc = "", string extraInfo = "", bool isVisible = true, EModalButtons buttons = EModalButtons.Confirm)
    {
        Modal = new ModalData()
        {
            Title = title,
            Lead = lead,
            Description = desc,
            ExtraInformations = extraInfo,
            isVisible = isVisible,
            Buttons = buttons
        };
    }
}