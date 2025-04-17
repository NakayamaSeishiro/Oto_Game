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
        GameObject note = Instantiate(NotesPrefabs, new Vector3(Lanes[block].LanePos, 6.5f, 0), Quaternion.Euler(-90.0f, 0f, 0f)) as GameObject;
        NotesMoving n = note.GetComponent<NotesMoving>();
        n.NotesSpeed(HiSpeed);
    }
}
