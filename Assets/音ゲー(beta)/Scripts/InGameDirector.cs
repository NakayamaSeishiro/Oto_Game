using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameDirector : MonoBehaviour
{
    public NotesFormat notesFormat;
    public LoadBeatmap loadBeatmap;
    public NotesInstantiate notesInstantiate;
    public NotesJudgement notesJudgement;
    public NotesMoving notesMoving;
    public UIManager uiManager;

    [Range(1f, 100f)] public float HiSpeed = 30.0f;

    [Range(-10.0f, 10f)] public float PlayOffset = 0.0f;

    // Start is called before the first frame update
    void OnEnable()
    {
        notesFormat = GetComponentInChildren<NotesFormat>();
        loadBeatmap = GetComponentInChildren<LoadBeatmap>();
        notesInstantiate = GetComponentInChildren<NotesInstantiate>();
        notesJudgement = GetComponentInChildren<NotesJudgement>();
        uiManager = GetComponent<UIManager>();
    }

    void Start()
    {
        notesInstantiate.HiSpeed = HiSpeed;
        notesInstantiate.PlayOffset = PlayOffset;
        loadBeatmap.PlayOffset = PlayOffset;

        uiManager.TextUpdate_Speed(HiSpeed);
        uiManager.TextUpdate_Offset(PlayOffset);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            HiSpeed += 10.0f;
            uiManager.TextUpdate_Speed(HiSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            HiSpeed -= 10.0f;
            uiManager.TextUpdate_Speed(HiSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            PlayOffset += 0.05f;
            uiManager.TextUpdate_Offset(PlayOffset);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            PlayOffset -= 0.05f;
            uiManager.TextUpdate_Offset(PlayOffset);
        }

        if ( HiSpeed == notesInstantiate.HiSpeed||
            PlayOffset == notesInstantiate.PlayOffset||
            PlayOffset ==loadBeatmap.PlayOffset)
        {
            notesInstantiate.HiSpeed = HiSpeed;
            notesInstantiate.PlayOffset = PlayOffset;
            loadBeatmap.PlayOffset = PlayOffset;
        }
    }
}
