using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "New Smart Object Action", menuName = "Smart Object/Action")]
public class SmartObjectAction : ScriptableObject
{
    public Animation animation;
    public Action action;
    public virtual void Action()
    {

    }
}
