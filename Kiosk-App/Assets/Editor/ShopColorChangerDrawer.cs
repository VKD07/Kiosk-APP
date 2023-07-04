using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(ShopColorChanger))]
public class ShopColorChangerDrawer : PropertyDrawer
{
    private SerializedProperty tagButton;
    private SerializedProperty shopTag;
    private SerializedProperty shopColor;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        tagButton = property.FindPropertyRelative("tagButton");
        shopTag = property.FindPropertyRelative("shopTag");
        shopColor = property.FindPropertyRelative("shopColor");
        
        Rect foldOutBox = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);
        property.isExpanded = EditorGUI.Foldout(foldOutBox, property.isExpanded, label);
        if (property.isExpanded)
        {
            DrawTagButton(position);
            DrawShoptag(position);
            DrawShopColor(position);
        }
        EditorGUI.EndProperty();
    } 

    private void DrawTagButton(Rect position)
    {
        EditorGUIUtility.labelWidth = 80;
        float xPos = position.min.x;
        float yPos = position.min.y + EditorGUIUtility.singleLineHeight;
        float width = position.size.x *.5f;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPos, yPos, width, height);
        EditorGUI.PropertyField(drawArea, tagButton, new GUIContent("Tag Button"));
    }

    private void DrawShoptag(Rect position)
    {
        Rect drawArea = new Rect(position.min.x + (position.width * 0.5f), position.min.y + EditorGUIUtility.singleLineHeight, position.size.x * .5f, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(drawArea, shopTag, new GUIContent("Tag Name:"));
    }

    private void DrawShopColor(Rect position)
    {
        Rect drawArea = new Rect(position.min.x + (position.width * .005f), position.min.y + (EditorGUIUtility.singleLineHeight * 2), position.size.x * .5f, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(drawArea, shopColor, new GUIContent("Shop Color"));
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int totalLines =1;

        if (property.isExpanded)
        {
            totalLines += 3;
        }

        return (EditorGUIUtility.singleLineHeight * totalLines);
    }
}
