using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Ship))]
public class ShipInspector : Editor
{
    int id = 0;
    string[] selection = {"Ship", "Crew"};
    int pointPool = 80;
    Ship myTarget;
    public override void OnInspectorGUI()
    {

        id = GUILayout.SelectionGrid(id, selection, 2);
        if(id == 0)
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
                    pointPool = 100 - myTarget.armor - myTarget.agility - myTarget.attack;
                }
                if (myTarget.armor > 10 && (100 - myTarget.armor - myTarget.agility - myTarget.attack > -1))
                {
                    pointPool = 100 - myTarget.armor - myTarget.agility - myTarget.attack;
                }
                if(100 - myTarget.armor - myTarget.agility - myTarget.attack < 0)
                {
                    myTarget.armor = 100 - myTarget.attack - myTarget.agility;
                }
            }

            EditorGUI.BeginChangeCheck();
            myTarget.attack = EditorGUILayout.IntField("Attack", myTarget.attack);
            if (EditorGUI.EndChangeCheck())
            {
                if (myTarget.attack < 10)
                {
                    myTarget.attack = 10;
                    pointPool = 100 - myTarget.armor - myTarget.agility - myTarget.attack;
                }
                if (myTarget.attack > 10 && pointPool - myTarget.attack > -1)
                {
                    pointPool = 100 - myTarget.armor - myTarget.agility - myTarget.attack;
                }
                if (100 - myTarget.armor - myTarget.agility - myTarget.attack < 0)
                    {
                        myTarget.attack = 100 - myTarget.armor - myTarget.agility;
                    }
            }

            EditorGUI.BeginChangeCheck();
            myTarget.agility = EditorGUILayout.IntField("Agility", myTarget.agility);
            if (EditorGUI.EndChangeCheck())
            {
                if (myTarget.agility < 10)
                {
                    myTarget.agility = 10;
                    pointPool = 100 - myTarget.armor - myTarget.agility - myTarget.attack;
                }
                if (myTarget.agility > 10 && pointPool - myTarget.agility > -1)
                {
                    pointPool = 100 - myTarget.armor - myTarget.agility - myTarget.attack;
                }
                if (100 - myTarget.armor - myTarget.agility - myTarget.attack < 0)
                {
                    myTarget.agility = 100 - myTarget.armor - myTarget.attack; 
                }
            }
            EditorGUILayout.Space();
            myTarget.hitPoints = EditorGUILayout.IntField("Hit Points", myTarget.hitPoints);

            serializedObject.Update();
            SerializedProperty myGuns = serializedObject.FindProperty("shipGuns");
            EditorGUILayout.PropertyField(myGuns, true);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndVertical();
        }

        if(id == 1)
        {
            EditorGUILayout.LabelField("Crew Stats", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("box");
            serializedObject.Update();
            SerializedProperty myCrew = serializedObject.FindProperty("crewMembers");
            EditorGUILayout.PropertyField(myCrew, true);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndVertical();
        }
    }

    private void OnEnable()
    {
        myTarget = (Ship)target;
        pointPool = 100;
        pointPool = pointPool - myTarget.armor - myTarget.agility - myTarget.attack;
    }
}
