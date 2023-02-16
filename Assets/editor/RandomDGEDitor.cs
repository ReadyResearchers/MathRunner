using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor(typeof(AbstractDungeonGenrator), true)]

public class RandomDGEditor : Editor
{
    AbstractDungeonGenerator generator;

    private void Awake()
    {
        generator = (AbstractDungeonGenerator)target;
    }

    private override void OnInspectionGUI()
    {
        base.OnInspectionGUI();
        if(GUILayout.Button("Create Dungeon"))
        {
            generator.GenerateDungon();
        }
    }
}
