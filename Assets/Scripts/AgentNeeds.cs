using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
