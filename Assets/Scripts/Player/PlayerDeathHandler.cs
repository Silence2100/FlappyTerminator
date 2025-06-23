using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerShooting _shooting;
    [SerializeField] private GameSession _gameSession;

    private void OnEnable()   => 
        _player.Died += HandleDeath;

    private void OnDisable () => 
        _player.Died -= HandleDeath;

    private void HandleDeath()
    {
        _gameSession.GameOver();
        _movement.enabled = false;
        _shooting.enabled = false;
    }
}