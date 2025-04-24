using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject NotesPrefabs;

    [SerializeField] bool NotesTest = false;

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
        /*
        //ê∂ê¨ÉeÉXÉg
        if (NotesTest)
        {
            if (Input.GetKeyDown(KeyCode.D))
                InstantiateNotes(0);

            if (Input.GetKeyDown(KeyCode.F))
                InstantiateNotes(1);

            if (Input.GetKeyDown(KeyCode.J))
                InstantiateNotes(2);

            if (Input.GetKeyDown(KeyCode.K))
                InstantiateNotes(3);

            if (Input.GetKeyDown(KeyCode.Space))
                InstantiateNotes(4);
        }
        */
    }

    public void InstantiateNotes(int BPM, int LPB, int Num, int block)
    {

        Debug.Log(BPM);

        float InstancePos = Time.deltaTime * ( 60.0f / (float)BPM * (float)Num * 120.0f ) * (float)LPB * (float)HiSpeed
                               /* + 120.0f / (float)BPM * 2.0f * HiSpeed */ - 8.5f;
        GameObject note = Instantiate(NotesPrefabs, new Vector3(Lanes[block].LanePos, InstancePos, InstancePos), Quaternion.identity) as GameObject;
        NotesMoving n = note.GetComponent<NotesMoving>();
        n.HiSpeed = HiSpeed;
    }
}
