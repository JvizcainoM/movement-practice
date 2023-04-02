using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimateQuickButtonMenu : MonoBehaviour
{
    [SerializeField] private GameObject _animate;
    [SerializeField] private float _animationTime = 1;
    private float _time;
    
    public void StartAnimation()
    {
        _animate.SetActive(true);
        _time = _animationTime;

        StartCoroutine(AnimationRoutine());
    }

    IEnumerator AnimationRoutine()
    {
        while (_time > 0)
        {
            _time -= Time.deltaTime;
            yield return null;
        }

        _animate.SetActive(false);
    }
}
