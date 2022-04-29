using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryUI : BaseUi
{
    [Separator("Buttons", true)]
    [SerializeField] private Button CloseButton;
    [SerializeField] private Transform InventoryListLayout;

    [Separator("Inventory", true)]
    [SerializeField] private InventoryObject m_Inventory;
    [SerializeField] private Dictionary<ItemObjectAbstract, InventorySlot> m_ItemTypeDisplayed = new Dictionary<ItemObjectAbstract,InventorySlot>();
    [SerializeField] private Dictionary<InventorySlot, GameObject> m_ItemDisplayed = new Dictionary<InventorySlot, GameObject>();
    public override void Initialize()
    {
        base.Initialize();
        CloseButton.onClick.AddListener(delegate { RequestCloseSelf();});

        CreateDisplay();
        EventBus.OnItemCollected += ItemCollectedHandler;
        EventBus.OnRefreshInventoryDisplay += RefreshInventoryHandler; 
    }

    private void RefreshInventoryHandler(EventBus.RefreshInventoryDisplayArgs obj)
    {
        FlushInventory();

        if (obj.inventoryToRefresh == m_Inventory) 
        {
            for (int i = 0; i < m_Inventory.Container.Count; i++)
            {
                if (m_ItemDisplayed.ContainsKey(m_Inventory.Container[i]))
                {
                    m_ItemDisplayed[m_Inventory.Container[i]].GetComponent<UiItem>().Counter.text = m_Inventory.Container[i].Amount.ToString("n0");
                }
                else
                {
                    SpawnitemBundleInInventory(m_Inventory.Container[i]);
                }
            }
        }
    }

    private void FlushInventory() 
    {
        foreach (var uiObject in m_ItemDisplayed)
        {
            Destroy(uiObject.Value);
        }
        m_ItemTypeDisplayed.Clear();
        m_ItemDisplayed.Clear();
    }

    private void ItemCollectedHandler(EventBus.ItemCollectedArgs obj)
    {
        if (m_ItemTypeDisplayed.TryGetValue(obj.ItemSlot.Item,out var slot)) 
        {
            Debug.Log("Grabed A ITEM WE ALREADY HAD");
            //Add more items to inventory bundle
            m_ItemDisplayed[slot].GetComponent<UiItem>().Amount += obj.ItemSlot.Amount;
        }
        else 
        {
            SpawnitemBundleInInventory(obj.ItemSlot);
            Debug.Log("****NEW ITEM****");
            Debug.Log(m_ItemDisplayed[obj.ItemSlot]);
        }
    }


    private void CreateDisplay() 
    {
        for (int i = 0; i < m_Inventory.Container.Count; i++)
        {
            SpawnitemBundleInInventory(m_Inventory.Container[i]);
        }
    }
    private void SpawnitemBundleInInventory(InventorySlot itemBundle) 
    {
        var obj = Instantiate(itemBundle.Item.prefab, Vector3.zero, Quaternion.identity, InventoryListLayout);
        //obj.GetComponent<RectTransform>().localPosition = GetPosition(i); // Sets Object inside grid
        obj.GetComponentInChildren<UiItem>().Amount = itemBundle.Amount;
        obj.GetComponentInChildren<UiItem>().Image.sprite = itemBundle.Item.uiImage;
        m_ItemTypeDisplayed.Add(itemBundle.Item, itemBundle);// item -> bundle
        m_ItemDisplayed.Add(itemBundle,obj);// bundle -> UIGameObject
    }
    public Vector3 GetPosition(int i) 
    {
        int X_XPACE_BETWEEN_ITEM = 12;
        int NUMBER_OF_COLUMN = 5;
        int Y_SPACE_BETWEEN_ITEMS = 12;
        int X_START = 0;
        int Y_START = 0;

        return new Vector3(X_START + (X_XPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
    }
}
