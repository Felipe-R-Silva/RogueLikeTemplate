using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using System;
using DG.Tweening;
public class _UiMaster : _Master
{
    public enum UiScreen
    {
        Null,
        MainMenu,
        SaveSlots,
        Settings,
        Confirmation,
        NewGame,
        Inventory,
        GameCreator,
    }
    public enum TransitionOutType
    {
        ExitToRight,
        ExitToLeft,
        ExitUp,
        ExitDown,
        Disapear
    }
    public enum TransitionInType
    {
        EnterfromRight,
        EnterfromLeft,
        EnterfromUp,
        EnterfromDown,
        Apear
    }

    [Separator("Registerd UIs", true)]
    [ReadOnly][SerializeField] private List<UiInfo> FoundUis;
    private Dictionary<UiScreen, UiInfo> m_FindCanvasById;

    [Separator("Active UIs", true)]
    [SerializeField][ReadOnly] private List<UiScreen> m_ActiveUis;

    public override void CustomInitializationAnex()
    {
        DOTween.Init();// Initialize DoTween For Project

        foreach (Transform child in transform)
        {
            var baseUi = child.GetComponent<BaseUi>();
            if (baseUi == null) 
            { 
                Debug.LogError("A Child With No UI element Detected ");
                continue;
            }
            baseUi.Initialize();
            FoundUis.Add(baseUi.Info);
        }

        m_FindCanvasById = new Dictionary<UiScreen, UiInfo>();
        foreach (var item in FoundUis)
        {
            m_FindCanvasById.Add(item.Id, item);
        }
        EventBus.OnOpenUI += OpenUI;
        EventBus.OnCloseUI += CloseUI;
    }

    private void OnDestroy()
    {
        EventBus.OnOpenUI -= OpenUI;
        EventBus.OnCloseUI -= CloseUI;
    }

    #region Class Methods
    public void OpenUI(EventBus.OpenUIArgs window)
    {
        var Ui = m_FindCanvasById[window.ID];//Get window info
        OpenUI(Ui);
    }
    private void OpenUI(UiInfo Ui)
    {
        Ui.Logic.StartInTransition();
        m_ActiveUis.Add(Ui.Id);
    }

    public void CloseUI(EventBus.CloseUIArgs window)
    {
        var Ui = m_FindCanvasById[window.ID];
        CloseUI(Ui);
    }
    private void CloseUI(UiInfo Ui) 
    {
        Ui.Logic.StartOutTransition();
        m_ActiveUis.Remove(Ui.Id);
    }
    public void HideAll(UiScreen HideAllExeptThis = UiScreen.Null)
    {
        //Hides all windows
    }
    public void MatchOpenAndClosedUIs(List<UiScreen> targetToMirror) 
    {
        //Stupid Ineficient fix later*************************************************************************
        //Create some bether script to go true all of them and see what will be removed and what will be added
        List<UiInfo> MarkedToClose =  new List<UiInfo>();//Close not in use
        for (int i = 0; i < m_ActiveUis.Count; i++)
        {
            if (!targetToMirror.Contains(m_ActiveUis[i]))
            {
                MarkedToClose.Add(m_FindCanvasById[m_ActiveUis[i]]);
            }
        }
        foreach (var item in MarkedToClose)
        {
            CloseUI(item);
        }
        //Open the ones marked as in use
        List<UiInfo> MarkedToOpen = new List<UiInfo>();
        for (int i = 0; i < targetToMirror.Count; i++)
        {
            Debug.Log(targetToMirror[i] + "MarkedToOpen =" + !m_ActiveUis.Contains(targetToMirror[i]));
            if (!m_ActiveUis.Contains(targetToMirror[i]))
            {
                MarkedToOpen.Add(m_FindCanvasById[targetToMirror[i]]);
            }
        }
        foreach (var item in MarkedToOpen)
        {
            OpenUI(item);
        }
    }
    #endregion

    #region Auxiliar Methods
    #endregion
}

[System.Serializable]
public class UiInfo
{
    [SerializeField] private _UiMaster.UiScreen m_Id;
    [SerializeField] private _UiMaster.TransitionInType m_InTransition;
    [ConditionalField(nameof(m_InTransition), true, _UiMaster.TransitionInType.Apear)]
    [SerializeField] private float m_InTime;
    [SerializeField] private _UiMaster.TransitionOutType m_OutTransiton;
    [ConditionalField(nameof(m_OutTransiton), true, _UiMaster.TransitionOutType.Disapear)]
    [SerializeField] private float m_OutTime;
    [SerializeField] private Canvas m_MainCanvas;
    [SerializeField] private BaseUi m_Logic;

    public _UiMaster.UiScreen Id { get => m_Id; set => m_Id = value; }
    public Canvas Canvas { get => m_MainCanvas; set => m_MainCanvas = value; }
    public _UiMaster.TransitionInType In { get => m_InTransition; set => m_InTransition = value; }
    public _UiMaster.TransitionOutType Out { get => m_OutTransiton; set => m_OutTransiton = value; }
    public BaseUi Logic { get => m_Logic; set => m_Logic = value; }
    public float InTime { get => m_InTime; set => m_InTime = value; }
    public float OutTime { get => m_OutTime; set => m_OutTime = value; }
}
