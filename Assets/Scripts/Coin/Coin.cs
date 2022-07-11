using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    public int Value {get; private set;} = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }
}
