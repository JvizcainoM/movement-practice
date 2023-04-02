using UnityEngine;

public class HealthBarMax : MonoBehaviour
{
    [SerializeField] private RectTransform _maxHealthBar;
    [SerializeField] private HealthBar _healthBar;

    private float _multiplier;
    private int _maxHealth;
    private float _offSetMinX;

    private bool _somethingToUpdate = false;

    private void Awake()
    {
        _offSetMinX = _maxHealthBar.offsetMin.x;
    }

    private void Update()
    {
        if(_somethingToUpdate)
        {
            _maxHealthBar.sizeDelta = new Vector2(_maxHealth * _multiplier, _maxHealthBar.sizeDelta.y);
            _maxHealthBar.offsetMin = new Vector2(_offSetMinX, _maxHealthBar.offsetMin.y);
            _somethingToUpdate = false;
        }
    }

    public void MaxHealthIncrease(int newMaxHealth)
    {
        _maxHealth = newMaxHealth;
        _healthBar.MaxHealthIncrease(_maxHealth);
        _somethingToUpdate = true;
    }

    public void MaxHealthDecrease(int newMaxHealth)
    {
        _maxHealth = newMaxHealth;
        _healthBar.MaxHealthDecrease(_maxHealth);
        _somethingToUpdate = true;
    }

    public void SetHealthMultiplier(float multiplier)
    {
        _multiplier = multiplier;
        _healthBar.SetHealthMultiplier(multiplier);
    }
}
