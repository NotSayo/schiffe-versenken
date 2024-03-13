namespace ShipDLL;

public class Battleships :IBattleships
{
    public int Round { get; }
    public List<IPlayer> Players { get; }
    public IPlayer ActivePlayer { get; }
    public EPhase GamePhase { get; }

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
    
    
    

    public void SetShips(IPlayer player, List<IShip> ships)
    {
        throw new NotImplementedException(); //TODO throw an Exception if there are too many ships or the ships are invalid. Either self made or ArgumentError
    }

    public void ChangeTurns()
    {
        throw new NotImplementedException(); //TODO Check if changeTurn is valid
    }

    public bool StartGame()
    {
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