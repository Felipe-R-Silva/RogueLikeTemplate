using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using System;

public class _AdmSaveLoad : MonoBehaviour
{
    [SerializeField] public List<SaveFile> AllStoredSaveGames;

    [SerializeField] public SavedGames AllSaves;


    //TODO
    //###################################### change this to Initialize() called from master to make the loading script work
    private void Start()
    {
        EventBus.OnCreateNewSave += CreateNewSaveHandler;
    }

    private void OnApplicationQuit()
    {
        AllSaves.AllStoredSaveGames.Clear();
    }

    public void LoadEnviroment(SaveFile readSaveFile, _EnviromentMaster _enviroment) 
    {
        _enviroment.OpenSceneRemoveActiveScene(readSaveFile.location.m_SceneEnum);//Load Scene that needs to be loaded
    }

    public void LoadUis(SaveFile readSaveFile, _UiMaster _ui)
    {
        _ui.MatchOpenAndClosedUIs(readSaveFile.player.ActiveUIs); //Open And Close Uis Acording to Load
    }

    private void CreateNewSaveHandler(EventBus.CreateNewSaveArgs obj)
    {
        AllSaves.CreateNewSave();
    }
}
