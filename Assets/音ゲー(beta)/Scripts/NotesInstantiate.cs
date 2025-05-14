using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject NotesPrefabs;

    public float HiSpeed = 1.0f;

    public float PlayOffset = 0.0f;

    [SerializeField] Vector3 notes_StartPos;

    [SerializeField] GameObject parent;

    [SerializeField]
    LaneInfo[] Lanes;

    [System.Serializable]
    public class LaneInfo
    {
        public string LaneNo;

        public float LanePos;
    }

    void Awake()
    {
        Application.targetFrameRate = 120;
    }

    void Start()
    {
        if(NotesPrefabs == null)
        {
            return;
        }
    }

    void Update()
    {

    }

    public void InstantiateNotes(int BPM, int LPB, int offset, int Num, int block, int i)
    {   
        float InstancePos = /* 各ノーツ生成 */　             ( 1 / 120.0f * (float)HiSpeed *  ( 60.0f / (float)BPM * 120.0f / (float)LPB ) * (float)Num )
                            /* 曲のオフセット */           + ( 1 / 120.0f * (float)HiSpeed * ( (float)offset / 44100.0f * 120.0f) ) 
                            /* プレイヤーのオフセット */   + ( 1 / 120.0f * (float)HiSpeed * ( (float)PlayOffset * 120.0f) )
                            /* 1s遅延 */                   + ( 1 / 120.0f * (float)HiSpeed * 120.0f )
                               - 8.5f;
        GameObject note = Instantiate(NotesPrefabs, new Vector3(Lanes[block].LanePos, InstancePos, InstancePos), Quaternion.identity) as GameObject;

        note.transform.parent = parent.transform;

        NotesMoving n = note.GetComponent<NotesMoving>();

        n.HiSpeed = HiSpeed;

        n.NotesNumber = i + 1;

        n.NotesEffectPos(int.Parse(Lanes[block].LaneNo));

        note.name = "Note" + n.NotesNumber.ToString();
    }
}
