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
    //�ő啪��
    public static float CountDownTime;
    public TextMeshProUGUI TextCountDown; // �\���p�e�L�X�gUI

    void Start()
    {
        CountDownTime = 30.0f;    // �J�E���g�_�E���J�n�b�����Z�b�g
    }

    // Update is called once per frame
    void Update()
    {
        float minutes = Mathf.FloorToInt(CountDownTime / 60);
        float seconds = Mathf.FloorToInt(CountDownTime % 60);
        // �J�E���g�_�E���^�C���𐮌`���ĕ\��
        TextCountDown.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        // �o�ߎ����������Ă���
        CountDownTime -= Time.deltaTime;

        if (CountDownTime <= 0)
        {
            CountDownTime = 0;
            SceneManager.LoadScene("ResultScene");
        }
    }
}
