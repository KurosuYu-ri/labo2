using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMesh : MonoBehaviour
{ // 目的地となるGameObjectをセットします。
    public GameObject target;
    public NavMeshAgent Human;

    void Start()
    {
        // Nav Mesh Agent を取得します。
        Human = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            Human.destination = target.transform.position;
        }

    }
}
