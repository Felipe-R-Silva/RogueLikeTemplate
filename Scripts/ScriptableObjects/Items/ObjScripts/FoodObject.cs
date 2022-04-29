using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Data/Items/Food")]
public class FoodObject : ItemObjectAbstract
{
    public int RestoreHealthValue;
    public void Awake()
    {
        type = EnumsGame.ItemType.Food;
    }
}
