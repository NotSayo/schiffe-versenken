﻿namespace ShipDLL;

public interface IShip
{
    public int HP { get; }
    public EShip Type { get; set; }
    public bool IsAlive { get; set; }
    public Point[] Positions { get; set; }
    public int UpdateHP();
    
    public List<ShipPart> ShipParts { get; set; }
}