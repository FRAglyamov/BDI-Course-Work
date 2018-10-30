using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomPropertyDrawer(typeof(Intention))]
public class IntentionDrawer : PropertyDrawer {
    /*
    private SerializedProperty prop_name;
    private SerializedProperty prop_nextIntentionsIDs;
    private SerializedProperty prop_primitiveAction;
    private SerializedProperty prop_knowledgeLabel;
    private SerializedProperty prop_agent;
    private int selectedStat;
    private SerializedProperty _lastUpdatedProp;

    private void Initialize(SerializedProperty property)
    {
        if (_lastUpdatedProp != property)
        {
            prop_name = property.FindPropertyRelative("name");
            prop_nextIntentionsIDs = property.FindPropertyRelative("nextIntentionsIDs");
            prop_primitiveAction = property.FindPropertyRelative("primitiveAction");
            prop_knowledgeLabel = property.FindPropertyRelative("knowledgeLabel");
            prop_agent = property.FindPropertyRelative("agent");
            _lastUpdatedProp = property;
        }
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Initialize(property);
        UnityBDIAgent agent = prop_agent.objectReferenceValue as UnityBDIAgent;
        EditorGUI.indentLevel = 0;
        // Box coloring by id key
        GUI.color = Utilities.GetColorForString(prop_name.stringValue);
        GUI.Box(new Rect(position.x, position.y, position.width, GetPropertyHeight(property, GUIContent.none)), GUIContent.none);
        position.x += 4f;
        position.width -= 8f;
        position.y += 4f;
        GUI.color = new Color(GUI.color.r * 0.1f + 0.9f, GUI.color.g * 0.1f + 0.9f, GUI.color.b * 0.1f + 0.9f);
        position = UnityBDIEditorUtilities.DrawProperty(position, prop_name);
        position = UnityBDIEditorUtilities.DrawProperty(position, prop_primitiveAction);
        position = UnityBDIEditorUtilities.DrawProperty(position, prop_knowledgeLabel);
        List<string> intentionNames = new List<string>();
        List<Intention> intentions = agent.intentions;

        for (int i = 0; i < intentions.Count; i++)
        {
            intentionNames.Add(intentions[i].name);
        }
        ReorderableList list;
        list = new ReorderableList(property.serializedObject, prop_nextIntentionsIDs, true, true, true, true);
        list.drawHeaderCallback += rect => GUI.Label(rect, label);
        list.drawElementCallback += (rect, index, active, focused) =>
        {
            rect.height = 16; rect.y += 2; int selectedIntention = intentionNames.FindIndex(s => s.Equals(prop_nextIntentionsIDs.GetArrayElementAtIndex(index).stringValue)); if (selectedIntention < 0) { selectedIntention = 0; }
            selectedIntention = EditorGUI.Popup(rect, selectedIntention, intentionNames.ToArray());
            prop_nextIntentionsIDs.GetArrayElementAtIndex(index).stringValue = intentions[selectedIntention].name;
        };
        list.DoList(position);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        Initialize(property);
        return EditorGUI.GetPropertyHeight(prop_name) + 
            EditorGUI.GetPropertyHeight(prop_primitiveAction) + 
            EditorGUI.GetPropertyHeight(prop_knowledgeLabel) + 
            (prop_nextIntentionsIDs.arraySize * 20f) 
            + 3 * 4f + 62f;
    }
    */
}