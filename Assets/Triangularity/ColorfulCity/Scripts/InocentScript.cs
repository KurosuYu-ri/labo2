using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InocentScript : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent myAgent;

    private string objName;

    private bool test;

    private float count = 0.0f;

    private HumanScript humanScript;

    private int ran;
    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       // this.humanScript = this.GameObject.GetComponent<HumanScript>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
       

    }
}
