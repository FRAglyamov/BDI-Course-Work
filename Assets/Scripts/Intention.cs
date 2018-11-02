using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс намерений агента
[Serializable]
public class Intention
{
    public string name;
    public IntentionPrimitiveTypeAction primitiveAction;
    public string knowledgeAboutSmth;
    public List<string> nextIntentionsName = new List<string>();


    [HideInInspector]
    public AgentNeeds agent;
    public void Initialize(AgentNeeds agent)
    {
        this.agent = agent;
    }
}
// Класс исполняемых намерений ?
[Serializable]
public struct ExecutingIntention
{
    public Intention intentionBase;
    public Transform goToObject;
    public ExecutingIntention(Intention intentionBase)
    {
        this.intentionBase = intentionBase;
        this.goToObject = null;
    }
    public ExecutingIntention(Intention intentionBase, Transform goToObject)
    {
        this.intentionBase = intentionBase;
        this.goToObject = goToObject;
    }
}
// Класс базовых действий для намерений
public enum IntentionPrimitiveTypeAction : byte
{
    None,
    GoTo,
    TakeItem,
    Exchange,
    UseSmartObject
}