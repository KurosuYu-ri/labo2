using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    public GameObject criminal_;
    public GameObject walker_;

    public Transform[] spawn_;

    private int peaple_ = 0;
    private int ranSpawn_ = 0;

    private int maxPeaple_;

    private GameObject item;

    private GameObject[] humanObject_;

    float elapsedTime;

    bool spawnFlag_ = false;
    // Start is called before the first frame update
    void Start()
    {
        maxPeaple_ = 15;
    }

    // Update is called once per frame
    void Update()
    {
        ranSpawn_ = Random.Range(0, 10);

      //最初の10人作成
       if (peaple_ < 10)
       {
            Spawn();
            this.peaple_++;
            // Debug.Log(item.transform.position);  
        }
       else if(peaple_ <= maxPeaple_)
       { 
          humanObject_ = GameObject.FindGameObjectsWithTag("Human");

            if (humanObject_.Length < peaple_)
            {
                spawnFlag_ = true;
                    Spawn();
               
            }
        }

       if(spawnFlag_ == true || humanObject_.Length <= maxPeaple_)
        {
            //10秒カウント
            elapsedTime += Time.deltaTime;
            Debug.Log(humanObject_.Length);
           // Debug.Log(elapsedTime);
            if (elapsedTime > 10.0f)
            {
                Spawn();
                this.peaple_++;
                elapsedTime = 0;
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

        if (dice % 2 == 0)
        {
            //犯罪歩行
            item = Instantiate(criminal_);
        }
        else
        {
            //歩行者
            item = Instantiate(walker_);
        }
        item.transform.position = spawn_[ranSpawn_].position;
      
       
    }
}
