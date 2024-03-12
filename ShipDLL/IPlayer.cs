using System.Runtime.CompilerServices;

namespace ShipDLL;

public interface IPlayer
{
    public int ID { get; set; }
    
    public IField Field { get; set; }
}