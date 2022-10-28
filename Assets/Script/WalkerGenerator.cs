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
    // Start is called before the first frame update
    void Start()
    {
        maxPeaple_ = 10;
    }

    // Update is called once per frame
    void Update()
    {
        ranSpawn_ = Random.Range(0, 10);

      //最初の10人作成
       if (peaple_ < maxPeaple_)
       {
            Spawn();
            // Debug.Log(item.transform.position);

            this.peaple_++;
       
       }
       else
       { 
          humanObject_ = GameObject.FindGameObjectsWithTag("Human");

            if (humanObject_.Length < 10)
            {
                Spawn();
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
