using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadBeatmap;

public class NotesMoving : MonoBehaviour
{
    public float HiSpeed = 1.0f;

    private bool BeatmapStart = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            BeatmapStart = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BeatmapStart)
        {
            transform.Translate(0, -HiSpeed * Time.deltaTime, -HiSpeed * Time.deltaTime);

            //Debug.Log(-HiSpeed * Time.deltaTime);
        }

        NotesDestroy();
    }

    void NotesDestroy()
    {
        if((this.transform.position.y <= -13) || (this.transform.position.z <= -13))
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKey(KeyCode.R))
        {
            Destroy(this.gameObject);
        }
    }
}    
