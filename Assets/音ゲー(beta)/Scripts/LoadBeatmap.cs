using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using static LoadBeatmap;

public class LoadBeatmap : MonoBehaviour
{

    [SerializeField] float _musicTime = 0f;

    [SerializeField] float currentTime = 0f;
    [SerializeField] int currentFlame = 0;

    [SerializeField] NotesFormat format;
    [SerializeField] NotesInstantiate notesInstantiate;
    [SerializeField] NotesJudgement judge;
    [SerializeField] AudioSource Music;

    [SerializeField] bool BeatmapStart = false;

    public string BeatmapName;
    public int maxBlock;
    public int BPM;
    public int offset;
    public int LPB;
    public int[] scoreNum;
    public int[] scoreBlock;

    public NotesInfo[] notesInfo = new NotesInfo[0];

    [System.Serializable]
    public class NotesInfo
    {
        public int Num;

        public int Block;

        public NotesInfo(int Num,int Block)
        {
            this.Num = Num;
            this.Block = Block;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();

        format = GetComponent<NotesFormat>();
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        currentFlame++;

        _musicTime = Music.time;
    }

    // Update is called once per frame
    async Task Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();

            Music.Stop();

            notesInfo = new NotesInfo[0];
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Reset();

            format.Format();

            LoadNotesFormat();

            NotesDataImport();

            NotesInstantiate(notesInfo);

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Reset();

            LoadLoadNotesFormat_test();

            NotesDataImport();

            NotesInstantiate(notesInfo);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Music.Play();
        }
    }

    void LoadNotesFormat()
    {
        BeatmapName = format._NAME;
        maxBlock = format._MAXBLOCK;
        BPM = format._BPM;
        offset = format._OFFSET;
        LPB = format._LPB;

        scoreNum = format._scoreNum;
        scoreBlock = format._scoreBlock;
    }


    void LoadLoadNotesFormat_test()
    {
        //テストデータJson読み込み

        BeatmapName = "test";
        maxBlock = 4;
        BPM = 120;
        offset = 0;
        LPB = 4;
        
        scoreNum = new int[4];
        scoreBlock = new int[4];

        for (int i = 0; i < 4; i++)
        {
            scoreNum[i] = i + 1;
            scoreBlock[i] = i;
        }

    }

    void NotesDataImport()
    {
      
        judge.liveNotes = new NotesJudgement.LiveNotes[scoreNum.Length];

        for (int i = 0; i < notesInfo.Length; i++)
        {
            notesInfo[i] = new NotesInfo(scoreNum[i], scoreBlock[i]);
        }
    }

    void NotesInstantiate(NotesInfo[] notesInfo)
    {
        for (int i = 0; i < notesInfo.Length; i++)
        {
            notesInstantiate.InstantiateNotes(BPM, LPB, offset, scoreNum[i], scoreBlock[i]);
        }

        Debug.Log("Load Successed");
    }

    void Reset()
    {
        currentTime = 0f;
        currentFlame = 0;
    }
}
