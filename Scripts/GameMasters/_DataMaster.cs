using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _DataMaster : _Master
{
    [SerializeField] private _AdmCurator m_Curator;
    [SerializeField] private _AdmSaveLoad m_SaveLoad;

    public _AdmSaveLoad SaveLoad { get => m_SaveLoad;}
    public _AdmCurator Curator { get => m_Curator;}
}
