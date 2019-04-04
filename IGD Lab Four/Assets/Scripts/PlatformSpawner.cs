using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public Transform spawnPoint;
    public float distance;

    private float platWidth;



    void Start()
    {
        platWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    
    void Update()
    {
        if (transform.position.x < spawnPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platWidth + distance, 
                transform.position.y, transform.position.z);

            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}
