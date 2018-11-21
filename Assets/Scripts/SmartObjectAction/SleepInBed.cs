using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepInBed : SmartObjectAction {

    //public DictionaryStringToFloat desireChanged;
    public override void DoAction(GameObject player, GameObject smartGO)
    {
        // ++ Energy
        if (player != null)
        {
            player.GetComponent<AgentController>().aoc["UseSmartObject"] = animClip;
            player.GetComponent<Animator>().SetBool("useSmartObject", true);
            player.GetComponent<AgentController>().desires.Find(x => x.name == "Energy").value += 20;
        }

    }
}
