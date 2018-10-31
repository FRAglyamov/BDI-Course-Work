using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSmartObject : SmartObject
{
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
