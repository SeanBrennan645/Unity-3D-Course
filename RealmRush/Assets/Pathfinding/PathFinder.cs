using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }

    void Start()
    {
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        List<Node> neightbours = new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = currentSearchNode.coordinates + direction;

            if(grid.ContainsKey(neighbourCoords))
            {
                neightbours.Add(grid[neighbourCoords]);

                //DELETE after testing
                grid[neighbourCoords].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
