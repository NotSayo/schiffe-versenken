namespace ShipDLL;

public interface IBattleships
{
    public void CreateGame();
    public void GameOver();
    public void Move();
    public Field CreateField();
    public void SetShips();
}