using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShopTagsManager))]
public class ShopColorChangerEditor : Editor
{
    private SerializedProperty shopColorChanger;

    private void OnEnable()
    {
        shopColorChanger = serializedObject.FindProperty("shopColorChanger");
    }
    public override void OnInspectorGUI()
    {
       // EditorGUILayout.PropertyField(shopColorChanger, new GUIContent("Shop Tag"));
        base.OnInspectorGUI();
    }
}
