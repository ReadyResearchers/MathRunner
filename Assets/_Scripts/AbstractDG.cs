using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDG : MonoBehaviour
{
    [SerializeField]
    protected TileMapVis tilemapVis = null;
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    public void GenerateDungeon()
    {
        tilemapVis.Clear();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
