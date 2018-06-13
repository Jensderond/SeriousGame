using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    public float xPos;
    public float zPos;
    public Vector3 desiredPos;
    public float speed = 0.1f;
    private float nextActionTime = 0.0f;
    public float period = 10f;

    private void Start()
    {
        xPos = Random.Range(-10f, 10f);
        zPos = Random.Range(-5f, -15f);
        desiredPos = new Vector3(xPos, transform.position.y, zPos);
    }

    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        Debug.Log(Time.time);
        Debug.Log(nextActionTime);
        Debug.Log(Time.time > nextActionTime);
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, desiredPos) <= 0.01f)
            {
                xPos = Random.Range(-10f, 10f);
                zPos = Random.Range(-5f, -15f);
                desiredPos = new Vector3(xPos, transform.position.y, zPos);

            }

        }
    }
}
