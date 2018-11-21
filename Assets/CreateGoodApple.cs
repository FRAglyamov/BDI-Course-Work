using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGoodApple : MonoBehaviour
{

    public GameObject goodApple;
    float spawnCD = 20f;
    float spawnTime = 0f;

    void Start()
    {
        Instantiate(goodApple, this.transform);
    }


    void Update()
    {
        if (transform.childCount != 0)
            spawnTime = Time.time + spawnCD;
        if (Time.time > spawnTime)
            Instantiate(goodApple, this.transform);

        if (transform.childCount == 0 && Time.time > spawnTime)
        {
            Instantiate(goodApple, this.transform);
            spawnTime = Time.time + spawnCD;
        }

    }
}
