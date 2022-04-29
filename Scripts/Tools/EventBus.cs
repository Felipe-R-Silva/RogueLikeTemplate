using UnityEngine;
using System;
public class EventBus : MonoBehaviour
{
    #region Example

    #region Argumentless Example
    public static Action OnArgumentlessExample;
    public static void RaiseArgumentlessExample()
    {
        OnArgumentlessExample?.Invoke();
    }
    #endregion

    #region Argumentful Example
    public struct ArgumentfulExampleEventArgs
    {
        public readonly bool Value;

        public ArgumentfulExampleEventArgs(bool value)
        {
            Value = value;
        }
    }
    public static Action<ArgumentfulExampleEventArgs> OnArgumentfulExample;
    public static void RaiseArgumentfulExample(bool value)
    {
        OnArgumentfulExample?.Invoke(new ArgumentfulExampleEventArgs(value));
    }
    #endregion

    #endregion

    #region UI
    #region Open UI
    public struct OpenUIArgs
    {
        public readonly _UiMaster.UiScreen ID;
        public OpenUIArgs(_UiMaster.UiScreen wValue)
        {
            ID = wValue;
        }
    }
    public static Action<OpenUIArgs> OnOpenUI;
    public static void RaiseOpenUI(_UiMaster.UiScreen wValue)
    {
        OnOpenUI?.Invoke(new OpenUIArgs(wValue));
    }
    #endregion

    #region Close UI
    public struct CloseUIArgs
    {
        public readonly _UiMaster.UiScreen ID;
        public CloseUIArgs(_UiMaster.UiScreen wValue)
        {
            ID = wValue;
        }
    }
    public static Action<CloseUIArgs> OnCloseUI;
    public static void RaiseCloseUI(_UiMaster.UiScreen wValue)
    {
        OnCloseUI?.Invoke(new CloseUIArgs(wValue));
    }
    #endregion
    #endregion

    #region SaveLoad
    #region Load Game
    public struct LoadGameArgs
    {
        public int SaveiD;
        public LoadGameArgs(int idValue)
        {
            SaveiD = idValue;
        }
    }
    public static Action<LoadGameArgs> OnLoadGame;
    public static void RaiseLoadGame(int idValue)
    {
        OnLoadGame?.Invoke(new LoadGameArgs(idValue));
    }
    #endregion

    #region Create New Save
    public struct CreateNewSaveArgs
    {
        public int Difficulty;
        public CreateNewSaveArgs(int dValue)
        {
            Difficulty = dValue;
        }
    }
    public static Action<CreateNewSaveArgs> OnCreateNewSave;
    public static void RaiseCreateNewSave(int dValue)
    {
        OnCreateNewSave?.Invoke(new CreateNewSaveArgs(dValue));
    }
    #endregion

    #region RefreshInventoryDisplay
    public struct RefreshInventoryDisplayArgs
    {
        public readonly InventoryObject inventoryToRefresh;

        public RefreshInventoryDisplayArgs(InventoryObject value)
        {
            inventoryToRefresh = value;
        }
    }
    public static Action<RefreshInventoryDisplayArgs> OnRefreshInventoryDisplay;
    public static void RaiseRefreshInventoryDisplay(InventoryObject value)
    {
        OnRefreshInventoryDisplay?.Invoke(new RefreshInventoryDisplayArgs(value));
    }
    #endregion

    #endregion

    #region Game
    #region ItemCollected
    public struct ItemCollectedArgs
    {
        public readonly InventorySlot ItemSlot;
        public ItemCollectedArgs(InventorySlot iValue)
        {
            ItemSlot = iValue;
        }
    }
    public static Action<ItemCollectedArgs> OnItemCollected;
    public static void RaiseItemCollected(InventorySlot iValue)
    {
        OnItemCollected?.Invoke(new ItemCollectedArgs(iValue));
    }
    #endregion
    #endregion
}
