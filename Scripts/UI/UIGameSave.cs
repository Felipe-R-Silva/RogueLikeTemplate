using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using UnityEngine.UI;
using System;

public class UIGameSave : MonoBehaviour
{
    [Separator("Buttons", true)]
    [SerializeField] private Button m_NewGameButton;
    [Separator("Data", true)]
    [SerializeField] private int m_SaveID;

    void Start()
    {
        m_NewGameButton.onClick.AddListener(delegate { RequestLoadingGame(m_SaveID); });
    }

    private void RequestLoadingGame(int _id)
    {
        if (_id == 0) 
        {
            CreateNewSave();
        }
        else
            EventBus.RaiseLoadGame(_id);
    }
    private void CreateNewSave() 
    {
        EventBus.RaiseCreateNewSave(0);
    }
}
