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
    public string solverIntention;

    [HideInInspector]
    public AgentNeeds agent;
    public void Initialize(AgentNeeds agent)
    {
        this.agent = agent;
    }

    //public Queue<ExecutingIntention> GetSolution()
    //{
    //    Intention solver = agent.GetIntention(solverIntention);
    //    int cost = 0;
    //    var solution = solver.CalculateCost(cost);
    //    if (solution == null)
    //    {
    //        return null;
    //    }
    //    else
    //    {
    //        return new Queue<ExecutingIntention>(solution);
    //    }
    //}
}
