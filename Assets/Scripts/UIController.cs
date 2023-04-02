using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> onPlayerHealthMultiplierChange;
    [SerializeField] private UnityEvent<int> onPlayerReceiveDamage;
    [SerializeField] private UnityEvent<int> onPlayerReceiveHeal;
    [SerializeField] private UnityEvent onPlayerMaxHeal;
    [SerializeField] private UnityEvent<int> onPlayerMaxHealthIncrease;
    [SerializeField] private UnityEvent<int> onPlayerMaxHealthDecrease;
    [SerializeField] private UnityEvent<float> onBossHealthMultiplierChange;
    [SerializeField] private UnityEvent<int> onBossReceiveDamage;
    [SerializeField] private UnityEvent<int> onBossReceiveHeal;
    [SerializeField] private UnityEvent onBossMaxHeal;
    [SerializeField] private UnityEvent<int> onBossMaxHealthIncrease;
    [SerializeField] private UnityEvent<int> onBossMaxHealthDecrease;
    [SerializeField] private UnityEvent<ItemsCollected> onItemRecollected;
    [SerializeField] private UnityEvent onUpQuickMenuPressed;
    [SerializeField] private UnityEvent onDownQuickMenuPressed;
    [SerializeField] private UnityEvent onLeftQuickMenuPressed;
    [SerializeField] private UnityEvent onRightQuickMenuPressed;

    public void PlayerHealthMultiplier(float multiplier)
    {
        onPlayerHealthMultiplierChange?.Invoke(multiplier);
    }
    public void PlayerReceiveDamage(int damage)
    {
        onPlayerReceiveDamage?.Invoke(damage);
    }

    public void PlayerReceiveHeal(int heal)
    {
        onPlayerReceiveHeal?.Invoke(heal);
    }

    public void PlayerFullHeal()
    {
        onPlayerMaxHeal?.Invoke();
    }

    public void PlayerMaxHealthIncrease(int healthIncrease)
    {
        onPlayerMaxHealthIncrease?.Invoke(healthIncrease);
    }

    public void PlayerMaxHealthDecrease(int healthDecrease)
    {
        onPlayerMaxHealthDecrease?.Invoke(healthDecrease);
    }

    public void BossHealthMultiplierchange(float multiplier)
    {
        onBossHealthMultiplierChange?.Invoke(multiplier);
    }
    public void BossReceiveDamage(int damage)
    {
        onBossReceiveDamage?.Invoke(damage);
    }

    public void BossReceiveHeal(int heal)
    {
        onBossReceiveHeal?.Invoke(heal);
    }

    public void BossFullHeal()
    {
        onBossMaxHeal?.Invoke();
    }

    public void BossMaxHealthIncrease(int healthIncrease)
    {
        onBossMaxHealthIncrease?.Invoke(healthIncrease);
    }

    public void BossMaxHealthDecrease(int healthDecrease)
    {
        onBossMaxHealthDecrease?.Invoke(healthDecrease);
    }

    public void PlayerCollectItem(ItemsCollected item)
    {
        onItemRecollected?.Invoke(item);
    }
    
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
