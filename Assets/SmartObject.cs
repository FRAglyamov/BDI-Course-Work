using RotaryHeart.Lib.SerializableDictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class DictionaryStringToFloat : SerializableDictionaryBase<string, float> { }

public class SmartObject : MonoBehaviour
{
    // У Smart object должны быть действия и изменения характеристик
    // Активируется с помощью игрока

    public DictionaryStringToFloat goalChanged = new DictionaryStringToFloat();
    public bool playerInteractWithObject = false;
    public GameObject agent;

    public void InteractWithObject(GameObject agent)
    {
        playerInteractWithObject = true;
        this.agent = agent;
    }


    // Нужно ли ?
    void Start()
    {

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


