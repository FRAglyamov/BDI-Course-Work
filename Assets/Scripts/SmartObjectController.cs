using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RotaryHeart.Lib.SerializableDictionary;
using System;

[Serializable]
public class DictionaryStringToInt : SerializableDictionaryBase<string, int> { }

public class SmartObjectController : MonoBehaviour
{

    public GameObject player;
    public SmartObject smartObject;
    //public DictionaryStringToInt neededItems = new DictionaryStringToInt();
    public Transform objectInteractionPlace;
    public bool isPlayerInteractWithObject = false;
    //public DictionaryStringToFloat desireChanged;

    void Start()
    {
        objectInteractionPlace = transform.Find("Interaction Place");
        //Debug.Log("Interaction Place = " + objectInteractionPlace.name + ", Parent = " + objectInteractionPlace.parent.name + ", Position" + objectInteractionPlace.position);
        CalculateAllActionChanges();
    }

    void Update()
    {
        if (isPlayerInteractWithObject == true && player != null)
        {
            //player.GetComponent<AgentController>().isWorking = true;
            smartObject.actions[0].DoAction(player, this.gameObject);
            //smartObject.playerInteractWithObject = false;
            //player.GetComponent<AgentController>().isWorking = false;
        }
    }

    void CalculateAllActionChanges()
    {
        smartObject.desireChanged.Clear();
        foreach (var action in smartObject.actions)
        {
            foreach (var desire in action.desireChanged)
            {
                if (smartObject.desireChanged.ContainsKey(desire.Key))
                {
                    smartObject.desireChanged[desire.Key] += desire.Value;
                }
                else
                {
                    smartObject.desireChanged.Add(desire.Key, desire.Value);
                }
            }
        }
    }
}
