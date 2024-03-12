namespace ShipDLL;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Tuple<int, int> GetPoint()
    {
        return new Tuple<int, int>(X, Y);
    }
}