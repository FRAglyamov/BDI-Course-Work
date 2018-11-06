using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EatApple : SmartObjectAction
{

    public override void DoAction(GameObject player)
    {
        // Go to apple position
        //player.GetComponent<NavMeshAgent>().SetDestination(Vector3.zero);

        // Animation = Animation of eating apple

        // ++ Satiety
        player.GetComponent<AgentController>().desires.Find(x => x.name == "Satiety").value += 20;
        // Destroy apple

    }

}