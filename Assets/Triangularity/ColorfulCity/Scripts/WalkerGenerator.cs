using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    //�����o�ϐ�
    public GameObject criminal_;//�ƍߎ�
    public GameObject inocent_;//��ʐl
    public Transform[] spawn_;//�X�|�[���ʒu
    private int human_ = 0;//�l��
    private int ranSpawn_ = 0;//�X�|�[���ʒu�����߂闐��
    private GameObject spawnHuman_;//�l������ϐ�

    private GameObject[] humanTag_;//HumanTag�𐔂���ϐ�

    private float elapsedTime_;//�v���^�C��

    float reSpawn_ = 0.0f;

    bool spawnFlag_ = false;

    //�萔
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
       

      //�ŏ���10�l�쐬
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
            //�b���J�E���g
            elapsedTime_ += Time.deltaTime;
            
           // Debug.Log(elapsedTime_);
           //�J�E���g���Ă��鎞�Ԃ��ăX�|�[�����鎞�Ԃ��傫���Ȃ�����
            if (elapsedTime_ > reSpawn_)
            {
                //�ăX�|�[��
                Spawn();

                //���̍ăX�|�[���܂ł̎��Ԃ�ݒ�
                reSpawn_ = Random.Range(5.0f, 10.0f);

                //�ăX�|�[��������l���𑝂₷
                this.human_++;

                //�J�E���g���Ă��鎞�Ԃ����Z�b�g
                elapsedTime_ = 0;
            }
        }
        


    }

    //���̉ϒ��z���HumanScript�ɓn����悤�ɃQ�b�^�[���쐬����B
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
            //�ƍߕ��s
            spawnHuman_ = Instantiate(criminal_);
        }
        else
        {
            //���s��
            spawnHuman_ = Instantiate(inocent_);
        }
        spawnHuman_.transform.position = spawn_[ranSpawn_].position;
      
       
    }
}