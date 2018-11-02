using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(SmartObject))]
public class SmartObjectEditor : Editor {

    UnityEditorInternal.ReorderableList actionList;

    private void OnEnable()
    {
        if(target==null)
        {
            return;
        }
        actionList = new ReorderableList(serializedObject, serializedObject.FindProperty("actions"), true, true, true, true);
        actionList.drawElementCallback += (rect, index, active, focused) =>
        {
            var element = actionList.serializedProperty.GetArrayElementAtIndex(index);
            rect.height = 16;
            rect.y += 2;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUI.GetPropertyHeight(element)), element, GUIContent.none);
        };
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();
        //actionList.DoLayoutList();


        EditorGUI.BeginChangeCheck();
        serializedObject.Update();
        actionList.DoLayoutList();
        EditorUtility.SetDirty(target);
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}
