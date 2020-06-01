using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationCell 
{
    public LocationCell(string name, LocationCell owner)
    {
        this.Name = name;
        Owner = owner;
    }
    public string Name { set; get; }
    public LocationCell Owner;
    public List<CellEntrance> Entrances = new List<CellEntrance>();
    public List<LocationCell> Cells = new List<LocationCell>();
}

public class CellEntrance
{
    public CellEntrance(int x1, int y1, LocationCell cell) :
        this(new Vector2Int(x1, y1), cell)
    { }

    public CellEntrance(Vector2Int entrance, LocationCell cell)
    {
        Entrance = entrance;
        Cell = cell;
    }
    public Vector2Int Entrance;
    public LocationCell Cell;
}

public static class CellStorage
{
    public static List<LocationCell> Cells = new List<LocationCell>();
    static CellStorage()
    {
        Cells.Add(CellStorage.Home001);
    }

    private static LocationCell _Home001;
    public static LocationCell Home001 
    {
        get
        {
            if (_Home001 == null)
            {
                _Home001 = new LocationCell("Home 001", null);

                var hall = new LocationCell("Hall", _Home001);
                var livingroom = new LocationCell("Livingroom", _Home001);
                var bedroom = new LocationCell("Bedroom", _Home001);
                var toilet = new LocationCell("Toilet", _Home001);
                var bathroom = new LocationCell("Bathroom", _Home001);
                var kitchen = new LocationCell("Kitchen", _Home001);
                var storeroom = new LocationCell("Storeroom", _Home001);
                var stair = new LocationCell("Stair", _Home001);

                hall.Entrances.Add(new CellEntrance(8, 0, _Home001));
                hall.Entrances.Add(new CellEntrance(13, 2, livingroom));
                hall.Entrances.Add(new CellEntrance(11, 2, toilet));
                hall.Entrances.Add(new CellEntrance(9, 6, bathroom));
                hall.Entrances.Add(new CellEntrance(7, 6, kitchen));
                hall.Entrances.Add(new CellEntrance(5, 2, stair));
                hall.Entrances.Add(new CellEntrance(3, 2, storeroom));
                livingroom.Entrances.Add(new CellEntrance(21, 4, bedroom));
                livingroom.Entrances.Add(new CellEntrance(13, 4, hall));
                bedroom.Entrances.Add(new CellEntrance(21, 2, livingroom));
                toilet.Entrances.Add(new CellEntrance(11, 4, hall));
                bathroom.Entrances.Add(new CellEntrance(9, 8, hall));
                kitchen.Entrances.Add(new CellEntrance(7, 8, hall));
                stair.Entrances.Add(new CellEntrance(5, 4, hall));
                storeroom.Entrances.Add(new CellEntrance(3, 4, hall));
            }
            return _Home001;
        }
    }
}
