using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    public GameObject criminal_;
    public GameObject walker_;


    private HumanScript crimScript_;
    private HumanScript walkScript_;

    public Transform[] spawn_;
    public Transform[] root0_0_;


    /*  public GameObject walker;
      public GameObject walker;
      public GameObject walker;*/
    private int peaple_ = 0;
    private int ranSpawn_ = 0;
    private Transform[] root_;
   
    private bool walkerDethFlag_;
    private bool criminalDethFlag_;

    private int maxPeaple_;

    private GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        maxPeaple_ = 10;
    }

    // Update is called once per frame
    void Update()
    {
        ranSpawn_ = Random.Range(0, 10);

      //�ŏ���10�l�쐬
       if (peaple_ < maxPeaple_)
       {
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
           item.transform.position = spawn_[ranSpawn_].position;
           // Debug.Log(item.transform.position);

          this.peaple_++;
       
       }

        //��������Instantiate������
        if (peaple_ >= 10)
        {
            this.crimScript_ = GameObject.Find("criminal").GetComponent<HumanScript>();
            this.walkScript_ = GameObject.Find("musc").GetComponent<HumanScript>();

            this.walkerDethFlag_  = this.walkScript_.GetDethFlag();
           //���񂱂�����
        }

    }

    //���̉ϒ��z���HumanScript�ɓn����悤�ɃQ�b�^�[���쐬����B
    public Vector3 GetSpawn()
    {
        return spawn_[ranSpawn_].position;
    }

    public Transform[] GetRoot()
    {
        return root_;
    }
}
