using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateApple : MonoBehaviour
{

    public GameObject apple;
    void Start()
    {
        Instantiate(apple, this.transform);
    }


    void Update()
    {
        if (transform.childCount == 0)
        {
            Instantiate(apple, this.transform);
        }

    }
}
