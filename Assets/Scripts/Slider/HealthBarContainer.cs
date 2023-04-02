using UnityEngine;

public class HealthBarContainer : MonoBehaviour
{
    [SerializeField] private RectTransform _maxHealthBarContainer;
    [SerializeField] private float _manualOffset = 10;
    [SerializeField] private HealthBarMax _healthBarMax;
    [SerializeField] private float _multiplier = 1;

    private float _offSetMinX;
    private int _maxHealth;

    private bool _somethingToUpdate = false;

    private void Awake()
    {
        _offSetMinX = _maxHealthBarContainer.offsetMin.x;
        _healthBarMax.SetHealthMultiplier(_multiplier);
    }

    private void Update()
    {
        if(_somethingToUpdate)
        {
            _maxHealthBarContainer.sizeDelta = new Vector2((_maxHealth * _multiplier) + _manualOffset,
                _maxHealthBarContainer.sizeDelta.y);
            _maxHealthBarContainer.offsetMin = new Vector2(_offSetMinX, _maxHealthBarContainer.offsetMin.y);
            _somethingToUpdate = false;
        }
    }

    public void MaxHealthIncrease(int healthIncrease)
    {
        _maxHealth += healthIncrease;
        _healthBarMax.MaxHealthIncrease(_maxHealth);
        _somethingToUpdate = true;
    }

    public void MaxHealthDecrease(int healthDrecrease)
    {
        _maxHealth -= healthDrecrease;
        _healthBarMax.MaxHealthDecrease(_maxHealth);
        _somethingToUpdate = true;
    }

    public void SetHealthBarMultiplier(float multiplier)
    {
        _multiplier = multiplier;
        _healthBarMax.SetHealthMultiplier(multiplier);
    }
}
