using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    //最大分数
    public static float CountDownTime;
    public TextMeshProUGUI TextCountDown; // 表示用テキストUI

    void Start()
    {
        CountDownTime = 30.0f;    // カウントダウン開始秒数をセット
    }

    // Update is called once per frame
    void Update()
    {
        float minutes = Mathf.FloorToInt(CountDownTime / 60);
        float seconds = Mathf.FloorToInt(CountDownTime % 60);
        // カウントダウンタイムを整形して表示
        TextCountDown.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        // 経過時刻を引いていく
        CountDownTime -= Time.deltaTime;

        if (CountDownTime <= 0)
        {
            CountDownTime = 0;
            SceneManager.LoadScene("ResultScene");
        }
    }
}
