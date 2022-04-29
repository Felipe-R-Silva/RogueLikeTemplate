using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyBox;
public class NewGameUI : BaseUi
{
    [Separator("NewGame",true)]
    [SerializeField] RectTransform m_ScrollViewRectTransform;
    [SerializeField] RectTransform m_CreateNewGameRect;
    [SerializeField] [ReadOnly] private int NumberOfSaves;
    [SerializeField]private float SaveTemplatePrefabOfset;
    [SerializeField] GameObject SaveTemplatePrefab;
    [Separator("Buttons", true)]
    [SerializeField] private Button BackButton;

    public override void Initialize()
    {
        base.Initialize();
        BackButton.onClick.AddListener(delegate { RequestCloseSelf(); }); //
    }

    public override void CanvasEnabled()
    {
        base.CanvasEnabled();
        //Spawn New Save Ui
        SerchForSaveDataAndUpdateUI();
        //Resize ScrollView
        NumberOfSaves = m_ScrollViewRectTransform.transform.childCount -1;
        if (((NumberOfSaves+1) * m_CreateNewGameRect.sizeDelta.y) + 60 > m_ScrollViewRectTransform.sizeDelta.y) 
        {
            // 1 is the create new game rect and 3 is the number that fits in the initial window
            m_ScrollViewRectTransform.sizeDelta = new Vector2(m_ScrollViewRectTransform.sizeDelta.x,
                                                              m_ScrollViewRectTransform.sizeDelta.y + ((m_CreateNewGameRect.sizeDelta.y + SaveTemplatePrefabOfset ) * (NumberOfSaves + 1 - 3)));
        }
    }

    public void SerchForSaveDataAndUpdateUI() 
    {   /* 
        //Create a new Save
        var NewSaveData = Instantiate(SaveTemplatePrefab, m_CreateNewGameRect.anchoredPosition, Quaternion.identity);
        NewSaveData.transform.SetParent(m_ScrollViewRectTransform.transform,false);
        NewSaveData.transform.SetAsFirstSibling();
        */
    }
}
