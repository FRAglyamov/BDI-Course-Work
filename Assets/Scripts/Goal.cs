using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс цели
[Serializable]
public class Goal // =Desire?
{
    public string name;
    public float value;
    // Вычисление недовольства
    public float getDiscontentment(float newValue)
    {
        return newValue * newValue;
    }
}