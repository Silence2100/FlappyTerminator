using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.RaiseJump();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _player.RaiseShoot();
        }
    }
}