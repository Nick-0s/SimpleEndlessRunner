using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Player player))
            player.TakeDamage(_damage);

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
