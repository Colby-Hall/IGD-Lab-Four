using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformKiller : MonoBehaviour
{
    public GameObject platDeathPoint;
    

    void Start()
    {
        platDeathPoint = GameObject.Find("PlatformDeathPoint");
    }

    
    void Update()
    {
        if (transform.position.x < platDeathPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
