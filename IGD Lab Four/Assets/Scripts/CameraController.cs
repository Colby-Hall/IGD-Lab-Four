using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;

    private Vector3 lastPlayerPos;
    private float distToShift;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPos = player.transform.position;
    }

    void Update()
    {
        distToShift = player.transform.position.x - lastPlayerPos.x;

        transform.position = new Vector3(transform.position.x + distToShift, 
            transform.position.y, transform.position.z);

        lastPlayerPos = player.transform.position;

    }
}
