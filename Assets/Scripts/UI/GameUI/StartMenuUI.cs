using UnityEngine;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private Button _playButton;
    [SerializeField] private GameSession _gameSession;

    private void Awake() => _startPanel.SetActive(true);

    private void OnEnable()
    {
        _playButton.onClick.AddListener(_gameSession.StartGame);
        GameSession.OnGameStart += HandleGameStart;
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(_gameSession.StartGame);
        GameSession.OnGameStart -= HandleGameStart;
    }

    private void HandleGameStart()
    {
        _startPanel.SetActive(false);
    }
}