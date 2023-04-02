using UnityEngine;
using UnityEngine.Events;

public class QuickActionInteraction : MonoBehaviour
{
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
}
