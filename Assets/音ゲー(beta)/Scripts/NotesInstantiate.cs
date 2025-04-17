using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject NotesPrefabs;

    [SerializeField] bool NotesTest = false;

    [SerializeField , Range(1f, 15f)] float HiSpeed = 1f;

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
        Application.targetFrameRate = 60;
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
        //ê∂ê¨ÉeÉXÉg
        if (NotesTest)
        {
            if (Input.GetKeyDown(KeyCode.D))
                InstantiateNotes(Lanes[0].LanePos);

            if (Input.GetKeyDown(KeyCode.F))
                InstantiateNotes(Lanes[1].LanePos);

            if (Input.GetKeyDown(KeyCode.J))
                InstantiateNotes(Lanes[2].LanePos);

            if (Input.GetKeyDown(KeyCode.K))
                InstantiateNotes(Lanes[3].LanePos);

            if (Input.GetKeyDown(KeyCode.Space))
                InstantiateNotes(Lanes[4].LanePos);
        }
    }

    public void InstantiateNotes(float lane)
    {
        GameObject note = Instantiate(NotesPrefabs, new Vector3(lane, 6.5f, 0), Quaternion.Euler(-90.0f, 0f, 0f)) as GameObject;
        NotesMoving n = note.GetComponent<NotesMoving>();
        n.NotesSpeed(HiSpeed);
    }

    public void SignalReceiveed_0()
    {
        InstantiateNotes(Lanes[0].LanePos);
    }


    public void SignalReceiveed_1()
    {
        InstantiateNotes(Lanes[1].LanePos);
    }


    public void SignalReceiveed_2()
    {
        InstantiateNotes(Lanes[2].LanePos);
    }


    public void SignalReceiveed_3()
    {
        InstantiateNotes(Lanes[3].LanePos);
    }

    public void SignalReceiveed_4()
    {
        InstantiateNotes(Lanes[4].LanePos);
    }
}
