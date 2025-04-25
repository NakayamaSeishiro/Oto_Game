using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesJudgement : MonoBehaviour
{
    public LiveNotes[] liveNotes = new LiveNotes[0];

    public int Notes_Length = 0;

    public enum JudgementType
    {
        None,
        Perfect,
        Great,
        Bad,
        Miss,
    }

    [System.Serializable]
    public class LiveNotes
    {
        public int Num;
        public int Time;
        public int Keys;

        public JudgementType judgementType;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LiveNotesSet(int Num, int Time, int Keys)
    {
        liveNotes[Num].Time = Time;
    }
}
