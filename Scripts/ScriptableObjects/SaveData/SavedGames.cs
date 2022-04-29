using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class SavedGames 
{
    [SerializeField] public List<SaveFile> AllStoredSaveGames;

    public void CreateNewSave() 
    {
        int NumberOfSaves = AllStoredSaveGames.Count;

        //Create a SavedLocationData
        Debug.Log("Creating New Location");
        string LocationfileName = "Save" + "-" + NumberOfSaves + "-" + "Location";
        SavedLocationData asset = ScriptableObject.CreateInstance<SavedLocationData>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/"+ LocationfileName + ".asset");

        //Create a SavedPlayerData
        Debug.Log("Creating New PlayerData");
        string PlayerDatafileName = "Save" + "-" + NumberOfSaves + "-" + "PlayerData";
        SavedPlayerData asset2 = ScriptableObject.CreateInstance<SavedPlayerData>();
        AssetDatabase.CreateAsset(asset2, "Assets/Resources/" + PlayerDatafileName + ".asset");

        asset2.PlayerName = "HotDog Boy";
        AssetDatabase.SaveAssets();

        //Add both to a SaveFile
        SaveFile newFile = new SaveFile(asset, asset2);

        //Add to List
        AllStoredSaveGames.Add(newFile);
    }
}

[System.Serializable]
public class SaveFile
{
    [SerializeField] public SavedLocationData location;
    [SerializeField] public SavedPlayerData player;

    public SaveFile(SavedLocationData _location, SavedPlayerData _player)
    {
        location = _location;
        player = _player;
    }
}