using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(AbstractDG), true)]

public class DungeonEditor : Editor
{
    AbstractDG generator;

    private void Awake()
    {
        generator = (AbstractDG)target;
    }

    public override void OnInspectionGUI()
    {
        base.OnInspectionGUI();
        if (GUILayout.Button("Create Dungeon"))
        {
            generator.GenerateDungeon();
        }
    }
}
