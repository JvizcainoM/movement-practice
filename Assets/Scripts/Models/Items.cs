using UnityEngine;

public class Items 
{
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public Sprite ItemSprite { get; set; }
    public Sprite RaritySprite { get; set; }
    public int Rarity { get; set; } //maybe enum ?
}
