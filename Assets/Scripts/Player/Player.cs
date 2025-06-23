using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public event Action JumpRequested;
    public event Action ShootRequested;
    public event Action Died;

    private Vector3 _startPosition;

    private void Awake() => 
        _startPosition = transform.position;

    public void RequestJump() => 
        JumpRequested?.Invoke();

    public void RequestShoot() => 
        ShootRequested?.Invoke();

    public void NotifyDeath() => 
        Died?.Invoke();

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}