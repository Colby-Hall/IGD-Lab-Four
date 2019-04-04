using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject[] platforms;
    public Transform spawnPoint;
    public float distance;
    
    private int platformChoice;
    private float[] platformWidths;

    public float platDistMin;
    public float platDistMax;

    private float platMinHeight;
    private float platMaxHeight;
    private float platformHeight;

   



    void Start()
    { 
        platformWidths = new float[platforms.Length];

        for (int i = 0; i < platforms.Length; i++)
        {
            platformWidths[i] = platforms[i].GetComponent <BoxCollider2D>().size.x;
        }

        platMinHeight = -5;
        platMaxHeight = 3;
    }

    
    void Update()
    {
        if (transform.position.x < spawnPoint.position.x)
        {
            distance = Random.Range(platDistMin, platDistMax);

            platformHeight = Random.Range(platMinHeight, platMaxHeight);

            platformChoice = Random.Range(0, platforms.Length);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformChoice] / 1.2f) + distance, 
                platformHeight, transform.position.z);

            

            Instantiate(platforms[platformChoice], transform.position, transform.rotation);
        }
    }
}
