using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PrefabManager))]
public class PrefabManagerEditor : Editor{
    PrefabManager manager;
    GameObject value;
    string key;


    public override void OnInspectorGUI(){
        manager = (PrefabManager) target;

        
        DrawDictionary(manager.obstacles, "Obstacles");
    }

    void DrawDictionary(Dictionary<string,GameObject> dict, string dictType){
        List<string> keys = new List<string>();
        try{
           keys = new List<string> (dict.Keys);
        }catch(NullReferenceException){
            dict = new Dictionary<string, GameObject>();
            keys = new List<string> (dict.Keys);
        }

        EditorGUILayout.LabelField(dictType + " Dictionary");
        EditorGUILayout.LabelField("Add " + dictType);
        AddSlot(manager.obstacles);
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField("Prefabs");
            EditorGUILayout.LabelField("Key");
        }
        EditorGUILayout.EndHorizontal();

        foreach(var key in keys){
            
            DrawSlot(dict, key);
            
        }
        
    }

    void DrawSlot(Dictionary<string,GameObject> dict, string key){
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUI.BeginDisabledGroup (true);
            {            
                EditorGUILayout.ObjectField(dict[key], typeof(GameObject), false);
                EditorGUILayout.TextField(key);
            }
            EditorGUI.EndDisabledGroup ();
            if(GUILayout.Button("X")){
                manager.Delete(dict,key);
                EditorUtility.SetDirty(target);
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    void AddSlot(Dictionary<string,GameObject> dict){
        EditorGUILayout.BeginHorizontal();
            value = (GameObject)EditorGUILayout.ObjectField(value, typeof(GameObject), false);
            key = EditorGUILayout.TextField(key);
            if(GUILayout.Button("Add")){
                try{
                    manager.Add(dict,key,value);
                    
                }catch(ArgumentException){
                    Debug.LogError("Elemento já existe, vacilão");
                }
                value = null;
                key = null;

                EditorUtility.SetDirty(target);
            }
        EditorGUILayout.EndHorizontal();
    }
}