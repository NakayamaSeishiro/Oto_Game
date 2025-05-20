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

    // 現在の状態
    [SerializeField] private GameState currentGameState;

    //[Header("必要なコンポーネントを登録")]

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
    // 外からこのメソッドを使って状態を変更
    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    // 起動時のシーンに合わせて状態を初期化
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

    // 状態が変わったら何をするか
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

    // Titleシーン
    void Title()
    {
    }

    // Selectシーン
    void Select()
    {

    }
    // Playingシーン
    void Playing()
    {

    }
    // Resultシーン
    void Result()
    {

    }
    // Endシーン
    void End()
    {

    }
}
