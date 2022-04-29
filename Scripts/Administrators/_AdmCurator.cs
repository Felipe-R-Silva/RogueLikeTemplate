using System.Collections;
using UnityEngine;
using MyBox;

public class _AdmCurator : MonoBehaviour
{
    [Header("\n" +
        "All this elements are for search purpose,\n" +
        " this class contains all of the listed items" +
        "\n")]
    [Separator("All Game Enums",true)]
    [SerializeField] private EnumsGame.Scenes m_Scenes;
    [SerializeField] private EnumsGame.PlayerColor m_Colors;
    [SerializeField] private EnumsGame.ItemType m_Items;
}
public static class EnumsGame
{
    //Scenes Enum must have the exact name as the scene Name
    public enum Scenes
    {
        SCN_GameMasters,
        SCN_MainMenu,
        SCN_TestStartingLevel,
    }

    public enum PlayerColor
    {
        Black,
        Pink,
        Yellow,
        Red,
        Green,
        Blue,
        White,
    }
    public enum ItemType
    {
        Food,
        Equipment,
        Default,
    }
}
