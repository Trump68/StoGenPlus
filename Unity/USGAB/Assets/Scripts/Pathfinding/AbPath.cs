using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AbPath 
{

    //[SerializeField] public Tilemap tilemap;
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    public static List<Vector3> FindPath(Vector3 startWorldPosition, Vector3 endWorldPosition)
    {

        List<AbWorldTile> path = FindPathData(startWorldPosition, endWorldPosition);
        return FindPath(path);
    }
    public static List<Vector3> FindPath(Vector3 startWorldPosition, Vector2Int endWorldPosition)
    {
        List<AbWorldTile> path = FindPathData(startWorldPosition, endWorldPosition);
        return FindPath(path);
    }
    private static List<Vector3> FindPath(List<AbWorldTile> path)
    {
        if (path != null)
        {
            List<Vector3> vectorPath = new List<Vector3>();
            foreach (AbWorldTile pathNode in path)
            {
                //vectorPath.Add(
                //new Vector3(pathNode.x, pathNode.y) * grid.GetCellSize() + Vector3.one * grid.GetCellSize() * .5f);
                //new Vector3(pathNode.x, pathNode.y) + Vector3.one * .5f);
                vectorPath.Add(AbGridTileStorage.WorldPosition(pathNode));
            }
            return vectorPath;
        }
        return null;
    }
    private static List<AbWorldTile> FindPathData(Vector3 startWorldPosition, Vector3 endWorldPosition)
    {
        AbWorldTile startNode = AbGridTileStorage.GetTileData(startWorldPosition);//GetGridObject(startX, startY);
        AbWorldTile endNode = AbGridTileStorage.GetTileData(endWorldPosition);
        return FindPathData(startNode, endNode);
    }
    private static List<AbWorldTile> FindPathData(Vector3 startWorldPosition, Vector2Int endWorldPosition)
    {
        AbWorldTile startNode = AbGridTileStorage.GetTileData(startWorldPosition);//GetGridObject(startX, startY);
        AbWorldTile endNode = AbGridTileStorage.GetTileData(endWorldPosition.x, endWorldPosition.y);
        return FindPathData(startNode, endNode);
    }
    private static List<AbWorldTile> FindPathData( AbWorldTile startNode, AbWorldTile endNode)
    {

        if (startNode == null || endNode == null)
        {
            // Invalid Path
            return null;
        }

        var openList = new List<AbWorldTile> { startNode };
        var closedList = new List<AbWorldTile>();

        foreach (var pathNode in AbGridTileStorage.Tiles)
        {
            pathNode.gCost = 99999999;
            pathNode.CalculateFCost();
            pathNode.cameFromNode = null;
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            AbWorldTile currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                // Reached final node
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            var nn = GetNeighbourList(currentNode);
            foreach (AbWorldTile neighbourNode in nn)
            {
                if (closedList.Contains(neighbourNode)) continue;
                if (!neighbourNode.isWalkable)
                {
                    closedList.Add(neighbourNode);
                    continue;
                }

                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }

        // Out of nodes on the openList
        return null;
    }
    private static int CalculateDistanceCost(AbWorldTile a, AbWorldTile b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        //return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
        return MOVE_STRAIGHT_COST * remaining;
    }
    private static AbWorldTile GetLowestFCostNode(List<AbWorldTile> pathNodeList)
    {
        AbWorldTile lowestFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++)
        {
            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = pathNodeList[i];
            }
        }
        return lowestFCostNode;
    }
    private static List<AbWorldTile> CalculatePath(AbWorldTile endNode)
    {
        List<AbWorldTile> path = new List<AbWorldTile>();
        path.Add(endNode);
        AbWorldTile currentNode = endNode;
        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        path.Reverse();
        return path;
    }
    private static List<AbWorldTile> GetNeighbourList(AbWorldTile currentNode)
    {
        List<AbWorldTile> neighbourList = new List<AbWorldTile>();
        AbWorldTile node = null;
        //if (currentNode.x - 1 >= 0)
        //{
        // Left
        node = GetNode(currentNode.x - 1, currentNode.y);
        if (node != null) neighbourList.Add(node);
        // Left Down
        //if (currentNode.y - 1 >= 0)
        //neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
        // Left Up
        //if (currentNode.y + 1 < AbGridTileStorage.GetHeight())
        //neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
        //}
        //if (currentNode.x + 1 < AbGridTileStorage.GetWidth())
        //{
        // Right
        node = GetNode(currentNode.x + 1, currentNode.y);
        if (node != null) neighbourList.Add(node);

        // Right Down
        //if (currentNode.y - 1 >= 0)
        //neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
        // Right Up
        //if (currentNode.y + 1 < AbGridTileStorage.GetHeight())
        //neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
        //}
        // Down
        //if (currentNode.y - 1 >= 0)
        node = GetNode(currentNode.x, currentNode.y - 1);
        if (node != null) neighbourList.Add(node);
        // Up
        //if (currentNode.y + 1 < AbGridTileStorage.GetHeight())
        node = GetNode(currentNode.x, currentNode.y + 1);
        if (node != null) neighbourList.Add(node);

        return neighbourList;
    }
    public static AbWorldTile GetNode(int x, int y)
    {
        return AbGridTileStorage.GetTileData(x, y);
    }
}
