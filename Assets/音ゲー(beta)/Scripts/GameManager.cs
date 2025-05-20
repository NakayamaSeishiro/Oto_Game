using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Title,
    Select,
    Playing,
    Result,
    End
}

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public static GameManager Instance;

    // ���݂̏��
    [SerializeField] private GameState currentGameState;

    //[Header("�K�v�ȃR���|�[�l���g��o�^")]

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
        SetCurrentState(GameState.None);
        OnAwakeCurrentState();

    }
    // �O���炱�̃��\�b�h���g���ď�Ԃ�ύX
    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    // �N�����̃V�[���ɍ��킹�ď�Ԃ�������
    public void OnAwakeCurrentState()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        switch (currentScene)
        {
            case "Title":
                SetCurrentState(GameState.Title);
                break;

            case "Select":
                SetCurrentState(GameState.Select);
                break;

            case "Playing":
                SetCurrentState(GameState.Playing);
                break;

            case "Result":
                SetCurrentState(GameState.Result);
                break;

            case "End":
                SetCurrentState(GameState.End);
                break;

            default:
                break;
        }
    }

    // ��Ԃ��ς�����牽�����邩
    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Title:
                Title();
                break;

            case GameState.Select:
                Select();
                break;

            case GameState.Playing:
                Playing();
                break;

            case GameState.Result:
                Result();
                break;

            case GameState.End:
                End();
                break;

            default:
                break;
        }
    }

    // Title�V�[��
    void Title()
    {
    }

    // Select�V�[��
    void Select()
    {

    }
    // Playing�V�[��
    void Playing()
    {

    }
    // Result�V�[��
    void Result()
    {

    }
    // End�V�[��
    void End()
    {

    }
}
