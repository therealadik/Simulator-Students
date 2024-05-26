using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<Quest> takenQuests = new();
    [SerializeField] private GameObject questPrefabUI;
    [SerializeField] private Transform contentForPrefabs;


    public void AddQuest(Quest quest)
    {
        takenQuests.Add(quest);
        quest.prefabWithUI = Instantiate(questPrefabUI, contentForPrefabs);
        quest.prefabWithUI.GetComponent<QuestTextUI>().UpdateUI(quest.Title);
    }

    public void QuestCompete(Quest quest)
    {
        if (takenQuests.Contains(quest))
        {
            quest.prefabWithUI.GetComponent<QuestTextUI>().Complete();
            takenQuests.Remove(quest);
        }
    }

}

