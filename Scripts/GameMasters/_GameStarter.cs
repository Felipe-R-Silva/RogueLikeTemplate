using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MyBox;
using UnityEngine.SceneManagement;
public class _GameStarter : MonoBehaviour
{
    [SerializeField] private _MasterOfMasters Father;//masters
    [SerializeField] private _GameAdministrator Son;//adm
    [SerializeField] private ToolsStarter Spirit;//tools

    [Separator]
    [SerializeField] private float TimeBetweenEachLoad = 0.1f;
    [SerializeField] EnumsGame.Scenes SceneToLoadAfterFinishedLoading;

    void Start()
    {
        Father.MasterOfMastersDone += FatherDoneHandler;
        Son.AdministratorDone += SonDoneHandler;
        Spirit.ToolsStartingDone += SpiritDoneHandler;

        StartCoroutine(BigBangCorotine());
    }

    #region Event Handlers
    private void FatherDoneHandler(bool obj)
    {
        Son.gameObject.SetActive(true);
        StartCoroutine(Son.InitializeMasterC(TimeBetweenEachLoad));
    }

    private void SonDoneHandler(bool obj)
    {
        Spirit.gameObject.SetActive(true);
        Spirit.Initialize(); // no partial loading system implemented
    }

    private void SpiritDoneHandler(bool obj)
    {
        _FirstLoadingScreen.Instance.loadNextStep("Starting Game...");
        DontDestroyOnLoad(this.gameObject);
        Son.Enviroment.OpenSceneRemoveActiveScene(SceneToLoadAfterFinishedLoading);

        Destroy(GetComponent<_GameStarter>());
    }
    #endregion

    #region Auxiliar
    IEnumerator BigBangCorotine()
    {
        _FirstLoadingScreen.Instance.loadNextStep("STARTED GAME INITIALIZATIOn");
        Father.gameObject.SetActive(true);
        yield return StartCoroutine(Father.InitializeMasterC(TimeBetweenEachLoad));
    }
    #endregion
}
