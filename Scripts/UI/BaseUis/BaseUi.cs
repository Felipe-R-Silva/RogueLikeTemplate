using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using DG.Tweening;
using System;

public class BaseUi : MonoBehaviour
{
    [Separator("BaseUi",true)]
    [SerializeField] protected UiInfo m_Data;
    [SerializeField] RectTransform m_RectTransform;
    [SerializeField][ReadOnly] private Vector2 InitialPosition;
    public UiInfo Info { get => m_Data; set => m_Data = value; }

    public virtual void Initialize()
    {
        InitialPosition = m_Data.Canvas.GetComponent<RectTransform>().anchoredPosition;
        m_Data.Canvas.enabled = false; // If you Start game with disabled canvas InitialPosition will return teh wrong number
    }
    #region Internal Basic ButtonCalls Methods
    protected void RequestOpenOtherUI(_UiMaster.UiScreen targetUi)
    {
        EventBus.RaiseOpenUI(targetUi);
    }

    protected void RequestCloseSelf()
    {
        EventBus.RaiseCloseUI(m_Data.Id);
    }

    protected void RequestCloseOtherUI(_UiMaster.UiScreen targetUi)
    {
        EventBus.RaiseCloseUI(targetUi);
    }

    protected void RequestSwapUis(_UiMaster.UiScreen toOpen, _UiMaster.UiScreen toClose)
    {
        RequestOpenOtherUI(toOpen);
        RequestCloseOtherUI(toClose);
    }

    #endregion

    #region In Tween Methods
    public void StartInTransition()
    {
        switch (m_Data.In)
        {
            case _UiMaster.TransitionInType.EnterfromRight:
                EnterfromRight();
                break;
            case _UiMaster.TransitionInType.EnterfromLeft:
                EnterfromLeft();
                break;
            case _UiMaster.TransitionInType.EnterfromUp:
                EnterfromUp();
                break;
            case _UiMaster.TransitionInType.EnterfromDown:
                EnterfromDown();
                break;
            case _UiMaster.TransitionInType.Apear:
                EnterApearing();
                break;
            default:
                break;
        }
        CanvasEnabled();
    }

    private void EnterfromDown()
    {
        m_RectTransform.anchoredPosition = new Vector2(0,- Screen.height);
        m_Data.Canvas.enabled = true;
        Sequence MoveInFromTheRight = DOTween.Sequence(
            m_RectTransform.DOMove(new Vector2(InitialPosition.x, InitialPosition.y), m_Data.InTime)
            .SetUpdate(true)
            .SetEase(Ease.OutQuad)
            .OnComplete(InCompleatCalback)
            );
    }

    private void EnterfromUp()
    {
        m_RectTransform.anchoredPosition = new Vector2(0,Screen.height);

        m_Data.Canvas.enabled = true;
        Sequence MoveInFromTheRight = DOTween.Sequence(
            m_RectTransform.DOMove(new Vector2(InitialPosition.x, InitialPosition.y), m_Data.InTime)
            .SetUpdate(true)
            .SetEase(Ease.OutQuad)
            .OnComplete(InCompleatCalback)
            );
    }

    private void EnterfromLeft()
    {
        m_RectTransform.anchoredPosition = new Vector2(- Screen.width, 0);
        m_Data.Canvas.enabled = true;
        Sequence MoveInFromTheRight = DOTween.Sequence(
            m_RectTransform.DOMove(new Vector2(InitialPosition.x, InitialPosition.y), m_Data.InTime)
            .SetUpdate(true)
            .SetEase(Ease.OutQuad)
            .OnComplete(InCompleatCalback)
            );
    }

    private void EnterfromRight() 
    {
        m_RectTransform.anchoredPosition = new Vector2(Screen.width, 0);
        m_Data.Canvas.enabled = true;
        Sequence MoveInFromTheRight = DOTween.Sequence(
            m_RectTransform.DOMove(new Vector2(InitialPosition.x, InitialPosition.y), m_Data.InTime)
            .SetUpdate(true)
            .SetEase(Ease.OutQuad)
            .OnComplete(InCompleatCalback)
            );
    }

    private void EnterApearing() 
    {
        m_RectTransform.anchoredPosition = new Vector2(0,0);
        m_Data.Canvas.enabled = true;
        InCompleatCalback();
    }

    private void InCompleatCalback()
    {
        //Calback After In animation ends
    }

    public virtual void CanvasEnabled()
    {
        // Replaces On Enable
    }
    #endregion

    #region Out Tween Methods
    public void StartOutTransition()
    {
        switch (m_Data.Out)
        {
            case _UiMaster.TransitionOutType.ExitToRight:
                ExitRight();
                break;
            case _UiMaster.TransitionOutType.ExitToLeft:
                ExitLeft();
                break;
            case _UiMaster.TransitionOutType.ExitUp:
                ExitUp();
                break;
            case _UiMaster.TransitionOutType.ExitDown:
                ExitDown();
                break;
            case _UiMaster.TransitionOutType.Disapear:
                ExitDisapearing();
                break;
            default:
                break;
        }
        CanvasDisabled();
    }

    private void ExitRight()
    {
        Sequence MoveInFromTheRight = DOTween.Sequence(
            m_RectTransform.DOMove(new Vector2(InitialPosition.x + Screen.width, InitialPosition.y), m_Data.OutTime)
            .SetUpdate(true)
            .SetEase(Ease.OutQuad)
            .OnComplete(OutCompleatCalback)
            );
    }

    private void ExitLeft()
    {
        Sequence MoveInFromTheRight = DOTween.Sequence(
            m_RectTransform.DOMove(new Vector2(InitialPosition.x - Screen.width, InitialPosition.y), m_Data.OutTime)
            .SetUpdate(true)
            .SetEase(Ease.OutQuad)
            .OnComplete(OutCompleatCalback)
            );
    }

    private void ExitUp()
    {
        Sequence MoveInFromTheRight = DOTween.Sequence(
            m_RectTransform.DOMove(new Vector2(InitialPosition.x, InitialPosition.y + Screen.height), m_Data.OutTime)
            .SetUpdate(true)
            .SetEase(Ease.OutQuad)
            .OnComplete(OutCompleatCalback)
            );
    }

    private void ExitDown()
    {
        Sequence MoveInFromTheRight = DOTween.Sequence(
            m_RectTransform.DOMove(new Vector2(InitialPosition.x, InitialPosition.y - Screen.height), m_Data.OutTime)
            .SetUpdate(true)
            .SetEase(Ease.OutQuad)
            .OnComplete(OutCompleatCalback)
            );
    }

    private void ExitDisapearing()
    {
        OutCompleatCalback();
    }

    private void OutCompleatCalback()
    {
        m_Data.Canvas.enabled = false;
        m_RectTransform.anchoredPosition = new Vector2(InitialPosition.x, InitialPosition.y);
        //Calback After In animation ends
    }

    protected virtual void CanvasDisabled()
    {
        // Replaces OnDisable
    }

    #endregion
}

