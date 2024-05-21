using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public enum TypeComplete
    {
        NotTaken,
        InProgress,
        Completed
    }

    [SerializeField] private string title;
    [SerializeField] private int id;

    public string Title { get { return title; } }
    public int Id { get { return id; } }
}