using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNeeds : MonoBehaviour {

    public float hunger = 0f;
    public float energy = 0f;
    public float comfort = 0f;
    public float hygiene = 0f;
    public float fun = 0f;
    public float overall = 0f;

    public Transform fridge;
    public Transform apple;
    public Transform toilet;
    public Transform sofa;

    public float walkSpeed;

    public bool nearApple;

    NavMeshAgent navAgent;

    void Start () {
        hunger = 100f;
        energy = 100f;
        comfort = 100f;
        hygiene = 100f;
        fun = 100f;
        navAgent = GetComponent<NavMeshAgent>();
    }
	
	void Update () {
        overall = (hunger + energy + comfort + hygiene + fun) / 5;
        hunger -= Time.deltaTime / 9;
        energy -= Time.deltaTime / 20;
        comfort -= Time.deltaTime / 15;
        hygiene -= Time.deltaTime / 11;
        fun -= Time.deltaTime / 12;
        Hungry();
    }

    void Hungry()
    {
        navAgent.SetDestination(apple.position);
        if(nearApple==true)
        {
            EatApple();
        }
        else
        {

        }
    }

    private void EatApple()
    {
        GameObject apple = GameObject.Find("Apple");
        hunger += 10f;
        Destroy(apple);
    }
}
