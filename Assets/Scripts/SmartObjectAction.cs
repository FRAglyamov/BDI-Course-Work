using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName = "New Smart Object Action", menuName = "Smart Object/Action")]
public abstract class SmartObjectAction : ScriptableObject
{
    [SerializeField]
    public DictionaryStringToFloat desireChanged;
    public AnimationClip animClip;
    public abstract void DoAction(GameObject player, GameObject smartGO);

}
