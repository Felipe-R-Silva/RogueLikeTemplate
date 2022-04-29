using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using UnityEngine.UI;

public class MainMenu : BaseUi
{
    [Separator("Buttons", true)]
    [SerializeField] private Button NewGameButton;

    public override void Initialize()
    {
        base.Initialize();
        NewGameButton.onClick.AddListener(delegate { RequestOpenOtherUI(_UiMaster.UiScreen.NewGame); });
    }
}
