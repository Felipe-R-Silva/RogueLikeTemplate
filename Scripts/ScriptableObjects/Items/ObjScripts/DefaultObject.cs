using UnityEngine;

[CreateAssetMenu(fileName ="New Default Object", menuName ="Data/Items/Default")]
public class DefaultObject : ItemObjectAbstract
{
    public void Awake()
    {
        type = EnumsGame.ItemType.Default;
    }
}
