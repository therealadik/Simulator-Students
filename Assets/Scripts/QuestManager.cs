using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<Quest> takenQuests = new();
    private List<Quest> questCompleted = new();

    [SerializeField] private GameObject questPrefabUI;
    [SerializeField] private Transform contentForPrefabs;


    private const string TakenQuestsKey = "TakenQuests";
    private const string CompletedQuestsKey = "CompletedQuests";

    private void Start()
    {
        //LoadTakenQuests();
       // LoadCompletedQuests();
        UpdateQuestUI();
    }

    public bool IsQuestTaken(Quest quest)
    {
        foreach (var q in takenQuests)
        {
            if (q.Title == quest.Title)
            {
                return true;
            }
        }

        return false;
    }

    public bool isQuestCompleted(Quest quest)
    {
        foreach (var q in questCompleted)
        {
            if (q.Title == quest.Title)
            {
                return true;
            }
        }

        return false;
    }


    public void AddQuest(Quest quest)
    {
        takenQuests.Add(quest);
        print(takenQuests);
        SaveTakenQuests();
        quest.UIOblect = Instantiate(questPrefabUI, contentForPrefabs);
        quest.UIOblect.GetComponent<QuestTextUI>().UpdateUI(quest.Title);
    }

    public void QuestCompete(Quest quest)
    {
        if (IsQuestTaken(quest))
        {
            quest = GetQuest(quest);
            questCompleted.Add(quest);
            quest.UIOblect.GetComponent<QuestTextUI>().Complete();
            takenQuests.Remove(quest);
            SaveTakenQuests();
            SaveCompletedQuests();
        }
    }

    private void UpdateQuestUI()
    {
        foreach (Quest quest in takenQuests)
        {
            quest.UIOblect = Instantiate(questPrefabUI, contentForPrefabs);
            quest.UIOblect.GetComponent<QuestTextUI>().UpdateUI(quest.Title);
        }
    }

    private Quest GetQuest(Quest quest)
    {
        foreach (var currentQuest in takenQuests)
        {
            if (currentQuest.Title == quest.Title)
            {
                return currentQuest;
            }
        }
        return null;
    }

    private void LoadCompletedQuests()
    {
        if (PlayerPrefs.HasKey(CompletedQuestsKey))
        {
            string questsDataString = PlayerPrefs.GetString(CompletedQuestsKey);
            string[] questDataArray = questsDataString.Split(';');

            foreach (string questTitle in questDataArray)
            {
                Quest quest = ScriptableObject.CreateInstance<Quest>();
                quest.Init(questTitle);
                questCompleted.Add(quest);
            }
        }
    }

    private void LoadTakenQuests()
    {
        if (PlayerPrefs.HasKey(TakenQuestsKey))
        {
            // ��������� ������ �� PlayerPrefs
            string questsDataString = PlayerPrefs.GetString(TakenQuestsKey);
            print(questsDataString);


            // ��������� ������ �� ������ ����� �� �����������
            string[] questDataArray = questsDataString.Split(';');

            // ������� ������ ������ ������� ����� ��������� ����� ������
            takenQuests.Clear();

            // �������� �� ������ ������ ������� � ������� ������ �� ������
            foreach (string questData in questDataArray)
            {

                // ��������� ������ � ������ �� �������� � ������ ����������
                string questTitle = questData;

                // ������� ����� ����� � ��������� ��� � ������
                Quest quest = ScriptableObject.CreateInstance<Quest>();
                quest.Init(questTitle);
                takenQuests.Add(quest);
            }
        }
    }

    private void SaveCompletedQuests()
    {
        string[] questDataArray = new string[questCompleted.Count];

        for (int i = 0; i < questCompleted.Count; i++)
        {
            questDataArray[i] = questCompleted[i].Title;
        }

        string questsDataString = string.Join(";", questDataArray);

        PlayerPrefs.SetString(CompletedQuestsKey, questsDataString);
        PlayerPrefs.Save();
    }

    private void SaveTakenQuests()
    {
        // ������� ������ ����� ��� �������� ������ � �������
        string[] questDataArray = new string[takenQuests.Count];

        // ��������� ������ ����� ������� � �������
        for (int i = 0; i < takenQuests.Count; i++)
        {
            questDataArray[i] = takenQuests[i].Title;
        }

        // ���������� ������ ����� � ���� ������ � ������� �����������
        string questsDataString = string.Join(";", questDataArray);

        // ��������� ������ � PlayerPrefs
        PlayerPrefs.SetString(TakenQuestsKey, questsDataString);
        PlayerPrefs.Save();
    }

}

