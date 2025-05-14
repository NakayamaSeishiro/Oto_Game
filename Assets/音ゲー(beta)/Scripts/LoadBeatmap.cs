using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBeatmap : MonoBehaviour
{

    [SerializeField] float _musicTime = 0f;

    public float currentTime = 0f;

    public float PlayOffset = 0f;

    [SerializeField] NotesFormat format;
    [SerializeField] NotesInstantiate notesInstantiate;
    [SerializeField] NotesJudgement judge;
    [SerializeField] AudioSource Music;

    public bool BeatmapStart = false;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();

        format = GetComponent<NotesFormat>();
    }

    void FixedUpdate()
    {
        if (BeatmapStart)
        {
            currentTime += Time.deltaTime;

            _musicTime = Music.time;
        }
    }

    // Update is called once per frame
    async Task Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            BeatmapStart = false;

            Reset();

            StopCoroutine(MusicPlay());

            Music.Stop();

            notesInfo = new NotesInfo[0];
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            format.Format();

            LoadNotesFormat();

            NotesDataImport();

            NotesInstantiate(notesInfo);

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadLoadNotesFormat_test();

            NotesDataImport();

            NotesInstantiate(notesInfo);
        }

        if (Input.GetKey(KeyCode.S))
        {
            BeatmapStart = true;
            StartCoroutine(MusicPlay());
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
        //�e�X�g�f�[�^Json�ǂݍ���

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
        notesInfo = new NotesInfo[scoreNum.Length];

        judge._num = new int[scoreNum.Length];
        judge._time = new float[scoreNum.Length];
        judge._keys = new int[scoreNum.Length];
    }

    void NotesInstantiate(NotesInfo[] notesInfo)
    {
        for (int i = 0; i < notesInfo.Length; i++)
        {
            notesInstantiate.InstantiateNotes(BPM, LPB, offset, scoreNum[i], scoreBlock[i], i);

            judge._num[i] = i;
            judge._time[i] = /* �e�m�[�c�̔��莞�� */ �@     60.0f / (float)BPM / (float)LPB * (float)scoreNum[i]
                             /* �Ȃ̃I�t�Z�b�g */          + (float)offset / 44100.0f
                             /* �v���C���[�̃I�t�Z�b�g*/   + PlayOffset
                             /* 1s�x�� */                  + 1.0f
                             /* ������ */                  - 0.01f;
            judge._keys[i] = scoreBlock[i];
        }

        judge.InfoLoaded = true;

        Debug.Log("Load Successed");
    }

    void Reset()
    {
        currentTime = 0f;

        _musicTime = 0f;
    }

    private IEnumerator MusicPlay()
    {
        yield return new WaitForSeconds(1.0f);

        Music.Play();
    }
}
