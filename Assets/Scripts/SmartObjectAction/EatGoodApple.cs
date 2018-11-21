using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatGoodApple : SmartObjectAction {

    //public DictionaryStringToFloat desireChanged;
    public override void DoAction(GameObject player, GameObject smartGO)
    {
        // Animation = Animation of eating apple

        // ++ Satiety
        if (player != null)
        {
            player.GetComponent<AgentController>().aoc["UseSmartObject"] = animClip;
            player.GetComponent<Animator>().SetBool("useSmartObject", true);
            player.GetComponent<AgentController>().desires.Find(x => x.name == "Satiety").value += 20;
            Destroy(smartGO);
        }

    }
}
