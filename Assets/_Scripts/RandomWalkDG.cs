using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class RandomWalkDG : AbstractDG 
{
    [SerializeField]
    protected RandomWalkSO randomWalkParameters;

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tilemapVis.Clear();
        tilemapVis.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVis);
    }

    protected HashSet<Vector2Int> RunRandomWalk(RandomWalkSO parameters, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
            Console.WriteLine(parameters);
        {
            var path = ProGenerationAlgorithms.SimpleRandomWalk(currentPosition, parameters.walkLength);
            floorPosition.UnionWith(path);
            if (parameters.startRandomlyEachIteration)
                currentPosition = floorPosition.ElementAt(Random.Range(0, floorPosition.Count));
        }
        return floorPosition;
    }
}
