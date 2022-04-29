using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MasterOfMasters : _Master
{
    [SerializeField] private _Master[] m_gameMasters;

    public event Action<bool> MasterOfMastersDone;
    public delegate bool MastersInitializers(_Master master);
    public MastersInitializers Del;

    #region Initialization Methods
    private bool Start_Master(_Master master)
    {
        master.gameObject.SetActive(true);
        return master.InitializeMaster();
    }

    public override void CustomInitializationAnexAfter() 
    {
        MasterOfMastersDone?.Invoke(true);
    }

    public override IEnumerator InitializeMasterC(float waitTime)
    {
        _FirstLoadingScreen.Instance.loadNextStep($"Loading {_MasterEnum.ToString()}");

        //DO MASTEROFMASTER LOAD HERE

        //****************

        yield return new WaitForSeconds(waitTime);

        Del = Start_Master;
        for (int i = 0; i < GameMasters.Length; i++)
        {
            //DO SUB-WORK
            if (!Del(GameMasters[i]))
            {
                Debug.LogError($"Fail To Initialize Master ({i})");
            }
            //***********
            yield return new WaitForSeconds(waitTime);
        }
        CustomInitializationAnexAfter();
    }

    #endregion
    #region Class Methods
    public _Master[] GameMasters { get => m_gameMasters; set => m_gameMasters = value; }
    #endregion
}
