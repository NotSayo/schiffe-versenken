namespace ShipDLL;


//TODO Add SetHasShip method



public class Point
{
    public EPositionStatus Status { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool HasShip { get; set; }

    public Point() {}

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public double CalculateDistance(Point point)
    {
        
        return Math.Sqrt(Math.Pow(X+ - (point.X +1), 2) + Math.Pow(Y - point.Y, 2));
    } 
        
    public Tuple<int, int> GetPoint()
    {
        return new Tuple<int, int>(X, Y);
    }

    public override string ToString()
    {
        return $"({Y}, {X})";
    }

    public override bool Equals(object? obj)
    {
        var p = obj as Point;
        return X == p.X && Y == p.Y;
    }
    
}