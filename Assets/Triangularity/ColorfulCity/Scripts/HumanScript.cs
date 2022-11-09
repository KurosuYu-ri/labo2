using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class HumanScript : MonoBehaviour
{
    // 目的地となるGameObjectをセットします。
    //public Target target;
    private NavMeshAgent myAgent;//ナビメッシュエージェント
    //public GameObject target;
    //public GameObject finaltarget;
 

    public Transform[] destination_;//行き先

    private WalkerGenerator walkerGenerator_;//スポーン用のスクリプト
    private GameDirector gameDirector_;//信号機の切り替えヲ制御しているスクリプト

    private Vector3 spawn_; //スポーン位置

    private string objName;//オブジェクト名

    string dethpawn_;//デスポーン位置

    private bool dethFlag_;//死んだかフラグ

    private int dethRan_;//デスポーン位置を決める乱数

    private int color;

    void Start()
    {
        
        // Nav Mesh Agent を取得します。
        myAgent = GetComponent<NavMeshAgent>();

        //スクリプトの取得
        this.walkerGenerator_ = GameObject.Find("WalkerGenerator").GetComponent<WalkerGenerator>();

        //スクリプトの取得
        this.gameDirector_ = GameObject.Find("SignalDirector").GetComponent<GameDirector>();

        //スポーン位置の取得
        spawn_ = this.walkerGenerator_.GetSpawn();
        
        //キャラクターをワープさせて位置調整
        myAgent.Warp(transform.position);

        //行き先決定
        SetDestination();
    }

    void Update()
    {
         color = this.gameDirector_.GetCarSignalB();
        if(myAgent.isStopped == true && color == 0 || color == 1)
        {
            myAgent.isStopped = false;
        }
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
                    //行き先決定
                    SetDestination();
                }
           }
        }
    }

    //行き先決定
    void SetDestination()
    {
        //ランダムで行き先を決める
        dethRan_ = Random.Range(0, 12);

        //デスポーン位置の名前を入れる
        dethpawn_ = destination_[dethRan_].name;
       // Debug.Log(dethpawn_);
       //デスポーン位置へ移動させる
        myAgent.SetDestination(destination_[dethRan_].position);
    }
    
    //当たり判定
    void OnTriggerEnter(Collider col)
    {
        //当たった物の名前取得
        objName = col.gameObject.name;
        //Debug.Log(objName);
        //デスポーン位置に付いたら
        if (objName.Contains("DethPawn") && dethpawn_ == objName)
        {
            //デスポーン処理
            Destroy(this.gameObject);
        }

    }

    void OnTriggerStay(Collider col)
    {
        if (objName.Contains("CrossWalkStopper"))
        {

            Debug.Log(color);
            if (color == 0 || color == 1)
            {
                this.myAgent.isStopped = false;
            }
            else
            {
                this.myAgent.isStopped = true;
            }

        }
    }

  
    public bool GetDethFlag()
    {
        return dethFlag_;
    }

    public int GetRan()
    {
        return dethRan_;
    }
    //可変長配列をWalkerGeneratorから取得してそれをセットする。
}