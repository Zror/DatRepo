using UnityEngine;
using System.Collections;
using UnityEditor;

/*
[CustomPropertyDrawer(typeof(WeightedTreasure))]
class WeightedTreasureEditor : PropertyDrawer
{
    /*public override void OnInspectorGUI () {
        var treasure = (WeightedTreasure)target;

        EditorGUILayout.BeginHorizontal();
        treasure.weight = EditorGUILayout.IntField(treasure.weight, GUILayout.Width(120));
        treasure.treasure = (GameObject)EditorGUILayout.ObjectField(treasure.treasure, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property != null)
        {
            var weight = property.FindPropertyRelative("weight");
            var treasure = property.FindPropertyRelative("treasure");
            EditorGUILayout.BeginHorizontal();
            if (weight != null) EditorGUILayout.PropertyField(weight, GUIContent.none, GUILayout.Width(120));
            if (treasure != null) EditorGUILayout.PropertyField(treasure, GUIContent.none);
            EditorGUILayout.EndHorizontal();
        }
    }
}
*/