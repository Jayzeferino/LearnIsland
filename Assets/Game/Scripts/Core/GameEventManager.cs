using System;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;

    private void Awake()
    {
        instance = this;

    }

    public event Action<string, int> OnTermoButtonPressedHandler;
    public void TermoButtonPressed(string letter, int id)
    {
        OnTermoButtonPressedHandler?.Invoke(letter, id);
    }

    public event Action<bool, int> OnButtonChangeColorHandler;
    public void ChangedButtonColor(bool success, int id)
    {
        OnButtonChangeColorHandler?.Invoke(success, id);
    }

    // public event Action<bool> OnButtonActionPressedHandler;
    // public void OnButtonActionPressed(bool pressed)
    // {
    //     OnButtonActionPressedHandler?.Invoke(pressed);
    // }



}