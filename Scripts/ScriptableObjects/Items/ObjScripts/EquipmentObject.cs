using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Data/Items/Equipment")]
public class EquipmentObject : ItemObjectAbstract
{
    public float AtkBonus;
    public float DefenceBonus;

    public void Awake()
    {
        type = EnumsGame.ItemType.Equipment;
    }
}
