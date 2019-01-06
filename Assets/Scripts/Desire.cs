using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс желаний агента
[Serializable]
public class Desire
{
    public string name;
    public float value;
    [SerializeField]
    private AnimationCurve myCurve;
    //public float DesireWeight { get { return myCurve.Evaluate(value); } }
    public float GetDesireWeight(float curValue)
    {
        return myCurve.Evaluate(curValue);
    }
    //public string solverIntention;
}
