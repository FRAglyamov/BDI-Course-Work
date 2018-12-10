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
            Destroy(smartGO);
        }

    }
}
