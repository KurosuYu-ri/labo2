using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    public GameObject criminal_;
    public GameObject walker_;

    public Transform[] spawn_;
    /*  public GameObject walker;
      public GameObject walker;
      public GameObject walker;*/
    private int peaple_ = 0;
    private int ranSpawn_ = 0;
    private List<Transform> spawnList_ = new List<Transform>();

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // ranSpawn_ = Random.Range(0, 10);

        if (peaple_ < 10)
        {
         GameObject item;
         int dice = Random.Range(0, 21);
         if(dice % 2 == 0)
         {
            //犯罪歩行
            item = Instantiate(criminal_);
         }
         else 
         {
                //歩行者
            item = Instantiate(walker_);
         }
            item.transform.position = spawn_[0].position;
            Debug.Log(item.transform.position);

            this.peaple_++; 
        }
      
    }

//その可変長配列をHumanScriptに渡せるようにゲッターを作成する。
    public Vector3 GetSpawn()
    {
        return spawn_[0].position;
    }
}
