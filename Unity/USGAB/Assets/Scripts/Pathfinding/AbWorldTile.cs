using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AbWorldTile 
{
    // Start is called before the first frame update
    public Vector3Int LocalPlace { get; set; }

    public Vector3 WorldLocation { get; set; }

    public TileBase TileBase { get; set; }

    public Tilemap TilemapMember { get; set; }

    public string Name { get; set; }

    // Below is needed for Breadth First Searching
    public bool IsExplored { get; set; }

    public AbWorldTile ExploredFrom { get; set; }

    public int Cost { get; set; }
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public bool isWalkable;
    public AbWorldTile cameFromNode;
    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
}
