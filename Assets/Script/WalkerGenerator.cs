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

        //�ォ��R�����g�@����0�Œ�
        ranSpawn_ = 0;
        if (peaple_ < 1)
        {
         GameObject item;
         int dice = Random.Range(0, 21);
         if(dice % 2 == 0)
         {
            //�ƍߕ��s
            item = Instantiate(walker_);
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

        //�����_���X�|�[�����ƂɃ��[�g�����߂�
        /*switch (ranSpawn_)
        {
            case 0:
                int ranRoot_ = Random.Range(0, 5);
                //�Ƃ肠�������񂩂���0�Œ�
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
