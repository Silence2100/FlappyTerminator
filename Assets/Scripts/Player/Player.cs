using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public event Action JumpRequested;
    public event Action ShootRequested;
    public event Action Died;

    private Vector3 _startPosition;

    private void Awake() => _startPosition = transform.position;

    public void RaiseJump() => JumpRequested?.Invoke();
    public void RaiseShoot() => ShootRequested?.Invoke();
    public void RaiseDeath() => Died?.Invoke();

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}