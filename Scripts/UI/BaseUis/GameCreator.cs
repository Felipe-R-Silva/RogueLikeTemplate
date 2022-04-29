using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using UnityEngine.UI;

public class GameCreator : BaseUi
{
    [Separator("Buttons", true)]
    [SerializeField] private Button CreateSave;
    [SerializeField] private Button Back;

    [SerializeField] public SaveFile NewSaveGamesSettings;

    public override void Initialize()
    {
        base.Initialize();
        Back.onClick.AddListener(delegate { RequestSwapUis(_UiMaster.UiScreen.NewGame, m_Data.Id); });
        Back.onClick.AddListener(delegate {

            RequestSwapUis(_UiMaster.UiScreen.NewGame, m_Data.Id);
        });

        NewSaveGamesSettings.player = new SavedPlayerData();
        NewSaveGamesSettings.location = new SavedLocationData();
    }
    private void RequestToCreateGame()
    {
    }
}
