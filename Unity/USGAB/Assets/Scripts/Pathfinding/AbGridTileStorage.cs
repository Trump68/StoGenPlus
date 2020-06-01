using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AbGridTileStorage : MonoBehaviour
{
    public Tilemap TilemapWalls;
    public Tilemap TilemapFloor;
    private static AbGridTileStorage instance;
    private Dictionary<Vector2Int, AbWorldTile> tiles;
    public static List<AbWorldTile> Tiles
    {
        get 
        {
            return instance.tiles.Select(x => x.Value).ToList();
        }
    }
    public static Vector3 GridPosition(Vector3 pos)
    {
        return instance.TilemapWalls.WorldToCell(pos);
    }
    public static Vector3 WorldPosition(AbWorldTile cell)
    {
        return instance.TilemapWalls.CellToWorld(new Vector3Int(cell.x, cell.y, 0));
    }

    public static AbWorldTile GetTileData(Vector3 pos)
    {
        var gridPos = instance.TilemapWalls.WorldToCell(pos);
        return GetTileData(gridPos.x, gridPos.y);
    }
    public static AbWorldTile GetTileData(int x, int y)
    {       
        AbWorldTile _tile;
        if (instance.tiles.TryGetValue(new Vector2Int(x, y), out _tile))
        {
            return _tile;
        }
        return null;
    }
    internal static int GetWidth()
    {
        return instance.TilemapWalls.cellBounds.xMax;
    }
    internal static int GetHeight()
    {
        return instance.TilemapWalls.cellBounds.yMax;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GetWorldTiles();
    }

    // Use this for initialization
    private void GetWorldTiles()
    {
        tiles = new Dictionary<Vector2Int, AbWorldTile>();
        foreach (Vector3Int pos in TilemapWalls.cellBounds.allPositionsWithin)
        {
            // var localPlace = new Vector3Int(pos.x, pos.y, pos.z);

            //if (!Tilemap.HasTile(pos)) continue;
            var tile = new AbWorldTile
            {
                LocalPlace = pos,
                WorldLocation = TilemapWalls.CellToWorld(pos),
                TileBase = TilemapWalls.GetTile(pos),
                TilemapMember = TilemapWalls,
                Name = pos.x + "," + pos.y,
                Cost = 1, // TODO: Change this with the proper cost from ruletile
                isWalkable = true,
                x= pos.x,
                y =pos.y
            };
            if (tile.TileBase != null)
            {
                var collidetype = TilemapWalls.GetColliderType(tile.LocalPlace);
                if (collidetype == Tile.ColliderType.Sprite)
                {
                    tile.isWalkable = false;
                }
                
            }
            if (tile.isWalkable && TilemapFloor != null)
            {
                var collidetype = TilemapFloor.GetColliderType(tile.LocalPlace);
                if (collidetype == Tile.ColliderType.Sprite)
                {
                    tile.isWalkable = false;
                }

            }
            tiles.Add(new Vector2Int(pos.x, pos.y), tile);
        }
    }


}
