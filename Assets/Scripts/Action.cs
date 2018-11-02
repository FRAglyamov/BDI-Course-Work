using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Action")]
public class Action : ScriptableObject
{
    // Какую потребность удовлетворяет и насколько
    public float getGoalChange(Goal goal)
    {
        return 0f;
    }
    // Длительность выполнения действия
    public float duration;
    // ?
    public float getDuration()
    {
        return 0f;
    }
}

/*[Serializable]
public class Action
{
    // Какую потребность удовлетворяет и насколько
    public float getGoalChange(Goal goal)
    {
        return 0f;
    }
    // Длительность выполнения действия
    public float duration;
    // ?
    public float getDuration()
    {
        return 0f;
    }
}
*/
