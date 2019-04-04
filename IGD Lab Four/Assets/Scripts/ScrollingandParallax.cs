using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingandParallax : MonoBehaviour
{

    public Camera cam;
    public float backgroundSize;

    private Transform cameraTrans;
    private Transform[] layers;
    private float viewZone = 5;
    private int leftIndex;
    private int rightIndex;

    private float camPosition;
    
    void Start()
    {
        cameraTrans = cam.transform;
        layers = new Transform[transform.childCount];

        for (int i=0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length -1;
    }

    private void ScrollLeft()
    {
        layers[rightIndex].position = new Vector2((layers[leftIndex].position.x - backgroundSize)
            , layers[leftIndex].position.y);

        leftIndex = rightIndex;
        rightIndex = rightIndex - 1;

        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        layers[leftIndex].position = new Vector2((layers[rightIndex].position.x + backgroundSize)
            , layers[rightIndex].position.y);

        rightIndex = leftIndex;
        leftIndex = leftIndex + 1;

        if (leftIndex == layers.Length)
            leftIndex = 0;
    }

    void Update()
    {
        if (cameraTrans.position.x < (layers[leftIndex].position.x + viewZone))
            ScrollLeft();
        if (cameraTrans.position.x > (layers[rightIndex].position.x - viewZone))
            ScrollRight();
    }
}
