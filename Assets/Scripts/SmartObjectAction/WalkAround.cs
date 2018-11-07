using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAround : SmartObjectAction
{

    public override void DoAction(GameObject player, GameObject smartObject)
    {
        if (player.GetComponent<NavMeshAgent>().isStopped)
        {
            player.GetComponent<NavMeshAgent>().SetDestination(new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5)));
        }

    }
}
