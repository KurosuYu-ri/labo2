using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class HumanScript : MonoBehaviour
{
    // 目的地となるGameObjectをセットします。
    //public Target target;
    private NavMeshAgent myAgent;
    //public GameObject target;
    //public GameObject finaltarget;
    private int hitCount;

    public Transform[] waypoints;
    private int currentWaypointIndex;

    private WalkerGenerator walkerGenerator_;
    private Vector3 spawn_;

    private string objName;

    string dethpawn_;

    private bool dethFlag_;
    
    void Start()
    {
        
        // Nav Mesh Agent を取得します。
        myAgent = GetComponent<NavMeshAgent>();
        this.walkerGenerator_ = GameObject.Find("WalkerGenerator").GetComponent<WalkerGenerator>();
        //スポーン位置の取得
        spawn_ = this.walkerGenerator_.GetSpawn();
        // waypoints = this.walkerGenerator_.GetRoot();
        //Debug.Log(waypoints[0].position);
        myAgent.Warp(transform.position);
        SetDestination();
    }

    void Update()
    {
        dethFlag_ = false;
        // targetに向かって移動します。
        //if (myAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        //{
        //    myAgent.SetDestination(target.transform.position);
        //}

        //信号が青になったらtargetを変更する
        /*if(myAgent.remainingDistance <= myAgent.stoppingDistance)
        {
              //次のtargetに移動
        myAgent.SetDestination(finaltarget.transform.position);
        
        }*/

        
    }
    void RandomWander()
    {
        
        //指定した目的地に障害物があるかどうか、そもそも到達可能なのかを確認して問題なければセットする。
        //pathPending 経路探索の準備できているかどうか
        if (!myAgent.pathPending)
        {
            if (myAgent.remainingDistance <= myAgent.stoppingDistance)
            {
                //hasPath エージェントが経路を持っているかどうか
                //navMeshAgent.velocity.sqrMagnitudeはスピード
                if (!myAgent.hasPath || myAgent.velocity.sqrMagnitude == 0f)
                {
                    SetDestination();
                }
           }
        }
    }

    void SetDestination()
    {
         int ran = Random.Range(0, 12);
        //Vector3 randomPos = new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));
        //SamplePositionは設定した場所から5の範囲で最も近い距離のBakeされた場所を探す。
        //NavMesh.SamplePosition(randomPos, out navMeshHit, 5, 1);
        //navMeshAgent.destination = navMeshHit.position;
        // this.transform.position = spawn_;
        dethpawn_ = waypoints[ran].name;
       // Debug.Log(dethpawn_);
        myAgent.SetDestination(waypoints[ran].position);
    }
    

    void OnTriggerEnter(Collider col)
    {
        objName = col.gameObject.name;
        //Debug.Log(objName);
        if(objName.Contains("Cube")&&dethpawn_ == objName)
        {
          Destroy(this.gameObject);
        }
       
    }

    public int GethitCount()
    {
        return hitCount;
    }

 
    public bool GetDethFlag()
    {
        return dethFlag_;
    }
    //可変長配列をWalkerGeneratorから取得してそれをセットする。
}