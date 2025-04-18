using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject NotesPrefabs;

    [SerializeField] bool NotesTest = false;

    [SerializeField , Range(1f, 15f)] float HiSpeed = 3f;

    [SerializeField] Vector3 notes_StartPos;

    [SerializeField] Vector3 notes_vec = Vector3.zero;

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
        //�����e�X�g
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
    }

    public void InstantiateNotes(int block)
    {
        GameObject note = Instantiate(NotesPrefabs, new Vector3(Lanes[block].LanePos, notes_StartPos.y, notes_StartPos.z), Quaternion.identity) as GameObject;
        NotesMoving n = note.GetComponent<NotesMoving>();
        n.NotesTransform(HiSpeed, notes_vec);
    }
}
