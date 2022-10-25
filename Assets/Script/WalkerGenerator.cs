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
            //�ƍߕ��s
            item = Instantiate(criminal_);
         }
         else 
         {
                //���s��
            item = Instantiate(walker_);
         }
            item.transform.position = spawn_[0].position;
            Debug.Log(item.transform.position);

            this.peaple_++; 
        }
      
    }

//���̉ϒ��z���HumanScript�ɓn����悤�ɃQ�b�^�[���쐬����B
    public Vector3 GetSpawn()
    {
        return spawn_[0].position;
    }
}
