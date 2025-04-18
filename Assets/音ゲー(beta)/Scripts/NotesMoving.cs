using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMoving : MonoBehaviour
{
    float NotesSpeedRatio = 1f;

    Vector3 notes_route = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 notes_vec = notes_route * NotesSpeedRatio;
        transform.Translate(notes_vec.x, notes_vec.y, notes_vec.z);
        NotesDestroy();
    }

    public void NotesTransform(float speed, Vector3 pos)
    {
        NotesSpeedRatio = speed / 10;
        notes_route = pos;
    }

    void NotesDestroy()
    {
        if((Mathf.Abs(this.transform.position.x) >= 10.0f) ||
                (Mathf.Abs(this.transform.position.y) >= 10.0f) ||
                    (Mathf.Abs(this.transform.position.z) >= 10.0f))
        {
            Destroy(this.gameObject);
        }
    }
}    
