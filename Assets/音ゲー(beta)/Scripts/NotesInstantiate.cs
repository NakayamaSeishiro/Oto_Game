using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject NotesPrefabs;

    [Range(1f, 100f)] public float HiSpeed = 1.0f;

    [SerializeField] Vector3 notes_StartPos;

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

    public void InstantiateNotes(int BPM, int LPB, int offset, int Num, int block)
    {
        float InstancePos = ( 1 / 120.0f * (float)HiSpeed *  ( 60.0f / (float)BPM * 120.0f / (float)LPB ) * (float)Num )
                               + ( 1 / 120.0f * (float)HiSpeed * ( (float)offset / 44100.0f * 120.0f) ) - 8.5f;
        GameObject note = Instantiate(NotesPrefabs, new Vector3(Lanes[block].LanePos, InstancePos, InstancePos), Quaternion.identity) as GameObject;
        
        NotesMoving n = note.GetComponent<NotesMoving>();
        n.HiSpeed = HiSpeed;

        
    }
}
