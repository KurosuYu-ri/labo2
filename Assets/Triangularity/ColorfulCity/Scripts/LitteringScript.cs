using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitteringScript : MonoBehaviour
{
    //ポイ捨て犯の処理を書きますよ～ん
    private GameObject dustObject_;//犯罪者
    private float time;
    private GameObject dust;//人を入れる変数

    private WalkerGenerator walkerGenerator_;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        //スクリプトの取得
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
            //位置の調整
            dust.transform.position = pos;
        }

        
    }
}
