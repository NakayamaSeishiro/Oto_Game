using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Playables;

public class NotesFormat : MonoBehaviour
{
    [Path]
    public string JsonName = "";

    private void Start()
    {
        //Format();
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            Format();
        }
        */
    }

    public void Format()
    {
        string JsonPass = "Json/" + JsonName;
        string textAsset = Resources.Load<TextAsset>(JsonPass).ToString();
        JsonFormat jsonData = JsonUtility.FromJson<JsonFormat>(textAsset);

        _scoreNum = new int[jsonData.notes.Length];
        _scoreBlock = new int[jsonData.notes.Length];

        _NAME = jsonData.name;
        _MAXBLOCK = jsonData.maxBlock;
        _BPM = jsonData.BPM;
        _OFFSET = jsonData.offset;
        _LPB = jsonData.notes[0].LPB;

        //Debug.Log($"name : {NAME}, BPM : {BPM}\nmaxBlock : {MAXBLOCK}, offset : {OFFSET}");

        for (int i = 0; i < jsonData.notes.Length; i++)
        {
            _scoreNum[i] = jsonData.notes[i].num;
            _scoreBlock[i] = jsonData.notes[i].block;
            //Debug.Log($"{i} ,,, N: {scoreNum[i]} B: {scoreBlock[i]}");
        }
    }

    [Serializable]
    public class JsonFormat
    {
        public string name;
        public int maxBlock;
        public int BPM;
        public int offset;
        public Notes[] notes;

    }

    [Serializable]
    public class Notes
    {
        public int LPB;
        public int num;
        public int block;
        public int type;
    }

    public string _NAME;
    public int _MAXBLOCK;
    public int _BPM;
    public int _OFFSET;
    public int _LPB;
    public int[] _scoreNum;
    public int[] _scoreBlock;
}
