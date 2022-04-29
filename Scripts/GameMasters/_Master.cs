using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Master : MonoBehaviour, InterfaceMaster
{
    public enum MasterTypes
    {
        unkown,
        Data_Master,
        Settings_Master,
        UI_Master,
        Audio_Master,
        Enviroment_Master,
        AI_Master,
        Count,
        MasterOfMaster,
        Game_Master,
    }

    [SerializeField] protected MasterTypes _MasterEnum;
    public virtual void CustomInitializationAnex() 
    {
    }
    public virtual void CustomInitializationAnexAfter() { }

    //Instant Loader can freeze game if is to large
    public bool InitializeMaster()
    {
        _FirstLoadingScreen.Instance.loadNextStep($"Loading {_MasterEnum.ToString()}");
        //DO LOAD HERE
        CustomInitializationAnex();
        //****************

        CustomInitializationAnexAfter();
        return true;
    }

    //partial Loader can made so you can split all loading to fit without freeze
    public virtual IEnumerator InitializeMasterC(float waitTime)
    {
        _FirstLoadingScreen.Instance.loadNextStep($"Loading {_MasterEnum.ToString()}");

        //DO LOAD HERE
        CustomInitializationAnex();
        //****************

        yield return new WaitForSeconds(waitTime);

        CustomInitializationAnexAfter();
    }
}
