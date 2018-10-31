using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// Класс желаний агента
[Serializable]
public class Desire
{
    public string name;
    public float value;
    public string solverIntention;

    [HideInInspector]
    public AgentNeeds agent;
    public void Initialize(AgentNeeds agent)
    {
        this.agent = agent;
    }

    public Queue<ExecutingIntention> GetSolution()
    {
        Intention solver = agent.GetIntention(solverIntention);
        int cost = 0;
        var solution = solver.CalculateCost(cost);
        if (solution == null)
        {
            return null;
        } else
        {
            return new Queue<ExecutingIntention>(solution);
        }
    }
}


// Класс намерений агента
[Serializable]
public class Intention
{
    public string name;
    public IntentionPrimitiveTypeAction primitiveAction;
    public string knowledgeAboutSmth;
    //public List<ExecutingIntention> nextIntentions;
    public List<string> nextIntentionsName = new List<string>();
    public Func<float> calculateCostFunc;


    [HideInInspector]
    public AgentNeeds agent;
    public void Initialize(AgentNeeds agent)
    {
        this.agent = agent;
    }
    public Stack<ExecutingIntention> CalculateCost(int cost)
    {
        int baseCost = 0;
        ExecutingIntention thisExecution;
        return null;
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

public class AgentNeeds : MonoBehaviour
{    
    [SerializeField]
    public Dictionary<string, int> items = new Dictionary<string, int>();
    public List<Desire> desires = new List<Desire>();
    public List<Intention> intentions = new List<Intention>();

    NavMeshAgent navAgent;

    void Start () {
        navAgent = GetComponent<NavMeshAgent>();
    }
	
	void Update ()
    {

        foreach (var desire in desires)
        {
            DescendByTime(desire.value, 10);
        }
    }

    public void DescendByTime(float desire, float descending)
    {
        desire = desire / descending * Time.deltaTime;
    }

    public void EatApple()
    {
        // Go to apple
        // Eat apple
        // +Satiety
    }
    public Intention GetIntention(string intentionName)
    {
        return intentions.Find(intention => intention.name.Equals(intentionName));
    }
}

//[Serializable]
//public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
//{
//    [SerializeField]
//    private List<TKey> keys = new List<TKey>();

//    [SerializeField]
//    private List<TValue> values = new List<TValue>();

//    // save the dictionary to lists
//    public void OnBeforeSerialize()
//    {
//        keys.Clear();
//        values.Clear();
//        foreach (KeyValuePair<TKey, TValue> pair in this)
//        {
//            keys.Add(pair.Key);
//            values.Add(pair.Value);
//        }
//    }

//    // load dictionary from lists
//    public void OnAfterDeserialize()
//    {
//        this.Clear();

//        if (keys.Count != values.Count)
//            throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

//        for (int i = 0; i < keys.Count; i++)
//            this.Add(keys[i], values[i]);
//    }
//}
//[Serializable]
//public class DictionaryOfStringAndInt : SerializableDictionary<string, int> { }