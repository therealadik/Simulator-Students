using System.Collections;
using TMPro;
using UnityEngine;

public class QuestTextUI : MonoBehaviour
{
    private TMP_Text m_Text;
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Text = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateUI(string text)
    {
        m_Text.text = text;
    }

    public void Complete()
    {
        StartCoroutine(Completed());
    }

    IEnumerator Completed()
    {
        m_Animator.SetTrigger("Completed");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
