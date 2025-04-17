using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMoving : MonoBehaviour
{
    [SerializeField] float NotesSpeedRatio = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, -0.1f * NotesSpeedRatio);
        NotesDestroy();
    }

    public void NotesSpeed(float speed)
    {
        NotesSpeedRatio = speed;
    }

    void NotesDestroy()
    {
        if(this.transform.position.y <= -7.0f)
        {
            Destroy(this.gameObject);
        }
    }
}    
