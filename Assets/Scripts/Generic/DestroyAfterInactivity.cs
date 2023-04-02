using UnityEngine;
using UnityEngine.Events;

public class DestroyAfterInactivity : MonoBehaviour
{
    [SerializeField] float _maxTimeAlive = 3;
    [SerializeField] private float _actualTimeToDie;
    [SerializeField] private UnityEvent<int> onDestroy;
    private bool _canStart;
    
    public void NewInteraction()
    {
        _actualTimeToDie = _maxTimeAlive;
        _canStart = true;
    }
    private void Update()
    {
        if (_canStart)
        {
            _actualTimeToDie -= Time.deltaTime;
            if (_actualTimeToDie <= 0)
            {
                onDestroy?.Invoke(int.Parse(transform.name));
                Destroy(gameObject);
            }
        }
    }

    public float GetTimeToDestroy()
    {
        return _actualTimeToDie;
    }
}
