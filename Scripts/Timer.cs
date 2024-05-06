using UnityEngine;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ToggleSwitch _toggleSwitch;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private bool _isCounting;

    private WaitForSeconds _wait;
    private int _counter = 0;
    private int _switchClick = 0;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(UpdateCounter());
    }

    private void OnEnable()
    {
        _toggleSwitch.Switching += ToggleCounter;
        _counter = 0;
        _switchClick = 0;
    }

    private void OnDisable()
    {
        _toggleSwitch.Switching -= ToggleCounter;
    }

    private void ToggleCounter()
    {
        _switchClick++;

        if (_switchClick % 3 == 0)
        {
            _isCounting = false;
        }
        else
        {
            _isCounting = true;
            _counter += 3;
            DisplayCounter(_counter);
        }
    }

    private IEnumerator UpdateCounter()
    {
        while (true)
        {
            yield return _wait;

            if (_isCounting)
            {
                _counter++;
                DisplayCounter(_counter);
            }
        }
    }

    private void DisplayCounter(int count)
    {
        _text.text = count.ToString();
    }
}
