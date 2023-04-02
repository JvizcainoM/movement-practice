using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemCollectedUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _amountOfItem;
    [SerializeField] private Image _itemImage;
    [SerializeField] private Image _rarityOfItemImage;
    [SerializeField] private UnityEvent onCreation;
    [SerializeField] private UnityEvent onIncreaseItemAmount;

    private int _actualAmount;

    public void SetData(ItemsCollected itemCollected)
    {
        transform.name = itemCollected.Item.ItemId.ToString();
        _name.text = itemCollected.Item.ItemName;
        _actualAmount = itemCollected.ItemAmount;
        _itemImage.sprite = itemCollected.Item.ItemSprite;
        _rarityOfItemImage.sprite = itemCollected.Item.RaritySprite;
        
        SetAmountItemFormat();
        
        onCreation?.Invoke();
    }

    public void IncreaseAmount(int amount)
    {
        _actualAmount += amount;
        SetAmountItemFormat();
        onIncreaseItemAmount?.Invoke();
    }
    private void SetAmountItemFormat()
    {
        _amountOfItem.text = "X " + _actualAmount.ToString();
    }
}
