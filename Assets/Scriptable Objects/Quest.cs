using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    [HideInInspector]
    public GameObject prefabWithUI;

    [SerializeField] private string title;

    public string Title { get { return title; } }
}