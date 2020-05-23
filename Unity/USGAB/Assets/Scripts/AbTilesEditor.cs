using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AbTilesEditor : MonoBehaviour
{
    //private AbWorldTile _tile;
    void Start()
    {
        //foreach (var pathNode in AbGridTileStorage.Tiles)
        //{
        //  if (!pathNode.isWalkable)
        //    {
        //        pathNode.TilemapMember.SetTileFlags(pathNode.LocalPlace, TileFlags.None);
        //        pathNode.TilemapMember.SetColor(pathNode.LocalPlace, Color.green);
        //    }
        //}
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var _tile = AbGridTileStorage.GetTileData(point);
            if (_tile != null)
            {
                string w = " -walkable";
                if (!_tile.isWalkable)
                {
                    w = " -not walkable";
                }
                print($"Tile {_tile.Name} costs: {_tile.Cost}{w}");
               
                //if (_tile.TileBase != null)
                //{
                //    _tile.TilemapMember.SetTileFlags(_tile.LocalPlace, TileFlags.None);
                //    _tile.TilemapMember.SetColor(_tile.LocalPlace, Color.green);
                //    _tile.isWalkable = false;
                //}
            }
        }
    }
}
