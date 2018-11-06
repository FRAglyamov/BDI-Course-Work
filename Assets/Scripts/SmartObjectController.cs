using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RotaryHeart.Lib.SerializableDictionary;
using System;

[Serializable]
public class DictionaryStringToInt : SerializableDictionaryBase<string, int> { }

public class SmartObjectController : MonoBehaviour {

    public  GameObject player;
    public SmartObject smartObject;
    public DictionaryStringToInt neededItems = new DictionaryStringToInt();
    public Transform objectInteractionPlace;

    void Start ()
    {
        objectInteractionPlace = gameObject.GetComponentInChildren<Transform>();
    }
	

	void Update ()
    {
		if(smartObject.playerInteractWithObject==true)
        {
            smartObject.actions[0].DoAction(player);
            //smartObject.scripts[0].GetClass().GetMethod("DoAction");
            smartObject.playerInteractWithObject = false;
        }
	}
}
