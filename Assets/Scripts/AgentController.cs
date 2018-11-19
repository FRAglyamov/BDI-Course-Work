using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class AgentController : MonoBehaviour
{
    public enum AgentStates
    {
        Idle,
        GoTo,
        UseSmartObject
    }
    [SerializeField]
    public Dictionary<string, int> items = new Dictionary<string, int>();
    public List<Desire> desires = new List<Desire>();
    public List<Intention> intentions = new List<Intention>();
    public List<GameObject> smartGOs = new List<GameObject>();
    public AgentStates state;

    NavMeshAgent navAgent;
    public bool isWorking = false;
    public GameObject bestGO;

    Animator anim;
    AnimatorOverrideController aoc;


    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        smartGOs.AddRange(GameObject.FindGameObjectsWithTag("Smart Object"));
        state = AgentStates.Idle;

        anim = GetComponent<Animator>();
        //aoc = anim.GetComponent<AnimatorOverrideController>();
    }

    void Update()
    {
        //var controller = anim.runtimeAnimatorController;
        smartGOs.Clear();
        smartGOs.AddRange(GameObject.FindGameObjectsWithTag("Smart Object"));

        switch (state)
        {
            case AgentStates.Idle:
                if (desires.Exists(x => x.value < 80f) && smartGOs.Count > 0)
                {
                    bestGO = ChooseSmartObject();
                    navAgent.SetDestination(bestGO.GetComponent<SmartObjectController>().objectInteractionPlace.position);
                    state = AgentStates.GoTo;
                }
                break;
            case AgentStates.GoTo:
                if (Vector3.Distance(navAgent.pathEndPosition, transform.position) > 0.1f)
                {
                    navAgent.SetDestination(bestGO.GetComponent<SmartObjectController>().objectInteractionPlace.position);
                }
                else
                {
                    bestGO.GetComponent<SmartObjectController>().player = gameObject;
                    bestGO.GetComponent<SmartObjectController>().smartObject.playerInteractWithObject = true;
                    state = AgentStates.UseSmartObject;
                }
                break;
            case AgentStates.UseSmartObject:
                if (isWorking == false)
                {
                    state = AgentStates.Idle;
                }
                break;
            default:
                state = AgentStates.Idle;
                break;
        }
        foreach (var desire in desires)
        {
            DescendByTime(ref desire.value, 10f);
            if (desire.value > 100)
            {
                desire.value = 100;
            }
        }
    }

    public void DescendByTime(ref float desireValue, float descending)
    {
        desireValue -= (desireValue / descending) * Time.deltaTime;
    }

    public Intention GetIntention(string intentionName)
    {
        return intentions.Find(intention => intention.name.Equals(intentionName));
    }

    public GameObject ChooseSmartObject()
    {
        Desire topDesire = desires[0];
        foreach (var desire in desires)
        {
            if (desire.value > topDesire.value)
            {
                topDesire = desire;
            }
        }
        GameObject bestObject = smartGOs[0];
        foreach (var smartGO in smartGOs)
        {
            if (smartGO.GetComponent<SmartObjectController>().smartObject.desireChanged.ContainsKey(topDesire.name))
            {
                if (smartGO.GetComponent<SmartObjectController>().smartObject.desireChanged[topDesire.name] > bestObject.GetComponent<SmartObjectController>().smartObject.desireChanged[topDesire.name])
                {
                    bestObject = smartGO;
                }
            }
        }
        return bestObject;

    }
}
