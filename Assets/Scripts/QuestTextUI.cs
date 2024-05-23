using TMPro;
using UnityEngine;

public class QuestTextUI : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;

    public void UpdateUI(string text)
    {
        m_Text.text = text;
    }
}
