using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LivingRoomActorController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public Transform walkAreaUpperBound;
    public Transform walkAreaLowerBound;
    public float minimalDistance;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance <= 0.2f)
        {
            Debug.Log("NavMeshAgent: Calculating new position");
            float x, z;
            while (true)
            {
                x = Random.Range(walkAreaLowerBound.position.x, walkAreaUpperBound.position.x);
                z = Random.Range(walkAreaLowerBound.position.z, walkAreaUpperBound.position.z);
                if (Mathf.Abs(transform.position.x - x) >= minimalDistance || Mathf.Abs(transform.position.z - z) >= minimalDistance)
                {
                    break;
                }
            }
            navMeshAgent.SetDestination(new Vector3(x, 0.0f, z));
        }
    }
}
