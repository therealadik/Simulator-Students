using System.Collections;
using TMPro;
using UnityEngine;

public class Nofity : MonoBehaviour
{
    private TMP_Text textNofity;
    private void Awake()
    {
        textNofity = GetComponentInChildren<TMP_Text>();
    }

    public void ShowNofity(string text)
    {
        gameObject.SetActive(true);
        StartCoroutine(ShowN(text));
    }

    IEnumerator ShowN(string text)
    {
        textNofity.text = text;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
