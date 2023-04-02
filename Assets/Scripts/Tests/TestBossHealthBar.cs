using UnityEngine;
using UnityEngine.Events;

public class TestBossHealthBar : MonoBehaviour
{
    [Range(0, 1500)][SerializeField] private int _maxHealth;
    [Range(0, 1500)] [SerializeField] private int _health;

    private int _actualMaxHealth;
    private int _actualHealth;

    [SerializeField] private UnityEvent<int> onMaxHealthIncrease;
    [SerializeField] private UnityEvent<int> onMaxHealthDecrease;
    [SerializeField] private UnityEvent<int> onHeal;
    [SerializeField] private UnityEvent<int> onDamage;

    private void Awake()
    {
        _actualHealth = _health;
        _actualMaxHealth = _maxHealth;
    }

    private void Update()
    {
        if(_maxHealth != _actualMaxHealth)
        {
            if(_maxHealth > _actualMaxHealth)
            {
                onMaxHealthIncrease?.Invoke(_maxHealth - _actualMaxHealth);
                _health += _maxHealth - _actualMaxHealth;
                _actualHealth = _health;
                _actualMaxHealth = _maxHealth;
            }
            else
            {
                onMaxHealthDecrease?.Invoke(_actualMaxHealth - _maxHealth);
                _actualMaxHealth = _maxHealth;
            }
        }

        if (_health != _actualHealth)
        {
            if (_health > _actualHealth)
            {
                onHeal?.Invoke(_health - _actualHealth);
                _actualHealth = _health;
            }
            else
            {
                onDamage?.Invoke(_actualHealth - _health);
                _actualHealth = _health;
            }
        }
        CheckHealthNotHigherThanMaxHealth();
    }

    public void HealthChange(int newHealth)
    {
        _health = newHealth;
        _actualHealth = _health;
    }
    
    private void CheckHealthNotHigherThanMaxHealth()
    {
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
            _actualHealth = _maxHealth;
        }
    }
}
