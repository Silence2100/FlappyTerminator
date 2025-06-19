using UnityEngine;
using TMPro;

[RequireComponent(typeof(ScoreCounter))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private ScoreCounter _counter;

    private void Awake()
    {
        _counter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _counter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }
}