using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navigation : MonoBehaviour
{
    public NavMeshAgent naveMeshAgent;
   // public Transform Target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(1.0f, 1.0f, 1.0f);
        naveMeshAgent.destination = new Vector3(0f, 0f, 0f);
    }
}
