using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public NotesInfo[] notesInfo = new NotesInfo[0];

    [System.Serializable]
    public class NotesInfo
    {
        public int Num;

        public float Block;

        public NotesInfo(int Num,int Block)
        {
            this.Num = Num;
            this.Block = Block;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TimerReset();
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        currentFlame++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TimerReset();
            notesInfo = new NotesInfo[0];
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNotesFormat();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadLoadNotesFormat_test();

            NotesDataImport();
        }

        NotesInsutantiate(notesInfo);
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
        
        scoreNum = new int[4];
        scoreBlock = new int[4];

        for (int i = 0; i < 4; i++)
        {
            scoreNum[i] = i + 1;
            scoreBlock[i] = 0;
        }

    }

    //BeatmapLoaded = true;

    void NotesDataImport()
    {
        notesInfo = new NotesInfo[scoreNum.Length];

        for (int i = 0; i < notesInfo.Length; i++)
        {
            notesInfo[i] = new NotesInfo(scoreNum[i], scoreBlock[i]);
            NextNotesTime =  60 / BPM / LPB * 4 * notesInfo[i].Num;
            Debug.Log($"60 / {BPM} / {LPB} * 4 * {notesInfo[i].Num}\n{NextNotesTime}");
        }

        //NextNotesTime = 60 / BPM / LPB * notesInfo[i].Num;
    }

    void NotesInsutantiate(NotesInfo[] notesInfo, int Notes_No = 0)
    {
        if (!BeatmapLoaded)
        {
            return;
        }

        if(currentTime >= NextNotesTime)
        {
            notesInstantiate.InstantiateNotes(notesInfo[Notes_No].Block);

            Notes_No++;

            //NextNotesTime = 60 / BPM / LPB * notesInfo[Notes_No].Num;
        }
    }

    void TimerReset()
    {
        currentTime = 0f;
        currentFlame = 0;
    }
}
