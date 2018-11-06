using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField]
    public Dictionary<string, int> items = new Dictionary<string, int>();
    public List<Desire> desires = new List<Desire>();
    public List<Intention> intentions = new List<Intention>();
    public List<GameObject> smartGOs = new List<GameObject>();

    NavMeshAgent navAgent;
    public bool isWorking = false;
    public GameObject bestGO;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        smartGOs.AddRange(GameObject.FindGameObjectsWithTag("Smart Object"));
    }

    void Update()
    {
        foreach (var desire in desires)
        {
            DescendByTime(desire.value, 10f);
            if (desire.value > 100)
            {
                desire.value = 100;
            }
        }
        if (isWorking == false)
        {
            bestGO = ChooseSmartObject();
            //navAgent.SetDestination(bestGO.GetComponent<SmartObjectController>().smartObject.objectInteractionPlace.position);
            navAgent.SetDestination(bestGO.GetComponent<SmartObjectController>().objectInteractionPlace.position);
        }
        //Debug.Log(navAgent.pathEndPosition);
        //Debug.Log(transform.position);

        if (Vector3.Distance(navAgent.pathEndPosition, transform.position) < 0.1f)
        {
            Debug.Log("IF==TRUE");
            bestGO.GetComponent<SmartObjectController>().player = gameObject;
            bestGO.GetComponent<SmartObjectController>().smartObject.playerInteractWithObject = true;
            isWorking = true;
        }
        else
        {
            Debug.Log("hasDest");
            //navAgent.SetDestination(bestGO.GetComponent<SmartObjectController>().smartObject.objectInteractionPlace.position);
            navAgent.SetDestination(bestGO.GetComponent<SmartObjectController>().objectInteractionPlace.position);
        }

        //if (Vector3.Distance(navAgent.pathEndPosition, transform.position) < 0.1f)
        //{
        //    Debug.Log("IF==TRUE");
        //    bestGO.GetComponent<SmartObjectController>().player = gameObject;
        //    bestGO.GetComponent<SmartObjectController>().smartObject.playerInteractWithObject = true;
        //    isWorking = true;
        //}
        //else
        //{
        //    Debug.Log("hasDest");
        //    navAgent.SetDestination(bestGO.GetComponent<SmartObjectController>().smartObject.objectInteractionPlace.position);
        //}
    }

    public void DescendByTime(float desireValue, float descending)
    {
        desireValue = desireValue / descending * Time.deltaTime;
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
        //navAgent.SetDestination(bestObject.GetComponent<SmartObjectController>().smartObject.objectInteractionPlace.position);
        //if (navAgent.destination == null)
        //{
        //    bestObject.GetComponent<SmartObjectController>().player = this.gameObject;
        //    bestObject.GetComponent<SmartObjectController>().smartObject.playerInteractWithObject = true;
        //    isWorking = true;
        //}

    }

    //public Intention ChooseIntention(List<Intention> intentions, List<Desire> desires)
    //{
    //    // Сначала выбираем какая цель имеет наибольшую важность
    //    Desire topDesire = desires[0];
    //    foreach (var desire in desires)
    //    {
    //        if (desire.value > topDesire.value)
    //        {
    //            topDesire = desire;
    //        }
    //    }

    //    // Находим наилучшее действие по полезности для заданной цели
    //    Intention bestIntention = intentions[0];
    //    float bestUtility = intentions[0].getDesireChange(topDesire);
    //    foreach (var intention in intentions)
    //    {
    //        float utility = -intention.getDesireChange(topDesire);
    //        if (utility > bestUtility)
    //        {
    //            bestUtility = utility;
    //            bestIntention = intention;
    //        }
    //    }
    //    return bestIntention;
    //}
}
