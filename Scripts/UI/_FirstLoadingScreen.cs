using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class _FirstLoadingScreen : MonoBehaviour
{
    [SerializeField] private int m_NumberOfSteps;
    private int m_NumberOfStepsDoneCounter = 0;
    [SerializeField] private Image m_FillBar;
    [SerializeField] private TextMeshProUGUI m_BarText;

    #region Singleton
    private static _FirstLoadingScreen _Instance;

    public static _FirstLoadingScreen Instance => _Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _Instance = this;
        }
    }
    #endregion

    public void loadNextStep(string message) 
    {
        m_NumberOfStepsDoneCounter += 1;
        m_FillBar.fillAmount = (float)m_NumberOfStepsDoneCounter / (float)m_NumberOfSteps;
        //Debug.Log(m_NumberOfStepsDoneCounter.ToString() + "-" + message + "("+ m_FillBar.fillAmount + ")");
        m_BarText.text = message + "...";
    }
}
