using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(TMP_Text))]
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Score _score;
    private TMP_Text _display;

    private void Start()
    {
        _display = GetComponent<TMP_Text>();
        RefreshDisplay();
    }

    private void OnEnable()
    {
        _score.Changed += RefreshDisplay;        
    }

    private void OnDisable()
    {
        _score.Changed -= RefreshDisplay;
    }

    private void RefreshDisplay()
    {
        _display.text = _score.Value.ToString();
    }
}
