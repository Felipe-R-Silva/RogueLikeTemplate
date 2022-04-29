using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

[CreateAssetMenu(fileName = "New_Location_Data", menuName = "Data/LocationData")]
[System.Serializable]
public class SavedLocationData : ScriptableObject
{
    [Separator("Location", true)]
    [SerializeField] public EnumsGame.Scenes m_SceneEnum;
}
