using RotaryHeart.Lib.SerializableDictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditorInternal;
using UnityEngine.Events;


[Serializable]
public class DictionaryStringToFloat : SerializableDictionaryBase<string, float> { }

[CreateAssetMenu(fileName = "New Smart Object", menuName = "Smart Object/Smart Object")]
public class SmartObject : ScriptableObject
{
    // У Smart object должны быть действия и изменения характеристик
    // Активируется с помощью игрока

    /*
    Graphics/animation
    State
    Scripts
    Advertising (what can it offer to the agent ?)
    */

    public DictionaryStringToFloat goalChanged = new DictionaryStringToFloat();
    public bool playerInteractWithObject = false;
    public GameObject agent;
    public Transform objectInteractionPlace;
    public UnityEditorInternal.ReorderableList list;
    [HideInInspector]
    public List<SmartObjectAction> actions = new List<SmartObjectAction>();

    public UnityEvent myUnityEvent;

    public void InteractWithObject(GameObject agent)
    {
        playerInteractWithObject = true;
        this.agent = agent;
    }

    void Awake()
    {
        if (myUnityEvent == null)
            myUnityEvent = new UnityEvent();
    }

    // Нужно ли ?
    void Start()
    {
        if(myUnityEvent == null)
             myUnityEvent = new UnityEvent();
    }

    void Update()
    {
        if (playerInteractWithObject == true)
        {
            // Выполнение действия
            // Передача изменений характеристик и необходимых анимаций и данных
            playerInteractWithObject = false;
        }
    }
}


