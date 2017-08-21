using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StageGenerator))]
public class StageGeneratorEditor: Editor{

    public override void OnInspectorGUI(){
        DrawDefaultInspector();
        
        if(!Application.isPlaying){
            EditorGUILayout.PrefixLabel("Waiting for play mode.");
            return;
        }
        this.Repaint();
        drawList("platforms", StageGenerator.platformList);
        drawList("obstacles", StageGenerator.obstacleList);
    }

    void drawList(string type, List<GameObject> list){
        EditorGUILayout.LabelField("Current "+ type);
        EditorGUI.BeginDisabledGroup(true);
        for(int i = 0; i < list.Count; i++){
            EditorGUILayout.ObjectField(list[i], typeof(GameObject), true);
        }
         EditorGUI.EndDisabledGroup();
    }
}
