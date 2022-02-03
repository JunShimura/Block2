using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState { Loading, Ready,InGame,GameOver, GameClear }

    [SerializeField] ScoreText scoreText;
    [SerializeField] Ball ball;
    [SerializeField] ClickPanel ready;
    [SerializeField] ClickPanel gameClear;
    [SerializeField] ClickPanel gameOver;
    [SerializeField] BlockManager blockManager;
    [SerializeField] ActionBlock bottomWall;

    private GameState _gameState=GameState.Loading;
    static public GameState gameState
    {
        set
        {
            if (_S._gameState != value)
            {
                _S._gameState = value;
                _S.OnChangeGameState();
            }
        }
    }

    private int _score = 0;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            if (_score != value)
            {
                _score = value;
                scoreText.Score = _score;
            }
        }
            
    }

    
    // シングルトン用の参照
    static GameController _S=null;

    private void Awake()
    {
        if (_S == null)
        {
            _S = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        gameState = GameState.Ready;
    }

    /// <summary>
    /// 状態が変わったらする処理
    /// </summary>
    private void OnChangeGameState()
    {
        switch (_gameState)
        {
            case GameState.Ready:
                gameClear.gameObject.SetActive(false);
                ready.gameObject.SetActive(true);
                ready.OnClickedAction = () => { GameController.gameState = GameState.InGame; };
                Score = 0;
                break;
            case GameState.InGame:
                ready.gameObject.SetActive(false);
                blockManager.OnBlockBroken = () => { Score++; };
                blockManager.OnBlockBrokenAll = OnClear;
                bottomWall.OnCollisionAction = OnGameOver;
                ball.gameObject.SetActive(true);
                break;
            case GameState.GameClear:
                gameClear.gameObject.SetActive(true);
                gameClear.OnClickedAction = ReloadScene;
                break;
            case GameState.GameOver:
                gameOver.gameObject.SetActive(true);
                gameOver.OnClickedAction = ReloadScene;
                break;
            default:
                break;
        }
    }
    private void OnClear()
    {
        Debug.Log("クリア時の処理");
        ball.gameObject.SetActive(false);
        gameState = GameState.GameClear;
    }
    private void OnGameOver()
    {
       gameState = GameState.GameOver;
        bottomWall.gameObject.SetActive(false);
        ball.gameObject.SetActive(false);
    }
    private void  ReloadScene()
    {
        var current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current);
    }
}
