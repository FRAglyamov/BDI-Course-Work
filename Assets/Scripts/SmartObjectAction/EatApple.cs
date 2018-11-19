using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EatApple : SmartObjectAction
{
    //public DictionaryStringToFloat desireChanged;
    public override void DoAction(GameObject player, GameObject smartGO)
    {
        // Animation = Animation of eating apple

        // ++ Satiety
        if (player != null)
        {
            player.GetComponent<AgentController>().desires.Find(x => x.name == "Satiety").value += 20;
            Destroy(smartGO);
        }

    }

}