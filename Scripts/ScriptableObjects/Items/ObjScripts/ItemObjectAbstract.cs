using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemObjectAbstract : ScriptableObject
{
    public GameObject prefab;
    public EnumsGame.ItemType type;
    [TextArea(15, 20)]
    public string description;
    public Sprite uiImage;


}
