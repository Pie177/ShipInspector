using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Ship))]
public class ShipInspector : Editor
{

    private int pointPool = 100;

    public override void OnInspectorGUI()
    {
        Ship myTarget = (Ship)target;

        EditorGUILayout.LabelField("Ship Stats", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        myTarget.armor = EditorGUILayout.IntField("Armor", myTarget.armor);
        if (myTarget.armor < 10)
            myTarget.armor = 10;

        myTarget.attack = EditorGUILayout.IntField("Attack", myTarget.attack);
        if (myTarget.attack < 10)
            myTarget.attack = 10;

        myTarget.agility = EditorGUILayout.IntField("Agility", myTarget.agility);
        if (myTarget.agility < 10)
            myTarget.agility = 10;

        EditorGUILayout.EndVertical();
    }
}
