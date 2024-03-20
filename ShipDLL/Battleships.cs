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
        SetShipPositions(ship, startPoint, endPoint);
        CalculateShipDirection(ship, startPoint, endPoint);
        bool result = ActivePlayer.SetShip(ship, startPoint.CalculateBetweenPoints(endPoint));
        if (ActivePlayer.UnplacedShips.Count() == 0 && ActivePlayer == Players[0]) 
           ChangeActivePlayer();
        StartGame();
        
        return result;
    }
    private void CalculateShipDirection(IShip ship, Point startPoint, Point endPoint)
    {
        if (startPoint.X == endPoint.X)
        {
            if(startPoint.Y > endPoint.Y)
                ship.Direction = EShipDirection.VerticalDown;
            else
                ship.Direction = EShipDirection.VerticalUp;
        }
        else
        {
            if(startPoint.X > endPoint.X)
                ship.Direction = EShipDirection.HorizontalLeft;
            else
            ship.Direction = EShipDirection.HorizontalRight;
        }
    }
    private void SetShipPositions(IShip ship, Point startPoint, Point endPoint)
    {
        ship.StartPoint = startPoint;
        ship.EndPoint = endPoint;
    }

    private IPlayer GetInactivePlayer()
    {
        return Players.Where(p => p != ActivePlayer).First();
    }

    public void ChangeTurns()
    {
        ChangeActivePlayer();
    }

    public void Move(IShip targetShip, Point EndPoint)
    {
        if(targetShip.HP == 0) return;
        if(targetShip.Direction ==)
    }
    private void MoveLeft(IShip targetShip)
    {
        if(targetShip.StartPoint.X == 0) return;
        targetShip.StartPoint.X--;
        targetShip.EndPoint.X--;
    }
    private void MoveRight(IShip targetShip)
    {
        if(targetShip.EndPoint.X == 9) return;
        
        if(targetShip.Direction == EShipDirection.HorizontalRight)
        {
            targetShip.StartPoint.X++;
            targetShip.EndPoint.X++;
        }

        if (targetShip.Direction == EShipDirection.HorizontalLeft)
        {
            var tmp = targetShip.StartPoint.X;
            targetShip.StartPoint.X = targetShip.EndPoint.X;
            targetShip.EndPoint.X = tmp;
        }

        if (targetShip.Direction == EShipDirection.VerticalUp && targetShip.StartPoint.X != 8 )
        {
            targetShip.StartPoint.X++;
            targetShip.EndPoint.X++;
        }
        
            
        
    }
    private void MoveUp(IShip targetShip)
    {
        if(targetShip.StartPoint.Y == 0) return;
        targetShip.StartPoint.Y++;
        targetShip.EndPoint.Y++;
    }
    private void MoveDown(IShip targetShip)
    {
        if(targetShip.EndPoint.Y == 9) return;
        targetShip.StartPoint.Y--;
        targetShip.EndPoint.Y--;
    }
    private void ChangeActivePlayer()
    {
        ActivePlayer =  GetInactivePlayer();
    }

    public void StartGame()
    {
        if (this.GamePhase == EPhase.PlacingShips && Players[0].Field.Ships.Count == 4 && Players[1].Field.Ships.Count == 4 && Players[0].UnplacedShips.Count == 0 && Players[1].UnplacedShips.Count == 0)
        {
            ChangeTurns();
            this.GamePhase = EPhase.Playing;
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

    public void Draw()
    {
        if(this.GamePhase == EPhase.Playing && Players.Where(p => p.AcceptDraw).Count() == 2)
        {  
            this.Result = EResult.Draw;
            this.GamePhase = EPhase.NotStarted;
        }
    }
}