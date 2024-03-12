using System.Runtime.CompilerServices;

namespace ShipDLL;

public interface IPlayer
{
    public int ID { get; set; }
    
    public IField Field { get; set; }
    public IField EnemyField { get; set; }
    public void CreateField();
    public void CreateEnemyField(IPlayer player);
    public void Attack(Point point);
}