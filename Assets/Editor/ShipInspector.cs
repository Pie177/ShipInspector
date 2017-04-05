using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Ship))]
public class ShipInspector : Editor
{

    int pointPool = 80;
    Ship myTarget;
    public override void OnInspectorGUI()
    {
        

        EditorGUILayout.LabelField("Ship Stats", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Ship Stat Point Pool: " + pointPool.ToString());

        EditorGUI.BeginChangeCheck();
        myTarget.armor = EditorGUILayout.IntField("Armor", myTarget.armor);
        if (EditorGUI.EndChangeCheck())
        {
            if (myTarget.armor < 10)
            {
                myTarget.armor = 10;
            }
            if (myTarget.armor > 10 && (pointPool - myTarget.armor > -1))
            {
                pointPool = 100 - myTarget.armor - myTarget.agility - myTarget.attack;
            }
        }

        EditorGUI.BeginChangeCheck();
        myTarget.attack = EditorGUILayout.IntField("Attack", myTarget.attack);
        if (EditorGUI.EndChangeCheck())
        {
            if (myTarget.attack < 10)
            {
                myTarget.attack = 10;
            }
            if (myTarget.attack > 10 && pointPool - myTarget.attack > -1)
            {
                pointPool = 100 - myTarget.armor - myTarget.agility - myTarget.attack;
            }
        }

        EditorGUI.BeginChangeCheck();
        myTarget.agility = EditorGUILayout.IntField("Agility", myTarget.agility);
        if (EditorGUI.EndChangeCheck())
        {
            if (myTarget.agility < 10)
            {
                myTarget.agility = 10;
            }
            if (myTarget.agility > 10 && pointPool - myTarget.agility > -1)
            {
                pointPool = 100 - myTarget.armor - myTarget.agility - myTarget.attack;
            }
        }
        EditorGUILayout.Space();
        myTarget.hitPoints = EditorGUILayout.IntField("Hit Points", myTarget.hitPoints);
        EditorGUILayout.EndVertical();

    }

    private void OnEnable()
    {
        myTarget = (Ship)target;
        pointPool = 100;
        pointPool = pointPool - myTarget.armor - myTarget.agility - myTarget.attack;
    }
}
