using UnityEngine;
using MyBox;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="New_Player_Data",menuName ="Data/PlayerData")]
[System.Serializable]
public class SavedPlayerData : ScriptableObject
{
    [Separator("Player", true)]
    [SerializeField] private string m_PlayerName;
    [SerializeField] private EnumsGame.PlayerColor m_Color;
    [SerializeField] private int m_PlayerLevel;
    [SerializeField] private int m_Health;//Player Stats Class
    [Separator("Location", true)]
    [SerializeField] public Vector3 m_PlayerSpawnPoint;
    [Separator("UI", true)]
    [SerializeField] public List<_UiMaster.UiScreen> ActiveUIs;//Player Stats Class

    public string PlayerName { get => m_PlayerName; set => m_PlayerName = value; }
}
