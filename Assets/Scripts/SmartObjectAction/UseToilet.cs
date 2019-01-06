using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseToilet : SmartObjectAction
{

    public override void DoAction(GameObject player, GameObject smartGO)
    {
        // ++ Bladder
        if (player != null)
        {
            player.transform.rotation = smartGO.transform.rotation;
            player.GetComponent<AgentController>().aoc["UseSmartObject"] = animClip;
            player.GetComponent<Animator>().SetBool("useSmartObject", true);
            foreach (var desire in player.GetComponent<AgentController>().desires)
            {
                foreach (var changed in desireChanged)
                {
                    if (desire.name == changed.Key)
                    {
                        desire.value += changed.Value;
                    }
                }
            }
        }
    }
}
