using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;


public class WaveDisplayer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _spawner.WaveNumberChanged += OnWaveNumberChanged;
    }

    private void OnWaveNumberChanged()
    {
        DisplayWaveNumber();
    }

    public void DisplayWaveNumber()
    {
        string text = "Лучшая волна: " + _spawner.WaveCount.ToString();
        _text.text = text;
    }
}
