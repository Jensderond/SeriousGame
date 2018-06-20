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
            
            xPos = Random.Range(-7f, -24f);
            yPos = Random.Range(-20f, 20f);
            desiredPos = Vector3.Lerp(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(xPos, 0, yPos), Time.deltaTime * speed);
            transform.position = desiredPos ;
        }

    }
}