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
    public List<Desire> curDesires;
    public List<GameObject> smartGOs = new List<GameObject>();
    public AgentStates state;

    [SerializeField]
    public Dictionary<GameObject, float> objectsUtility = new Dictionary<GameObject, float>();

    NavMeshAgent navAgent;
    public bool isWorking = false;
    public GameObject bestGO;

    Animator anim;
    public AnimatorOverrideController aoc;

    public TextMesh textMesh;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        smartGOs.AddRange(GameObject.FindGameObjectsWithTag("Smart Object"));
        state = AgentStates.Idle;

        anim = GetComponent<Animator>();
        aoc = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = aoc;

        if (textMesh == null)
            textMesh = transform.Find("TextMesh").GetComponent<TextMesh>();
    }

    void Update()
    {
        smartGOs.Clear();
        smartGOs.AddRange(GameObject.FindGameObjectsWithTag("Smart Object"));
        switch (state)
        {
            case AgentStates.Idle:

                anim.SetBool("goTo", false);
                anim.SetBool("idle", true);
                if (desires.Exists(x => x.value < 90f) && smartGOs.Count > 0)
                {
                    curDesires = desires.FindAll(x => x.value < 90f);
                    bestGO = ChooseSmartObjectUtility();
                    if (bestGO != null)
                    {
                        navAgent.SetDestination(bestGO.GetComponent<SmartObjectController>().objectInteractionPlace.position);
                        state = AgentStates.GoTo;
                    }

                }
                break;
            case AgentStates.GoTo:

                anim.SetBool("idle", false);
                anim.SetBool("goTo", true);
                if (bestGO == null)
                {
                    state = AgentStates.Idle;
                }
                if (Vector3.Distance(navAgent.pathEndPosition, transform.position) > 0.1f)
                {
                    //Debug.Log(this.gameObject.name + " GoTo " + bestGO.GetComponent<SmartObjectController>().objectInteractionPlace.position);
                    navAgent.SetDestination(bestGO.GetComponent<SmartObjectController>().objectInteractionPlace.position);
                    if(bestGO.GetComponent<SmartObjectController>().isPlayerInteractWithObject)
                    {

                    }
                }
                else
                {
                    bestGO.GetComponent<SmartObjectController>().player = gameObject;
                    bestGO.GetComponent<SmartObjectController>().isPlayerInteractWithObject = true;
                    state = AgentStates.UseSmartObject;
                    anim.SetBool("useSmartObject", true);
                    isWorking = true;
                }
                break;
            case AgentStates.UseSmartObject:

                anim.SetBool("goTo", false);
                anim.SetBool("idle", false);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Use Smart Object") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    anim.SetBool("useSmartObject", false);
                    state = AgentStates.Idle;
                    isWorking = false;
                    bestGO.GetComponent<SmartObjectController>().isPlayerInteractWithObject = false;
                }
                break;
            default:
                state = AgentStates.Idle;
                break;
        }
        foreach (var desire in desires)
        {
            DescendByTime(ref desire.value, 2f);
            if (desire.value > 100)
            {
                desire.value = 100;
            }
            if (desire.value < 0)
            {
                desire.value = 0;
            }
        }

        TextMeshUpdate();
    }

    public void TextMeshUpdate()
    {

        textMesh.text = "";
        foreach (var desire in desires)
        {
            textMesh.text += desire.name + ": " + (int)desire.value + "\n";
        }
        if (bestGO == null)
        {
            textMesh.text += "None";
        }
        else
        {
            textMesh.text += bestGO.name;
        }
        textMesh.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }

    public void DescendByTime(ref float desireValue, float descending)
    {
        desireValue = desireValue - (descending * Time.deltaTime);
    }

    public GameObject ChooseSmartObject()
    {
        //Desire topDesire = desires[0];
        //foreach (var desire in desires)
        //{
        //    if (desire.value > topDesire.value)
        //    {
        //        topDesire = desire;
        //    }
        //}
        Desire topDesire = curDesires[0];

        foreach (var desire in curDesires)
        {
            if (desire.value < topDesire.value)
            {
                topDesire = desire;
            }
        }
        GameObject bestObject = smartGOs[0];
        foreach (var smartGO in smartGOs)
        {
            if (smartGO.GetComponent<SmartObjectController>().smartObject.desireChanged.ContainsKey(topDesire.name))
            {
                if (!bestObject.GetComponent<SmartObjectController>().smartObject.desireChanged.ContainsKey(topDesire.name) || smartGO.GetComponent<SmartObjectController>().smartObject.desireChanged[topDesire.name] > bestObject.GetComponent<SmartObjectController>().smartObject.desireChanged[topDesire.name])
                {
                    bestObject = smartGO;
                }
            }
        }
        if (!bestObject.GetComponent<SmartObjectController>().smartObject.desireChanged.ContainsKey(topDesire.name))
        {
            return null;
        }
        return bestObject;
    }

    public GameObject ChooseSmartObjectUtility()
    {

        GameObject bestObject = smartGOs[0];
        float bestObjectUtility = CalculateUtility(bestObject);

        foreach (var smartGO in smartGOs)
        {
            float curGOUtility = CalculateUtility(smartGO);

            if (bestObjectUtility < curGOUtility)
            {
                bestObject = smartGO;
                bestObjectUtility = curGOUtility;
            }
        }

        return bestObject;
    }

    public float CalculateUtility(GameObject smartObject)
    {
        Desire curDesire;
        float smartObjectUtility = 0f;
        float utilityBefore = 0f;
        float utilityAfter = 0f;
        objectsUtility.Clear();
        foreach (var smartObjectDesire in smartObject.GetComponent<SmartObjectController>().smartObject.desireChanged)
        {
            curDesire = curDesires.Find(x => x.name == smartObjectDesire.Key);
            if (curDesire == null)
            {
                continue;
            }
            utilityBefore = curDesire.value;
            utilityAfter = smartObjectDesire.Value + curDesire.value;
            if (utilityAfter > 100f)
            {
                utilityAfter = 100f;
            }
            Debug.Log("Desire " + curDesire.name + " weight: " + curDesire.GetDesireWeight(curDesire.value / 100));
            smartObjectUtility = (utilityAfter - utilityBefore) * curDesire.GetDesireWeight(curDesire.value / 100);
            objectsUtility.Add(smartObject, smartObjectUtility);
            Debug.Log("Object: " + smartObject.name + " Desire: " + curDesire.name + " Before: " + utilityBefore + " After: " + utilityAfter + " Utility: " + smartObjectUtility);
        }
        return smartObjectUtility;
    }
}
