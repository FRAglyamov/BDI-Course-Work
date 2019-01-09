using RotaryHeart.Lib.SerializableDictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Events;


[Serializable]
public class DictionaryStringToFloat : SerializableDictionaryBase<string, float> { }

[CreateAssetMenu(fileName = "New Smart Object", menuName = "Smart Object/Smart Object")]
public class SmartObject : ScriptableObject
{
    /*
    Graphics/animation
    State
    Scripts
    Advertising (what can it offer to the agent ?)
    */

    public DictionaryStringToFloat desireChanged = new DictionaryStringToFloat();

    //public bool playerInteractWithObject = false;

    //public Transform objectInteractionPlace;
    //public UnityEditorInternal.ReorderableList list;
    public List<SmartObjectAction> actions;
}


