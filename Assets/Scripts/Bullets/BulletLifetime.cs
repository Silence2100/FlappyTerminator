using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class BulletLifetime : MonoBehaviour
{
    [SerializeField] private float _lifetime = 2f;

    public event Action OnExpired;

    private Coroutine _coroutine;

    private void OnEnable() => 
        _coroutine = StartCoroutine(Lifetime());

    private void OnDisable() => 
        StopCoroutine(_coroutine);

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(_lifetime);
        OnExpired?.Invoke();
    }
}