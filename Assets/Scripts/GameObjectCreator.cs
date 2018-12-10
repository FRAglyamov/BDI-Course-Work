using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectCreator : MonoBehaviour {

    public GameObject createdObject;
    public float spawnCD = 20f;
    float spawnTime = 0f;

    void Start()
    {
        Instantiate(createdObject, this.transform);
    }


    void Update()
    {
        if (transform.childCount != 0)
            spawnTime = Time.time + spawnCD;
        if (Time.time > spawnTime)
            Instantiate(createdObject, this.transform);

        if (transform.childCount == 0 && Time.time > spawnTime)
        {
            Instantiate(createdObject, this.transform);
            spawnTime = Time.time + spawnCD;
        }

    }
}
