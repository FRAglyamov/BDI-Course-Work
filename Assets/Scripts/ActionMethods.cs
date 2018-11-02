using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionMethods : MonoBehaviour {

    public UnityEvent myUnityEvent;
    void Awake()
    {
        if (myUnityEvent == null)
            myUnityEvent = new UnityEvent();
    }
    public void GoTo()
    {
        myUnityEvent.Invoke();
    }
}
