using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsStarter : MonoBehaviour
{
    public event Action<bool> ToolsStartingDone;
    public bool Initialize()
    {
        _FirstLoadingScreen.Instance.loadNextStep("Tools Finished Loading");
        //Debug.Log("Tools Finished Loading");
        ToolsStartingDone?.Invoke(true);
        return true;
    }
}
