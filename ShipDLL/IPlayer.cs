using System.Runtime.CompilerServices;

namespace ShipDLL;

public interface IPlayer
{
    public int ID { get; set; }
    
    public IField Field { get; set; }
    public IField EnemyField { get; set; }
    public void CreateField();
    public bool HasMoved { get; set; }
    public void CreateEnemyField(IPlayer player);
    public bool Attack(Point point);
}