using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public enum Judge
{
    Perfect,
    Good,
    Miss,
    None
}

public class DefaultJudge
{
    private float PerfectRange;
    private float GoodRange;
    private float MissRange;

    //最初の定義
    public virtual void Set(float PerfectRen, float GoodRen, float MissRen)
    {
        PerfectRange = PerfectRen;
        GoodRange = GoodRen;
        MissRange = MissRen;
    }

    //判定部分
    public virtual async Task<Judge> GetJudge(float FirstFire, float LastFire, float NowTime, KeyCode imputKey)
    {
        Judge returnJudge = Judge.None;

        if (InDefaultValue(FirstFire, PerfectRange, NowTime)) returnJudge = Judge.Perfect; //Perfect判定
        else if (InDefaultValue(FirstFire, GoodRange, NowTime)) returnJudge = Judge.Good; //Good判定
        else if (InDefaultValue(FirstFire, MissRange, NowTime)) returnJudge = Judge.Miss; //Miss判定
        else returnJudge = Judge.None; //空打ち判定

        if (LastFire != 0f && (returnJudge == Judge.Good || returnJudge == Judge.Perfect))
        {
            while (true)
            {
                float DeltaTime = Time.time - NowTime;
                if (LastFire + MissRange < NowTime + DeltaTime) break;
                if (Input.GetKeyUp(imputKey)) break;
                await Task.Delay(1);
            }
            float DeltaMusicTime = Time.time;
            if (!InDefaultValue(LastFire, GoodRange, DeltaMusicTime)) returnJudge = Judge.Miss; //ロングノーツ終点がGoodRangeに収まってない場合、Missに変換
        } //ロングノーツ処理

        return returnJudge;
    }

    //規定値内の値になっているかを判断
    private bool InDefaultValue(float Value, float Range, float MusicTime)
    {
        bool returnBool = false;

        if (MusicTime - Range <= Value && Value <= MusicTime + Range) returnBool = true;
        else returnBool = false;

        return returnBool;
    }
}
