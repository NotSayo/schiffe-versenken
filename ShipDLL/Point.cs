﻿namespace ShipDLL;


//TODO Add SetHasShip method



public class Point
{
    public EPositionStatus Status { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool HasShip { get; set; }
    public Tuple<int, int> GetPoint()
    {
        return new Tuple<int, int>(X, Y);
    }
    
}