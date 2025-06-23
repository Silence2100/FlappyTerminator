using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameSession _gameSession;

    private void Awake() => 
        _gameOverPanel.SetActive(false);

    private void OnEnable()
    {
        _gameSession.OnGameOver += Show;
        _restartButton.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
        _gameSession.OnGameOver -= Show;
        _restartButton.onClick.RemoveListener(Restart);
    }

    private void Show() => _gameOverPanel.SetActive(true);

    private void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}