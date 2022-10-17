using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMesh : MonoBehaviour
{ // �ړI�n�ƂȂ�GameObject���Z�b�g���܂��B
    public GameObject target;
    public NavMeshAgent Human;

    void Start()
    {
        // Nav Mesh Agent ���擾���܂��B
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
