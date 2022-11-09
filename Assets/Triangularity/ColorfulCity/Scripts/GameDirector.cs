using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    //全体の周期の時間
    float SginCycle = 60.0f;

    //今何秒か入れる変数
    public float SignalTime = 0.0f;

    //初期化用の時間
    float InstanceTime = 0.0f;

    //歩行者用信号
    public float WalkBlue;         //青スタートの青の時間
    public float WalkBlueStartRed; //赤スタートの青の時間

    //点滅（歩行者）
    public float WalkYellowB;      //歩行者用（青スタート）の点滅時間
    public float WalkYellowR;      //歩行者用（赤スタート）の点滅時間

    //車用信号
    public float CarGoSgin;        //青信号の時間
    public float CarYellowB;       //車（青スタート）の黄色信号の時間
    public float CarYellowR;       //車（赤スタート）の黄色信号の時間

    //車用信号の色の状態
    public int CarSignalB = 0; //青スタート
    public int CarSignalR = 0; //赤スタート

    //歩行者用の色の状態
    public int WalkSignalB = 0; //青スタート
    public int WalkSignalR = 0; //赤スタート

    //信号の状態
    int RED = 2;    //赤
    int YELLOW = 1; //黄色か点滅
    int BLUE = 0;   //青

    // Start is called before the first frame update
    void Start()
    {
        //周期を4で割った数を入れる変数
        //青→黄色→赤→赤
        //赤→赤→青→黄色
        //で信号が変わるタイミングが4回あるので4で割る
        float CarDivision = SginCycle / 4;

        //車用信号の時間を初期化する
        CarGoSgin = CarDivision;           //青信号
        CarYellowB = CarDivision * 2;  //青スタートの黄色
        CarYellowR = CarDivision * 3;  //赤スタートの黄色

        //歩行者用信号周期
        float WalkDivision = CarDivision / 4;

        //歩行者用信号の時間を初期化する
        WalkBlue = WalkDivision;             //青信号
        WalkBlueStartRed = WalkDivision * 3; //赤スタートの青信号
        WalkYellowB = WalkDivision * 2;      //青スタートの点滅
        WalkYellowR = WalkDivision * 4;      //赤スタートの点滅
    }

    // Update is called once per frame
    void Update()
    {
        //信号の切り替え、60秒で一周
        if (SignalTime < SginCycle)
        {
            //時間を増やす
            SignalTime += Time.deltaTime;

            //信号の状態を変える関数を呼び出す
            CarState();
            WalkState();
        }
        else
        {
            //ループしたら時間の初期化
            SignalTime = InstanceTime;
        }
    }

    //青スタートの車用信号
    public void CarState()
    {
        //0 = 青, 1 = 黄色,2 = 赤
        //15秒ごとに変わる
        if (SignalTime < this.CarGoSgin)       //15秒まで
        {
            CarSignalB = BLUE;
            CarSignalR = RED;
        }
        else if (SignalTime < this.CarYellowB) //30秒まで
        {
            CarSignalB = YELLOW;
            CarSignalR = RED;
        }
        else if (SignalTime < this.CarYellowR) //45秒まで
        {
            CarSignalB = RED;
            CarSignalR = BLUE;
        }
        else if (SignalTime < this.SginCycle)  //60秒まで
        {
            CarSignalB = RED;
            CarSignalR = YELLOW;
        }
    }

    //青スタートの歩行者用信号
    public void WalkState()
    {
        //0 = 青,1 = 点滅,2 = 赤
        //約3.5秒ごとに切り替わる
        if (SignalTime < this.WalkBlue)
        {
            WalkSignalB = BLUE; //青スタートが青
            WalkSignalR = RED;  //赤スタートが赤
        }
        else if (SignalTime < this.WalkYellowB)
        {
            WalkSignalB = YELLOW; //青スタートが点滅
            WalkSignalR = RED;    //赤スタートが赤
        }
        else if (SignalTime < this.WalkBlueStartRed)
        {
            WalkSignalB = RED;  //青スタートが赤になる
            WalkSignalR = BLUE; //赤スタートが青になる
        }
        else if (SignalTime < this.WalkYellowR)
        {
            WalkSignalB = RED;
            WalkSignalR = YELLOW;  //赤スタートが点滅
        }
        else if (SignalTime < this.SginCycle)
        {
            //二つとも周期が終わるまで赤になる
            WalkSignalB = RED;
            WalkSignalR = RED;
        }
    }

    //青スタートの信号の状態を返す
    public int GetCarSignalB()
    {
        int NowTimeB = CarSignalB;
        return NowTimeB;
    }

    //赤スタートの信号の状態を返す
    public int GetCarSignalR()
    {
        int NowTimeR = CarSignalR;
        return NowTimeR;
    }

    //青スタートの歩行者用信号の状態を返す
    public int GetWalkSignalB()
    {
        int NowTimeWB = WalkSignalB;
        return NowTimeWB;
    }

    //赤スタートの歩行者用信号の状態を返す
    public int GetWalkSignalR()
    {
        int NowTimeWR = WalkSignalR;
        return NowTimeWR;
    }
}
