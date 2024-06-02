using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
[System.Serializable]
public class Quest : ScriptableObject
{
    [HideInInspector]
    public GameObject UIOblect;

   [SerializeField] private string title;

    public string Title { get { return title; } }

    public void Init(string title)
    {
        this.title = title;
    }
}