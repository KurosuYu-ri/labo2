using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
public class CarScript : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent myAgent;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myAgent.pathStatus != UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            myAgent.SetDestination(target.transform.position);
        }
    }
}
