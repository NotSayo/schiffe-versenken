using ShipDLL;
namespace UnitTest;

public class Tests
{
    private IBattleships _gameController;
    [SetUp]
    public void Setup()
    {
        _gameController = new Battleships();
    }

    [Test]
    public void CheckPlayerCount()
    {
        Assert.That(_gameController.Players.Count, Is.EqualTo(2));
    }

    [Test]
    public void CheckEntryGamePhase()
    {
        _gameController = new Battleships();
        Assert.That(_gameController.GamePhase == EPhase.NotStarted);
    }

    [Test]
    public void CheckPlacingPhase()
    {
        _gameController = new Battleships();
        _gameController.CreateGame();
        Assert.That(_gameController.GamePhase == EPhase.PlacingShips);
    }

    [Test]
    public void CheckActivePlayerOnStart()
    {
        _gameController = new Battleships();
        _gameController.CreateGame();
        Assert.That(_gameController.ActivePlayer, Is.Not.Null);
        Assert.That(_gameController.ActivePlayer == _gameController.Players[0]);
    }
    
    [Test]
    public void CheckActivePlayerOnSwitch()
    {
        _gameController = new Battleships();
        _gameController.CreateGame();
    }

    [Test]
    public void CheckSetShips()
    {
        //TODO Implement the list
        _gameController.CreateGame();
        _gameController.SetShips(_gameController.ActivePlayer, new List<IShip>());
    }
    
    [Test]
    public void CheckAttack()
    {
        //TODO ka
        _gameController.CreateGame();
        _gameController.Attack();
    }
}