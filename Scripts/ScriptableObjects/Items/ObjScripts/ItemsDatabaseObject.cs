using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item Database",menuName = "Data/Inventory System/Database")]

public class ItemsDatabaseObject : ScriptableObject,ISerializationCallbackReceiver
{
    public ItemObjectAbstract[] Items;
    public Dictionary<ItemObjectAbstract, int> GetId = new Dictionary<ItemObjectAbstract, int>();
    public Dictionary<int, ItemObjectAbstract> GetItem = new Dictionary<int,ItemObjectAbstract>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<ItemObjectAbstract, int>();
        GetItem = new Dictionary<int, ItemObjectAbstract>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
