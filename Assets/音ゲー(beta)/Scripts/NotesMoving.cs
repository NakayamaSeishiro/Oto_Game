using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static LoadBeatmap;
using static NotesJudgement;

public class NotesMoving : MonoBehaviour
{
    public float HiSpeed = 1.0f;

    private bool BeatmapStart = false;

    public int NotesNumber = 0;

    public NotesJudgement judgement = null;

    [SerializeField] private bool judged = false;

    [SerializeField] ParticleSystem _perfect;
    [SerializeField] ParticleSystem _great;
    [SerializeField] ParticleSystem _bad;
    [SerializeField] ParticleSystem _miss;

    private Vector3 EffectPos = Vector3.zero;
    private float EffectPos_x = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            BeatmapStart = true;
        }

        if (judgement == null)
        {
            judgement = GameObject.Find("NotesJudgement").GetComponent<NotesJudgement>();
        }

        if (!judged)
        {
            if (judgement.liveNotes[NotesNumber - 1].judgementType != JudgementType.None)
            {
                Debug.Log($"{NotesNumber} : {judgement.liveNotes[NotesNumber - 1].judgementType} ");

                EffectPos = new Vector3(EffectPos_x, -6.5f, -6.5f);

                switch (judgement.liveNotes[NotesNumber - 1].judgementType)
                {
                    case JudgementType.Perfect:

                        Instantiate(_perfect, EffectPos, Quaternion.identity);
                        break;

                    case JudgementType.Great:

                        Instantiate(_great, EffectPos, Quaternion.identity);
                        break;

                    case JudgementType.Bad:

                        Instantiate(_bad, EffectPos, Quaternion.identity);
                        break;

                    case JudgementType.Miss:

                        Instantiate(_miss, EffectPos, Quaternion.identity);
                        break;

                    case JudgementType.None:

                        break;
                }
                

                judged = true;

                NotesDestroy_inGame();
            }
        }

        if (BeatmapStart)
        {
            transform.Translate(0, -HiSpeed * Time.deltaTime, -HiSpeed * Time.deltaTime);

            //Debug.Log(-HiSpeed * Time.deltaTime);
        }

       NotesDestroy_System();
    }

    void NotesDestroy_System()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Destroy(this.gameObject);
        }
    }

    void NotesDestroy_inGame()
    {
        Destroy(this.gameObject);
    }

    public void NotesEffectPos(int LaneNo)
    {
        switch (LaneNo)
        {
            case 1:
                EffectPos_x = -6.0f;
                break;

            case 2:
                EffectPos_x = -2.0f;
                break;

            case 3:
                EffectPos_x = 2.0f;
                break;

            case 4:
                EffectPos_x = 6.0f;
                break;
        }
    }
}    
