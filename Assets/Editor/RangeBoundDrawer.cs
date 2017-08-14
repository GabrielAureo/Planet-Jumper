using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RangeBound))]
public class RangeBoundDrawer:PropertyDrawer{

   public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {           
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var minRect = new Rect(position.x, position.y, position.width/2, position.height);
        var maxRect = new Rect(minRect.xMax, position.y, position.width/2, position.height);

        SerializedProperty min = property.FindPropertyRelative("min");
        SerializedProperty max = property.FindPropertyRelative("max");
    
        EditorGUI.PropertyField(minRect, property.FindPropertyRelative("min"), GUIContent.none);
        EditorGUI.PropertyField(maxRect, property.FindPropertyRelative("max"), GUIContent.none);
        if(max.intValue < min.intValue){
            max.intValue = min.intValue;
        } 

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}