using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class RandomWalkDungeonGenerator : AbstractDG 
{

    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;


    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPosition = RunRandomWalk();
        tilemapVis.Clear();
        tilemapVis.PaintFloorTiles(floorPosition);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = ProGenerationAlgoithms.SimpleRandomWalk(currentPosition, walkLength);
            floorPosition.UnionWith(path);
            if (startRandomlyEachIteration)
                currentPosition = floorPosition.ElementAt(Random.Range(0, floorPosition.Count));
        }
        return floorPosition;
    }
}
