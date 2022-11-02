using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    //メンバ変数
    public GameObject criminal_;//犯罪者
    public GameObject inocent_;//一般人
    public GameObject littering_;//ポイ捨て犯
    public Transform[] spawn_;//スポーン位置
    private int human_ = 0;//人数
    private int ranSpawn_ = 0;//スポーン位置を決める乱数
    private GameObject spawnHuman_;//人を入れる変数

    private GameObject[] humanTag_;//HumanTagを数える変数

    private float elapsedTime_;//計測タイム

    float reSpawn_ = 0.0f;//再スポーンまでの乱数

    bool spawnFlag_ = false;//乱数の秒数ごとに人数を増やすかフラグ

    //定数
    const int FIRSTPERSON = 10;
    const int MAXPARSON = 15;
   
    //PGが始まって最初に行われる処理
    void Start()
    {
        //乱数で再スポーンまでの時間の設定
        reSpawn_ = Random.Range(5.0f, 10.0f);
    }

    
    //Startの次に行われる繰り返される処理
    void Update()
    {
        //人のタグ設定
        humanTag_ = GameObject.FindGameObjectsWithTag("Human");
       

      //最初の10人作成
       if (human_ < FIRSTPERSON)
       {
            Spawn();
            this.human_++;
            // Debug.Log(spawnHuman_.transform.position);  
        }

       else if(human_ <= MAXPARSON)
       { 
            if (humanTag_.Length < human_)
            {
                spawnFlag_ = true;
                    Spawn();  
            }
        }
        Debug.Log(humanTag_.Length);
        if (spawnFlag_ == true && humanTag_.Length < MAXPARSON)
        {
            //秒数カウント
            elapsedTime_ += Time.deltaTime;
            
           // Debug.Log(elapsedTime_);
           //カウントしている時間が再スポーンする時間より大きくなったら
            if (elapsedTime_ > reSpawn_)
            {
                //再スポーン
                Spawn();

                //次の再スポーンまでの時間を設定
                reSpawn_ = Random.Range(5.0f, 10.0f);

                //再スポーンしたら人数を増やす
                this.human_++;

                //カウントしている時間をリセット
                elapsedTime_ = 0;
            }
        }
        


    }

    //その可変長配列をHumanScriptに渡せるようにゲッターを作成する。
    public Vector3 GetSpawn()
    {
        return spawn_[ranSpawn_].position;
    }

    //スポーン用の関数
   private void Spawn()
    {
        //誰をスポーンさせるかの乱数
        int humansRan_ = Random.Range(0, 21);

        //スポーン位置の乱数
        ranSpawn_ = Random.Range(0, 10);

        if (humansRan_ <= 7)
        {
            //犯罪歩行召喚
            spawnHuman_ = Instantiate(criminal_);
        }
        else if(humansRan_ <= 14)
        {
            //歩行者召喚
            spawnHuman_ = Instantiate(inocent_);
        }
        else
        {
            //ポイ捨て犯召喚
            spawnHuman_ = Instantiate(littering_);
        }

        //位置の調整
        spawnHuman_.transform.position = spawn_[ranSpawn_].position;
      
       
    }
}
