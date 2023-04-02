using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TestInputs : MonoBehaviour
{
    [SerializeField] private InputAction _actionQuickUp;
    [SerializeField] private InputAction _actionQuickDown;
    [SerializeField] private InputAction _actionQuickLeft;
    [SerializeField] private InputAction _actionQuickRight;
    [SerializeField] private UnityEvent onUpQuickMenuPressed;
    [SerializeField] private UnityEvent onDownQuickMenuPressed;
    [SerializeField] private UnityEvent onLeftQuickMenuPressed;
    [SerializeField] private UnityEvent onRightQuickMenuPressed;
    

    public void AnimateUpQuickMenu()
    {
        onUpQuickMenuPressed?.Invoke();
    }

    public void AnimateDownQuickMenu()
    {
        onDownQuickMenuPressed?.Invoke();
    }

    public void AnimateLeftQuickMenu()
    {
        onLeftQuickMenuPressed?.Invoke();
    }

    public void AnimateRightQuickMenu()
    {
        onRightQuickMenuPressed?.Invoke();
    }

    private void Start()
    {
        _actionQuickUp.performed += _ => AnimateUpQuickMenu();
        _actionQuickDown.performed += _ => AnimateDownQuickMenu();
        _actionQuickLeft.performed += _ => AnimateLeftQuickMenu();
        _actionQuickRight.performed += _ => AnimateRightQuickMenu();
    }

    private void OnEnable()
    {
        _actionQuickUp.Enable();
        _actionQuickDown.Enable();
        _actionQuickLeft.Enable();
        _actionQuickRight.Enable();
    }
}
