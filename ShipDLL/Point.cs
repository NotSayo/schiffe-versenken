namespace ShipDLL;

public class Point
{
    public EPositionStatus Status { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public ShipPart ShipPart { get; set; }

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
    
    public List<Point> CalculateBetweenPoints( Point p2)
    {
        Point p1 = this;
        List<Point> points = new List<Point>();
        if (p1.X != p2.X)
        {
            for (int i = p1.X; i <= p2.X; i++)
            {
                points.Add(new Point(i, p1.Y));
            }
        }
        if (p1.Y != p2.Y)
        {
            for (int i = p1.Y; i <= p2.Y; i++)
            {
                points.Add(new Point(p1.X, i));
            }
        }
        return points;
    }
        
    public Tuple<int, int> GetPoint() => new(X, Y);

    public int GetIndex() => Y * 10 + X;
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