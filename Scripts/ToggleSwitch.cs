using System;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    public event Action Switching;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Switching?.Invoke();
        }
    }
}
