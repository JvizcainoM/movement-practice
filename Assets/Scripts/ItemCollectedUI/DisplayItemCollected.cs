using UnityEngine;
using UnityEngine.UI;

public class DisplayItemCollected : MonoBehaviour
{
    [SerializeField] private GameObject _itemList;
    [SerializeField] private GameObject _itemCollectedUIPrefab;
    [SerializeField] private Image _backGround;
    [SerializeField] private int _maxItemsOnDisplay;

    private void Update()
    {
        if (_itemList.transform.childCount == 0 )
        {
            _backGround.enabled = false;
        }
        else
        {
            _backGround.enabled = true;
        }
    }

    public void NewItemCollected(ItemsCollected itemCollected)
    {
        
        Transform child = _itemList.transform.Find(itemCollected.Item.ItemId.ToString());
        if (child != null)
        {
            if (child.TryGetComponent(out ItemCollectedUI itemScript))
            {
                itemScript.IncreaseAmount(itemCollected.ItemAmount);
            }
            return;
        }

        CheckAmountOfItemsDisplayed();
        CreateItemToDisplay(itemCollected);
    }

    private void CreateItemToDisplay(ItemsCollected itemCollected)
    {
        GameObject newItem = Instantiate(_itemCollectedUIPrefab, _itemList.transform);
        if (newItem.TryGetComponent(out ItemCollectedUI newItemScript))
        {
            newItemScript.SetData(itemCollected);
        }
    }

    private void CheckAmountOfItemsDisplayed()
    {
        if (_itemList.transform.childCount >= _maxItemsOnDisplay)
        {
            int objectToDestroy = 0;
            float timeToDestroy = float.MaxValue;
            for (int i = 0; i < _itemList.transform.childCount; i++)
            {
                if (_itemList.transform.GetChild(i).TryGetComponent(out DestroyAfterInactivity childScript))
                {
                    if (childScript.GetTimeToDestroy() < timeToDestroy)
                    {
                        objectToDestroy = i;
                        timeToDestroy = childScript.GetTimeToDestroy();
                    }
                }
            }
            Destroy(_itemList.transform.GetChild(objectToDestroy).gameObject);
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // public void CollectNewItem(ItemsCollected itemCollected)
    // {
    //     bool itemSaved = false;
    //     foreach (ItemsCollected IC in _itemsCollected)
    //     {
    //         if (IC.Item.ItemId == itemCollected.Item.ItemId)
    //         {
    //             Transform goChild = _itemList.transform.Find(itemCollected.Item.ItemId.ToString());
    //             if (goChild.TryGetComponent(out ItemCollectedUI itemScript))
    //             {
    //                 itemScript.IncreaseAmount(itemCollected.ItemAmount);
    //             }
    //             itemSaved = true;
    //             break;
    //         }
    //     }
    //
    //     if (!itemSaved)
    //     {
    //         GameObject newItem = Instantiate(_itemCollectedUIPrefab);
    //         newItem.transform.parent = _itemList.transform;
    //         if (newItem.TryGetComponent(out ItemCollectedUI itemScript))
    //         {
    //             itemScript.SetData(itemCollected);
    //         }
    //         _itemsCollected.Add(itemCollected);
    //     }
    // }
    //
    // public void RemoveFromList(int itemId)
    // {
    //     foreach (ItemsCollected item in _itemsCollected)
    //     {
    //         if (item.Item.ItemId == itemId)
    //         {
    //             _itemsCollected.Remove(item);
    //             break;
    //         }
    //     }
    // }
}
