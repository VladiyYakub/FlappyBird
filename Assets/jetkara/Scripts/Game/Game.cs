using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGeneration _pipeGeneration;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnDisable()
    {
        _startScreen.playNutttonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnEnable()
    {
        _startScreen.playNutttonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();        
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _pipeGeneration.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
