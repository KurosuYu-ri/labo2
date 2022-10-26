using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    public GameObject criminal_;
    public GameObject walker_;

    public Transform[] spawn_;
    public Transform[] root0_0_;


    /*  public GameObject walker;
      public GameObject walker;
      public GameObject walker;*/
    private int peaple_ = 0;
    private int ranSpawn_ = 0;
    private List<Transform> rootList_ = new List<Transform>();
    private Transform[] root_;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ranSpawn_ = Random.Range(0, 10);

        //後からコメント　今は0固定
        ranSpawn_ = 0;
        if (peaple_ < 1)
        {
         GameObject item;
         int dice = Random.Range(0, 21);
         if(dice % 2 == 0)
         {
            //犯罪歩行
            item = Instantiate(walker_);
         }
         else 
         {
                //歩行者
            item = Instantiate(walker_);
         }
            item.transform.position = spawn_[ranSpawn_].position;
           // Debug.Log(item.transform.position);

            this.peaple_++;
        }

        //ランダムスポーンごとにルートを決める
        /*switch (ranSpawn_)
        {
            case 0:
                int ranRoot_ = Random.Range(0, 5);
                //とりあえずこんかいは0固定
                ranRoot_ = 0;
                switch (ranRoot_)
                {
                    case 0:
                        root_ = root0_0_;
                        
                        break;

                    default:
                        break;
                }



                break;
        }
        */

    }

    //その可変長配列をHumanScriptに渡せるようにゲッターを作成する。
    public Vector3 GetSpawn()
    {
        return spawn_[ranSpawn_].position;
    }

    public Transform[] GetRoot()
    {
        return root_;
    }
}
