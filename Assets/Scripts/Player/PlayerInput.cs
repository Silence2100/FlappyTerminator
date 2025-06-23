using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _shootKey = KeyCode.F;
    
    public event Action JumpPerformed;
    public event Action ShootPerformed;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            JumpPerformed?.Invoke();
        }

        if (Input.GetKeyDown(_shootKey))
        {
            ShootPerformed?.Invoke();
        }
    }
}