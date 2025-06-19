using System;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static event Action OnGameStart;
    public static event Action OnGameOver;

    private void Awake() => Time.timeScale = 0f;

    public void StartGame()
    {
        Time.timeScale = 1f;
        OnGameStart?.Invoke();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        OnGameOver?.Invoke();
    }
}