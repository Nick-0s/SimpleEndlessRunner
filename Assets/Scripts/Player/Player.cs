using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    public event UnityAction<int> CoinPicked;
    public event UnityAction Died;
    public event UnityAction HealthChanged;
    public int Health {get; private set;}

    private void Start()
    {
        Health = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Coin>(out Coin coin))
            CoinPicked?.Invoke(coin.Value);
    }

    public int MaxHealth => _maxHealth;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        HealthChanged?.Invoke();

        if (Health <= 0)
            Died?.Invoke();
    }
}
