using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{

    private float xPos;
    private float yPos;
    public Vector3 desiredPos;
    public float speed = 0.1f;
    private float nextActionTime = 0.0f;
    public float period = 10f;

 

    private void FixedUpdate()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            xPos = Random.Range(-1.5f, 1.5f);
            yPos = Random.Range(-4f, 4f);
            desiredPos = Vector3.SlerpUnclamped(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(Random.insideUnitCircle.x * xPos, 0, Random.insideUnitCircle.y * yPos), Time.deltaTime * speed);
            transform.position = desiredPos ;
        }

    }
}