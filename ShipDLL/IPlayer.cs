using System.Runtime.CompilerServices;

namespace ShipDLL;

public interface IPlayer
{
    public int ID { get; set; }
    public bool HasWon { get; set; }
    public List<IShip> UnplacedShips { get; set; }
    public bool AcceptDraw { get; set; }
    public IField Field { get; set; }
    public IField EnemyField { get; set; }
    public void CreateField();
    public bool HasMoved { get; set; }
    public bool Attack(Point point);
    public bool SetShip(IShip ship, List<Point> points);
}