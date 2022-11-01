using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    //メンバ変数
    public GameObject criminal_;//犯罪者
    public GameObject inocent_;//一般人
    public Transform[] spawn_;//スポーン位置
    private int human_ = 0;//人数
    private int ranSpawn_ = 0;//スポーン位置を決める乱数
    private GameObject spawnHuman_;//人を入れる変数

    private GameObject[] humanTag_;//HumanTagを数える変数

    private float elapsedTime_;//計測タイム

    float reSpawn_ = 0.0f;

    bool spawnFlag_ = false;

    //定数
    const int FIRSTPERSON = 10;
    const int MAXPARSON = 15;
   
    void Start()
    {
        reSpawn_ = Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
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

   private void Spawn()
    {
        int dice = Random.Range(0, 21);
        ranSpawn_ = Random.Range(0, 10);
        if (dice % 2 == 0)
        {
            //犯罪歩行
            spawnHuman_ = Instantiate(criminal_);
        }
        else
        {
            //歩行者
            spawnHuman_ = Instantiate(inocent_);
        }
        spawnHuman_.transform.position = spawn_[ranSpawn_].position;
      
       
    }
}
