using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class UiItem : MonoBehaviour
{
    [SerializeField] private int m_Amount;
    [SerializeField] private Image m_Image;
    [SerializeField] private TextMeshProUGUI m_Counter;

    public Image Image { get => m_Image;}
    public TextMeshProUGUI Counter { get => m_Counter;}
    public int Amount { get => m_Amount; set { m_Amount = value; m_Counter.text = value.ToString("n0"); } }
}
