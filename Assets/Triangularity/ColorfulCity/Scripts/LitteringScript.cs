using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitteringScript : MonoBehaviour
{
    //�|�C�̂ĔƂ̏����������܂���`��
    private GameObject dustObject_;//�ƍߎ�
    private float time;
    private GameObject dust;//�l������ϐ�

    private WalkerGenerator walkerGenerator_;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        //�X�N���v�g�̎擾
        this.walkerGenerator_ = GameObject.Find("WalkerGenerator").GetComponent<WalkerGenerator>();
        dustObject_ = this.walkerGenerator_.GetDust();
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Transform myTrans = this.transform;

        pos = myTrans.position;
        pos.y = 0.15f;
        if(time > 8.0f)
        {
            dust = Instantiate(dustObject_);
            time = 0.0f;
            //�ʒu�̒���
            dust.transform.position = pos;
        }

        
    }
}
