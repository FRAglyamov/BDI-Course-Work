using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName = "New Smart Object Action", menuName = "Smart Object/Action")]
public abstract class SmartObjectAction : ScriptableObject
{
    [SerializeField]
    public DictionaryStringToFloat desireChanged;
    public AnimationClip animClip;
    public abstract void DoAction(GameObject player, GameObject smartGO);

    //public bool isDestroyed;
    //public virtual void DoAction(GameObject player, GameObject smartGO)
    //{
    //    if (player != null)
    //    {
    //        player.GetComponent<AgentController>().aoc["UseSmartObject"] = animClip;
    //        player.GetComponent<Animator>().SetBool("useSmartObject", true);
    //        foreach (var desire in player.GetComponent<AgentController>().desires)
    //        {
    //            foreach (var changed in desireChanged)
    //            {
    //                if (desire.name == changed.Key)
    //                {
    //                    desire.value += changed.Value;
    //                }
    //            }
    //        }
    //        if(isDestroyed)
    //            Destroy(smartGO);
    //    }
    //}
}
