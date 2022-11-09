using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    //�S�̂̎����̎���
    float SginCycle = 60.0f;

    //�����b�������ϐ�
    public float SignalTime = 0.0f;

    //�������p�̎���
    float InstanceTime = 0.0f;

    //���s�җp�M��
    public float WalkBlue;         //�X�^�[�g�̐̎���
    public float WalkBlueStartRed; //�ԃX�^�[�g�̐̎���

    //�_�Łi���s�ҁj
    public float WalkYellowB;      //���s�җp�i�X�^�[�g�j�̓_�Ŏ���
    public float WalkYellowR;      //���s�җp�i�ԃX�^�[�g�j�̓_�Ŏ���

    //�ԗp�M��
    public float CarGoSgin;        //�M���̎���
    public float CarYellowB;       //�ԁi�X�^�[�g�j�̉��F�M���̎���
    public float CarYellowR;       //�ԁi�ԃX�^�[�g�j�̉��F�M���̎���

    //�ԗp�M���̐F�̏��
    public int CarSignalB = 0; //�X�^�[�g
    public int CarSignalR = 0; //�ԃX�^�[�g

    //���s�җp�̐F�̏��
    public int WalkSignalB = 0; //�X�^�[�g
    public int WalkSignalR = 0; //�ԃX�^�[�g

    //�M���̏��
    int RED = 2;    //��
    int YELLOW = 1; //���F���_��
    int BLUE = 0;   //��

    // Start is called before the first frame update
    void Start()
    {
        //������4�Ŋ�������������ϐ�
        //�����F���ԁ���
        //�ԁ��ԁ������F
        //�ŐM�����ς��^�C�~���O��4�񂠂�̂�4�Ŋ���
        float CarDivision = SginCycle / 4;

        //�ԗp�M���̎��Ԃ�����������
        CarGoSgin = CarDivision;           //�M��
        CarYellowB = CarDivision * 2;  //�X�^�[�g�̉��F
        CarYellowR = CarDivision * 3;  //�ԃX�^�[�g�̉��F

        //���s�җp�M������
        float WalkDivision = CarDivision / 4;

        //���s�җp�M���̎��Ԃ�����������
        WalkBlue = WalkDivision;             //�M��
        WalkBlueStartRed = WalkDivision * 3; //�ԃX�^�[�g�̐M��
        WalkYellowB = WalkDivision * 2;      //�X�^�[�g�̓_��
        WalkYellowR = WalkDivision * 4;      //�ԃX�^�[�g�̓_��
    }

    // Update is called once per frame
    void Update()
    {
        //�M���̐؂�ւ��A60�b�ň��
        if (SignalTime < SginCycle)
        {
            //���Ԃ𑝂₷
            SignalTime += Time.deltaTime;

            //�M���̏�Ԃ�ς���֐����Ăяo��
            CarState();
            WalkState();
        }
        else
        {
            //���[�v�����玞�Ԃ̏�����
            SignalTime = InstanceTime;
        }
    }

    //�X�^�[�g�̎ԗp�M��
    public void CarState()
    {
        //0 = ��, 1 = ���F,2 = ��
        //15�b���Ƃɕς��
        if (SignalTime < this.CarGoSgin)       //15�b�܂�
        {
            CarSignalB = BLUE;
            CarSignalR = RED;
        }
        else if (SignalTime < this.CarYellowB) //30�b�܂�
        {
            CarSignalB = YELLOW;
            CarSignalR = RED;
        }
        else if (SignalTime < this.CarYellowR) //45�b�܂�
        {
            CarSignalB = RED;
            CarSignalR = BLUE;
        }
        else if (SignalTime < this.SginCycle)  //60�b�܂�
        {
            CarSignalB = RED;
            CarSignalR = YELLOW;
        }
    }

    //�X�^�[�g�̕��s�җp�M��
    public void WalkState()
    {
        //0 = ��,1 = �_��,2 = ��
        //��3.5�b���Ƃɐ؂�ւ��
        if (SignalTime < this.WalkBlue)
        {
            WalkSignalB = BLUE; //�X�^�[�g����
            WalkSignalR = RED;  //�ԃX�^�[�g����
        }
        else if (SignalTime < this.WalkYellowB)
        {
            WalkSignalB = YELLOW; //�X�^�[�g���_��
            WalkSignalR = RED;    //�ԃX�^�[�g����
        }
        else if (SignalTime < this.WalkBlueStartRed)
        {
            WalkSignalB = RED;  //�X�^�[�g���ԂɂȂ�
            WalkSignalR = BLUE; //�ԃX�^�[�g���ɂȂ�
        }
        else if (SignalTime < this.WalkYellowR)
        {
            WalkSignalB = RED;
            WalkSignalR = YELLOW;  //�ԃX�^�[�g���_��
        }
        else if (SignalTime < this.SginCycle)
        {
            //��Ƃ��������I���܂ŐԂɂȂ�
            WalkSignalB = RED;
            WalkSignalR = RED;
        }
    }

    //�X�^�[�g�̐M���̏�Ԃ�Ԃ�
    public int GetCarSignalB()
    {
        int NowTimeB = CarSignalB;
        return NowTimeB;
    }

    //�ԃX�^�[�g�̐M���̏�Ԃ�Ԃ�
    public int GetCarSignalR()
    {
        int NowTimeR = CarSignalR;
        return NowTimeR;
    }

    //�X�^�[�g�̕��s�җp�M���̏�Ԃ�Ԃ�
    public int GetWalkSignalB()
    {
        int NowTimeWB = WalkSignalB;
        return NowTimeWB;
    }

    //�ԃX�^�[�g�̕��s�җp�M���̏�Ԃ�Ԃ�
    public int GetWalkSignalR()
    {
        int NowTimeWR = WalkSignalR;
        return NowTimeWR;
    }
}
