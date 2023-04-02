using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform _healthBar;
    [SerializeField] private float _animationSpeed = 1;
    [SerializeField] private UnityEvent OnHealthZero;
    
    private float _multiplier;
    private int _actualHealth;
    private int _maxHealth;
    private float _offSetMinX;
    private float _actualHealthBarSizeX;
    private float _newHealthBarSizeX;
    
    private void Awake()
    {
        _offSetMinX = _healthBar.offsetMin.x;
    }
    private void Update()
    {//For testing purposes, IEnumerator for intended use
       
        _actualHealthBarSizeX = _healthBar.sizeDelta.x;

        if ((_actualHealth * _multiplier) + 2f > (int)_actualHealthBarSizeX &&
            (_actualHealth * _multiplier) - 2f < (int)_actualHealthBarSizeX)
        {
            return;
        }
        
        
        if (_actualHealthBarSizeX > _actualHealth * _multiplier)
        {
            _newHealthBarSizeX = _actualHealthBarSizeX + (_animationSpeed * -1);
        }
        else
        {
            _newHealthBarSizeX = _actualHealthBarSizeX + _animationSpeed;
        }

        _healthBar.sizeDelta = new Vector2(_newHealthBarSizeX , _healthBar.sizeDelta.y);
        _healthBar.offsetMin = new Vector2(_offSetMinX, _healthBar.offsetMin.y);
    }

    public void InitializeHealthBar()
    {
        // StartCoroutine(AnimateHealthBar());
    }

    // IEnumerator AnimateHealthBar() //Update for testing, IEnumerator for intended use
    // {
    //     while (GameManager.Instance.GameState = GameManager.GameState.Playing) //or something like that
    //     {
    //         _actualHealthBarSizeX = _healthBar.sizeDelta.x;
    //         if ((_actualHealth * _multiplier) + 2f > (int)_actualHealthBarSizeX &&
    //             (_actualHealth * _multiplier) - 2f < (int)_actualHealthBarSizeX)
    //         {
    //                 yield return null;
    //         }
    //         if (_actualHealthBarSizeX > _actualHealth * _multiplier)
    //         {
    //             _newHealthBarSizeX = _actualHealthBarSizeX + (_animationSpeed * -1);
    //         }
    //         else
    //         {
    //             _newHealthBarSizeX = _actualHealthBarSizeX + _animationSpeed;
    //         }
    //     
    //         _healthBar.sizeDelta = new Vector2(_newHealthBarSizeX, _healthBar.sizeDelta.y);
    //         _healthBar.offsetMin = new Vector2(_offSetMinX, _healthBar.offsetMin.y);
    //         yield return null;
    //     }
    // }

    public void MaxHealthIncrease(int newMaxHealth)
    {
        _maxHealth = newMaxHealth;
        
    }

    public void MaxHealthDecrease(int newMaxHealth)
    {
        _maxHealth = newMaxHealth;
        
        CheckHealthNotHigherThanMaxHealth();
    }

    public void ReceiveHeal(int heal)
    {
        _actualHealth += heal;
        
        CheckHealthNotHigherThanMaxHealth();
    }

    public void ReceiveDamage(int damage)
    {
        _actualHealth -= damage;
        
        if (_actualHealth <= 0)
        {
            _actualHealth = 0;
            OnHealthZero?.Invoke();
        }
    }

    public void ReceiveMaxHeal()
    {
        _actualHealth = _maxHealth;
    }

    public void SetHealthMultiplier(float multiplier)
    {
        _multiplier = multiplier;
    }

    private void CheckHealthNotHigherThanMaxHealth()
    {
        if (_actualHealth > _maxHealth)
        {
            _actualHealth = _maxHealth;
        }
    }
    
}
