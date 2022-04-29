using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

/*
 * Save File Tutorial "Coding With Unity" 
https://www.youtube.com/watch?v=232EqU1k9yQ
*/

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Data/Inventory System/Inventory")]
public class InventoryObject : ScriptableObject,ISerializationCallbackReceiver
{
    public string SavePath;
    private ItemsDatabaseObject Database;
    public List<InventorySlot> Container = new List<InventorySlot>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        Database = (ItemsDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset",typeof(ItemsDatabaseObject));
#else
        Database = Resources.Load<ItemsDatabaseObject>("Database");
#endif
    }

    public void AddItem(ItemObjectAbstract _item,int _amount) 
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].Item == _item) 
            {
                Container[i].AddAmount(_amount);
                return;
            }
        }
            Container.Add(new InventorySlot(Database.GetId[_item], _item, _amount));
    }

    public void AddItem(InventorySlot _ItemObject)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].Item == _ItemObject.Item)
            {
                Container[i].AddAmount(_ItemObject.Amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(Database.GetId[_ItemObject.Item], _ItemObject.Item, _ItemObject.Amount));
        }

    }

    public void Save() 
    {
        string saveData = JsonUtility.ToJson(this,true);
        Debug.Log(saveData);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath,SavePath));
        bf.Serialize(file,saveData);
        file.Close();
    }

    public void Load() 
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, SavePath))) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, SavePath),FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);

            string saveData = JsonUtility.ToJson(this, true);
            Debug.Log(saveData);

            file.Close();
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
        {
            Container[i].Item = Database.GetItem[Container[i].ID];
        }
        EventBus.RaiseRefreshInventoryDisplay(this);//Refreshes all wildows that contains this data
    }

    public void OnBeforeSerialize()
    {
    }
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObjectAbstract Item;
    public int Amount;

    public InventorySlot(int _id, ItemObjectAbstract _item, int _amount) 
    {
        ID = _id;
        Item = _item;
        Amount = _amount;
    }

    public void AddAmount(int value) 
    {
        Amount += value;
    }
}
