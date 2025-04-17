using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadBeatmap;

public class LoadBeatmap : MonoBehaviour
{
    [SerializeField] float currentTime = 0f;
    [SerializeField] int currentFlame = 0;

    [SerializeField] NotesFormat format;
    [SerializeField] NotesInstantiate notesInstantiate;

    public string BeatmapName;
    public int maxBlock;
    public int BPM;
    public int offset;
    public int LPB;
    public int[] scoreNum;
    public int[] scoreBlock;

    [SerializeField] float NextNotesTime = 0f;

    [SerializeField] bool BeatmapLoaded = false;

    [SerializeField] bool BeatmapStart = false;

    [SerializeField] int Notes_No = 0;

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
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        currentFlame++;

        
        NotesInsutantiate(notesInfo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Reset();
            notesInfo = new NotesInfo[0];
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNotesFormat();

            NotesDataImport();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadLoadNotesFormat_test();

            NotesDataImport();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Reset();
            BeatmapStart = true;
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
        maxBlock = 5;
        BPM = 120;
        offset = 0;
        LPB = 4;
        
        scoreNum = new int[5];
        scoreBlock = new int[5];

        for (int i = 0; i < 5; i++)
        {
            scoreNum[i] = i + 1;
            scoreBlock[i] = i;
        }

    }

    void NotesDataImport()
    {
        notesInfo = new NotesInfo[scoreNum.Length];

        for (int i = 0; i < notesInfo.Length; i++)
        {
            notesInfo[i] = new NotesInfo(scoreNum[i], scoreBlock[i]);
        }

        NextNotesTime = 60 / (float)BPM / (float)LPB * 4 * (float)notesInfo[0].Num;

        Reset();

        BeatmapLoaded = true;
    }

    void NotesInsutantiate(NotesInfo[] notesInfo)
    {
        if (!BeatmapStart)
        {
            //Debug.Log($"Don't Beatmap Loaded!");
            return;
        }

        if (currentTime >= NextNotesTime)
        {
            notesInstantiate.InstantiateNotes(notesInfo[Notes_No].Block);

            Debug.Log($"Notes_No : {Notes_No}");

            Notes_No++;

            if (Notes_No >= notesInfo.Length)
            {
                BeatmapStart = false;
                return;
            }

            NextNotesTime = ( 60 / (float)BPM / (float)LPB * 4 * (float)notesInfo[Notes_No].Num ) - 
                ( 60 / (float)BPM / (float)LPB * 4 * (float)notesInfo[Notes_No - 1].Num );

            currentTime = 0f;
        }
    }

    void Reset()
    {
        currentTime = 0f;
        currentFlame = 0;
        Notes_No = 0;
    }
}
