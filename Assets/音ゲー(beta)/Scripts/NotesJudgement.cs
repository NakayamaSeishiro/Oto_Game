using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using System.Linq;
using UnityEngine;

public class NotesJudgement : MonoBehaviour
{
    [SerializeField] LoadBeatmap loadBeatmap;

    [SerializeField] private int NEXT_NOTES = 0;
    [SerializeField] private float NEXT_TIME = 0;

    public LiveNotes[] liveNotes = new LiveNotes[0];

    [HideInInspector] public int[] _num = new int[0];
    [HideInInspector] public float[] _time = new float[0];
    [HideInInspector] public int[] _keys = new int[0];

    public bool InfoLoaded = false;

    public enum JudgementType
    {
        None,
        Perfect,
        Great,
        Bad,
        Miss,
    }

    [System.Serializable]
    public class LiveNotes
    {
        public int Num;
        public float Time;
        public int Keys;

        public JudgementType judgementType;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InfoLoaded)
        {
            liveNotes = new LiveNotes[_num.Length].Select(x => { return new LiveNotes(); }).ToArray();
            for (int i = 0; i < _num.Length; i++)
            {
                liveNotes[i].Num = _num[i];
                liveNotes[i].Time = _time[i];
                liveNotes[i].Keys = _keys[i];
            }

            NEXT_NOTES = 0;
            NEXT_TIME = liveNotes[NEXT_NOTES].Time;

            InfoLoaded = false;
        }

        if (loadBeatmap.BeatmapStart)
        {
            LaneJudge();
        }
    }

    void LaneJudge()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(liveNotes[NEXT_NOTES].Keys == 0)
            {
                notesJudge();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (liveNotes[NEXT_NOTES].Keys == 1)
            {
                notesJudge();
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (liveNotes[NEXT_NOTES].Keys == 2)
            {
                notesJudge();
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (liveNotes[NEXT_NOTES].Keys == 3)
            {
                notesJudge();
            }
        }


        if (loadBeatmap.currentTime - NEXT_TIME >= ( 30.0f / 120.0f ))
        {
            liveNotes[NEXT_NOTES].judgementType = JudgementType.Miss;
            NEXT_NOTES++;
            NEXT_TIME = liveNotes[NEXT_NOTES].Time;
        }
    }

    void notesJudge()
    {
        if (Mathf.Abs(loadBeatmap.currentTime - NEXT_TIME) <  ( 30.0f / 120.0f ))
        {
            liveNotes[NEXT_NOTES].judgementType = JudgementType.None;

            if (Mathf.Abs(loadBeatmap.currentTime - NEXT_TIME) < ( 18.0f / 120.0f ))
            {
                liveNotes[NEXT_NOTES].judgementType = JudgementType.Bad;
                if (Mathf.Abs(loadBeatmap.currentTime - NEXT_TIME) < ( 10.0f / 120.0f ))
                {
                    liveNotes[NEXT_NOTES].judgementType = JudgementType.Great;
                    if (Mathf.Abs(loadBeatmap.currentTime - NEXT_TIME) < ( 6.0f / 120.0f ))
                    {
                        liveNotes[NEXT_NOTES].judgementType = JudgementType.Perfect;
                    }
                }

                NEXT_NOTES++;
                NEXT_TIME = liveNotes[NEXT_NOTES].Time;
            }
        }
    }
}
