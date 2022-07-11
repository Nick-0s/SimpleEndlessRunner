using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Color _lowHealthColor;
    [SerializeField] private Color _maxHealthColor;
    [SerializeField] private TMP_Text _textOfHealth;

    private void Start()
    {
        _textOfHealth.text = _player.MaxHealth.ToString();
        _textOfHealth.color = _maxHealthColor;
    }

    private void OnEnable()
    {
        _player.HealthChanged += RefreshHealthDisplay;        
    }

    private void OnDisable()
    {
        _player.HealthChanged -= RefreshHealthDisplay;
    }

    private void RefreshHealthDisplay()
    {
        _textOfHealth.text = _player.Health.ToString();
        _textOfHealth.color = Color.Lerp(_lowHealthColor, _maxHealthColor, (float)_player.Health / _player.MaxHealth);
    }
}
