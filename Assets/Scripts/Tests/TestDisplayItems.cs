using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class TestDisplayItems : MonoBehaviour
{
    [SerializeField] private bool _createNewItemCollected = false;
    [SerializeField] private UnityEvent<ItemsCollected> onCreateItemcollected;
    [SerializeField] private Sprite _testSprite;


    private void Update()
    {
        if (_createNewItemCollected)
        {
            Items i = new Items();
            i.ItemId = Random.Range(0, 6);
            i.Rarity = 0;
            i.ItemName = "TestItem " + i.ItemId.ToString();
            i.ItemSprite = _testSprite;
            i.RaritySprite = _testSprite;

            ItemsCollected ic = new ItemsCollected();
            ic.Item = i;
            ic.ItemAmount = Random.Range(1, 10);
            onCreateItemcollected?.Invoke(ic);
            _createNewItemCollected = false;

        }
    }
}
