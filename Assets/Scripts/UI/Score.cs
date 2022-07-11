using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    private int _value;
    public event UnityAction Changed;

    private void Start()
    {
        _player.CoinPicked += Increase;
        _value = 0;
    }

    public int Value => _value;

    public void Increase(int value)
    {
        _value += value;
        Changed?.Invoke();
    }
}
