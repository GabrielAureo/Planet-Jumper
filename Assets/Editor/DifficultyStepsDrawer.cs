using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RangeBoundDifficulty))]
[CustomPropertyDrawer(typeof(FloatDifficulty))]
[CustomPropertyDrawer(typeof(IntDifficulty))]
public class DifficultyStepsDrawer: PropertyDrawer{

	int lh = 18;

    SerializedProperty array;
	SerializedProperty levels;
	SerializedProperty list;

  	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
		array = property.FindPropertyRelative("steps");
		levels = property.FindPropertyRelative("levels");

		EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		EditorGUI.BeginProperty(position,label,property);
		{
			Rect scripObjRect = new Rect(position.x, position.y + lh ,position.width, lh);
			Rect listLabel = new Rect(position.x, position.y + 2*lh, position.width, lh);
			Rect ctrlAdd =  new Rect ( position.x+ 95,    position.y + 2*lh +1f,   20f,    lh-6f );
        	Rect ctrlRem =  new Rect ( position.x+ 120,    position.y + 2*lh +1f,   20f,    lh-6f );

			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 1;

			
			EditorGUI.PropertyField(scripObjRect,levels);

			if(levels != null && levels.objectReferenceValue != null ){
				SerializedObject scripObj = new SerializedObject(levels.objectReferenceValue);
				list = scripObj.FindProperty("list");

				resizeGUIArray(array, list.arraySize);
				
				EditorGUI.LabelField( listLabel, "Steps Array", EditorStyles.label );
				/*GUI.enabled = array.arraySize < list.arraySize;
				if ( GUI.Button( ctrlAdd, "+" ) ) {
					array.InsertArrayElementAtIndex( array.arraySize );
				}
				GUI.enabled = array.arraySize > 0;
				if ( GUI.Button( ctrlRem, "-" ) ) {
					array.DeleteArrayElementAtIndex( array.arraySize-1 );
				}
				GUI.enabled = true;
				*/
				EditorGUI.indentLevel++;
				DrawList(array, position);
			}
			EditorGUI.indentLevel = indent;
		}
		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label){
		if(levels == null || levels.objectReferenceValue == null){
			return lh * 2;
		}else{
			return lh * 3 + (lh * array.arraySize);
		}	
	}

	void DrawList(SerializedProperty array, Rect position){	
		for(int i =0; i < array.arraySize; i++){
			Rect itemRect = new Rect(position.x, position.y + 3*lh + (i * lh), position.width, lh);
			EditorGUI.PropertyField(itemRect, array.GetArrayElementAtIndex(i),new GUIContent("Step " + i));
			
		}
		
		
	}

	void resizeGUIArray(SerializedProperty array, int newSize){
		if(array.arraySize > newSize){
			for(int i = newSize; i < array.arraySize; i++){
				array.DeleteArrayElementAtIndex(i);
			}
		}else if(array.arraySize < newSize){
			for(int i = array.arraySize; i < newSize; i++){
				array.InsertArrayElementAtIndex(i);
			}
		}
	}
}
