namespace ShipDLL;

public class Battleships :IBattleships
{
    public int Round { get; }
    public List<IPlayer> Players { get; set; }
    public IPlayer ActivePlayer { get; private set; }
    public EPhase GamePhase { get; set; }

    public Battleships()
    {
        Players = new List<IPlayer>();
        Players.Add(new Player() {ID = 1});
        Players.Add(new Player() {ID = 2});
        GamePhase = EPhase.NotStarted;
        
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
        if(Players[0].Field.LeftHP == 0 || Players[1].Field.LeftHP == 0)
            return true;
        return false;
    }

    public bool SetShip(IShip ship, Point startPoint ,Point endPoint)
    {
        bool result = ActivePlayer.SetShip(ship, startPoint.CalculateBetweenPoints(endPoint));
        
        return result;
        
        
        throw new NotImplementedException(); //TODO throw an Exception if there are too many ships or the ships are invalid. Either self made or ArgumentError
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

    public bool StartGame()
    {
        Players[0].Field.Ships.Add(new Ship(EShip.Destroyer));
        Players[0].Field.Ships.Add(new Ship(EShip.Battleship));
        Players[0].Field.Ships.Add(new Ship(EShip.CruiseShip));
        Players[0].Field.Ships.Add(new Ship(EShip.Submarine));
        
        Players[1].Field.Ships.Add(new Ship(EShip.Destroyer));
        Players[1].Field.Ships.Add(new Ship(EShip.Battleship));
        Players[1].Field.Ships.Add(new Ship(EShip.CruiseShip));
        Players[1].Field.Ships.Add(new Ship(EShip.Submarine));

        return false;
        throw new NotImplementedException(); //TODO after ships are placed start the game, change phase to playing, and return if the game has started or not (bool)
    }

    public void EndGame()
    {
        throw new NotImplementedException(); //TODO switch phase from gameOver to NotStarted
    }

    public void Surrender()
    {
        throw new NotImplementedException(); //TODO endgame 
    }

    public void Draw()
    {
        throw new NotImplementedException(); //TODO draw the game
    }
}