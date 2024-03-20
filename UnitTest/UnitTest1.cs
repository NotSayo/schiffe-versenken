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
        _gameController.CreateGame();
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
        _gameController.StartPlacingShips();
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
    public void CheckSetShips()
    {
        _gameController.CreateGame();
        var ships = new List<IShip>()
        {
            new Ship( EShip.Battleship ),
            new Ship(EShip.GorlockTheDestroyer),
            new Ship(EShip.OceanGate_Submarine),
            new Ship(EShip.CruiseShip)
          
        };
        _gameController.StartPlacingShips();
        Assert.That(_gameController.ActivePlayer.Field.Ships.Count, Is.EqualTo(4));
    }

    [Test]
    public void CheckFieldAssignment()
    {
        _gameController.CreateGame();
        Assert.That(_gameController.Players[0].Field, Is.Not.Null);
        Assert.That(_gameController.Players[0].EnemyField, Is.Not.Null);
        Assert.That(_gameController.Players[1].Field, Is.Not.Null);
        Assert.That(_gameController.Players[1].EnemyField, Is.Not.Null);
    } 
    
    [Test]
    public void CheckSwitchTurn()
    {
        _gameController.CreateGame();
        IPlayer player = _gameController.ActivePlayer;
        _gameController.ChangeTurns();
        Assert.That(_gameController.ActivePlayer != player);
    }
    
    [Test]
    public void CheckFieldCreation()
    {
        _gameController.CreateGame();
        Assert.That(_gameController.Players[0].Field.FieldArr.Length, Is.EqualTo(100));
        Assert.That(_gameController.Players[1].Field.FieldArr.Length, Is.EqualTo(100));
    }

    [Test]
    public void CheckLeftShips()
    {
        _gameController.CreateGame();
        Assert.That(_gameController.Players[0].Field.Ships.Count == _gameController.Players[0].Field.LeftShips);
        Assert.That(_gameController.Players[1].Field.Ships.Count == _gameController.Players[1].Field.LeftShips);
    }

    [Test]
    public void CheckIfTypeAndHPMatch()
    {
        _gameController.StartPlacingShips();
        
        
        Assert.That(_gameController.ActivePlayer.Field.Ships.Count, Is.EqualTo(4));
        Assert.That(_gameController.ActivePlayer.Field.Ships[0].HP == 5);
        Assert.That(_gameController.ActivePlayer.Field.Ships[1].HP == 4);
        Assert.That(_gameController.ActivePlayer.Field.Ships[2].HP == 3);
        Assert.That(_gameController.ActivePlayer.Field.Ships[3].HP == 2);
    }

    [Test]
    public void CheckRound()
    {
        _gameController.CreateGame();
        Assert.That(_gameController.Round, Is.EqualTo(0));
    }

    [Test]
    public void CheckPoint()
    {
        Point p = new Point(5, 6);
        Assert.That(p.X, Is.EqualTo(5));
        Assert.That(p.Y, Is.EqualTo(6));
    }

    [Test]
    public void CheckPointReturnValue()
    {
        Point p = new Point(5, 6);
        var returnValue = p.GetPoint();
        Assert.That(returnValue.Item1, Is.EqualTo(5));
        Assert.That(returnValue.Item2, Is.EqualTo(6));
    }

    [Test]
    public void CheckIfPositionAndHPMatch()
    {
        _gameController.CreateGame();
        var ships = new List<IShip>()
        {
            new Ship( EShip.Battleship ),
            new Ship(EShip.GorlockTheDestroyer),
            new Ship(EShip.OceanGate_Submarine),
            new Ship(EShip.CruiseShip)
          
        };
        
        Assert.That(_gameController.ActivePlayer.Field.Ships[0].Positions.Length, Is.EqualTo(5));
        Assert.That(_gameController.ActivePlayer.Field.Ships[1].Positions.Length, Is.EqualTo(4));
        Assert.That(_gameController.ActivePlayer.Field.Ships[2].Positions.Length, Is.EqualTo(3));
        Assert.That(_gameController.ActivePlayer.Field.Ships[3].Positions.Length, Is.EqualTo(2));
    }
    
    [Test]
    public void CheckSurrender()
    {
        _gameController.CreateGame();
        _gameController.Surrender();
        Assert.IsTrue(_gameController.GamePhase == EPhase.GameOver);
    }

    [Test]
    public void CheckDraw()
    {
        _gameController.CreateGame();
        _gameController.Draw();
        Assert.IsTrue(_gameController.GamePhase == EPhase.GameOver);
    }

    #region Wrong Tests

    [Test]
    public void CheckWrongAttack()
    {
        _gameController.StartPlacingShips();
        _gameController.StartGame();
        Assert.IsFalse(_gameController.Attack(new Point(-4,-4)));
        Assert.IsFalse(_gameController.Attack(new Point(15,4)));
        Assert.IsFalse(_gameController.Attack(new Point(4,15)));
        Assert.IsFalse(_gameController.Attack(new Point(7,-5)));
    }
    
    [Test]
    public void CheckWrongSetShips()
    {
        _gameController.CreateGame();
        var ships = new List<IShip>()
        {
            new Ship( EShip.Battleship ),
            new Ship(EShip.GorlockTheDestroyer),
            new Ship(EShip.OceanGate_Submarine),
            new Ship(EShip.CruiseShip)
          
        };
        try
        {
            _gameController.StartPlacingShips();
            Assert.Fail();
        }
        catch (Exception e)
        {
            Assert.Pass();
        }
    }
    [Test]
    public void CheckSurrenderEndGame()
    {
        _gameController.CreateGame();
        _gameController.Surrender();
        Assert.IsFalse(_gameController.GamePhase == EPhase.Playing);
    }

    [Test]
    public void CheckDrawEndGame()
    {
        _gameController.CreateGame();
        _gameController.Draw();
        Assert.IsFalse(_gameController.GamePhase == EPhase.Playing);
    }
    

    #endregion
    
    
    
    
}