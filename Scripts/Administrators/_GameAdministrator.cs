using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class _GameAdministrator : _Master
{

    [SerializeField] private _DataMaster m_Data;
    [SerializeField] private _SettingsMaster m_Settings;
    [SerializeField] private _UiMaster m_Ui;
    [SerializeField] private _AudioMaster m_Audio;
    [SerializeField] private _EnviromentMaster m_Enviroment;
    [SerializeField] private _AiMaster m_Ai;

    public _EnviromentMaster Enviroment { get => m_Enviroment; set => m_Enviroment = value; }

    public event Action<bool> AdministratorDone;

    #region Initialization
    public override void CustomInitializationAnex()
    {
        SceneManager.sceneLoaded += SceneLoadedHandler;
        EventBus.OnLoadGame += LoadGameRequestHandler;
    }

    public override void CustomInitializationAnexAfter()
    {
        AdministratorDone?.Invoke(true);
    }
    #endregion

    #region Event Handlers
    private void SceneLoadedHandler(Scene scene, LoadSceneMode loadMode)
    {
        if (scene.buildIndex == 1)//Main Menu
        {
            EventBus.RaiseOpenUI(_UiMaster.UiScreen.MainMenu);
        }
    }

    private void LoadGameRequestHandler(EventBus.LoadGameArgs obj)
    {
        SaveFile FileLoaded = m_Data.SaveLoad.AllStoredSaveGames[obj.SaveiD];
        _AdmSaveLoad Adm = m_Data.SaveLoad;
        //Here we will Load Game with all its intrinsic values
        Adm.LoadEnviroment(FileLoaded, m_Enviroment);
        Adm.LoadUis(FileLoaded, m_Ui);
    }
    #endregion
}
