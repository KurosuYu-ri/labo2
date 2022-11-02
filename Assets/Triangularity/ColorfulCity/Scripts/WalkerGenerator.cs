using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    //�����o�ϐ�
    public GameObject criminal_;//�ƍߎ�
    public GameObject inocent_;//��ʐl
    public GameObject littering_;//�|�C�̂Ĕ�
    public Transform[] spawn_;//�X�|�[���ʒu
    private int human_ = 0;//�l��
    private int ranSpawn_ = 0;//�X�|�[���ʒu�����߂闐��
    private GameObject spawnHuman_;//�l������ϐ�

    private GameObject[] humanTag_;//HumanTag�𐔂���ϐ�

    private float elapsedTime_;//�v���^�C��

    float reSpawn_ = 0.0f;//�ăX�|�[���܂ł̗���

    bool spawnFlag_ = false;//�����̕b�����Ƃɐl���𑝂₷���t���O

    //�萔
    const int FIRSTPERSON = 10;
    const int MAXPARSON = 15;
   
    //PG���n�܂��čŏ��ɍs���鏈��
    void Start()
    {
        //�����ōăX�|�[���܂ł̎��Ԃ̐ݒ�
        reSpawn_ = Random.Range(5.0f, 10.0f);
    }

    
    //Start�̎��ɍs����J��Ԃ���鏈��
    void Update()
    {
        //�l�̃^�O�ݒ�
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

    //�X�|�[���p�̊֐�
   private void Spawn()
    {
        //�N���X�|�[�������邩�̗���
        int humansRan_ = Random.Range(0, 21);

        //�X�|�[���ʒu�̗���
        ranSpawn_ = Random.Range(0, 10);

        if (humansRan_ <= 7)
        {
            //�ƍߕ��s����
            spawnHuman_ = Instantiate(criminal_);
        }
        else if(humansRan_ <= 14)
        {
            //���s�ҏ���
            spawnHuman_ = Instantiate(inocent_);
        }
        else
        {
            //�|�C�̂ĔƏ���
            spawnHuman_ = Instantiate(littering_);
        }

        //�ʒu�̒���
        spawnHuman_.transform.position = spawn_[ranSpawn_].position;
      
       
    }
}
