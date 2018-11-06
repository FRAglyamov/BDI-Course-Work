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
    // Можно добавить требования к знаниям в плане навыков (пр. готовка) от которых будет зависеть возможно ли действие и его результат
    //public string knowledgeAboutSmth;
    //public List<string> nextIntentionsName = new List<string>();
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