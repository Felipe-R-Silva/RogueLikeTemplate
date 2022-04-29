using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private InventorySlot m_ItemObject;
    public InventorySlot ItemObject { get => m_ItemObject; set => m_ItemObject = value; }
}
