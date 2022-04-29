using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField]private InventoryObject m_inventory;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.TryGetComponent(out Item item))
        {
            m_inventory.AddItem(item.ItemObject);
            EventBus.RaiseItemCollected(item.ItemObject);
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Game Saved");
            m_inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Game Loaded");
            m_inventory.Load();
        }
    }
    private void OnApplicationQuit()
    {
        m_inventory.Container.Clear();
    }
}
