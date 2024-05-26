using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private string namePeople;
    [SerializeField] private List<Quest> quests;
    [SerializeField] private List<Dialog> dialogs;
    [SerializeField] private CinemachineCamera cameraDialog;

    private ProximityButton button;

    private DialogueManager dialogueManager;
    private Animator animator;

    private Queue<Quest> questQueue = new();
    private Queue<Dialog> dialogQueue = new();

    public Quest GetQuest()
    {
        if (questQueue.Count > 0)
        {
            return questQueue.Dequeue();
        }

        return null;
    }

    // Start is called before the first frame update

    private void Awake()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
        button = GetComponentInChildren<ProximityButton>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        foreach (Quest quest in quests)
            questQueue.Enqueue(quest);

        foreach (Dialog dialog in dialogs)
            dialogQueue.Enqueue(dialog);

        namePeople = name;
    }

    public void PlayerInteract()
    {
        StartDialog();
    }

    public void StartDialog()
    {
        cameraDialog.gameObject.SetActive(true);
        dialogueManager.StartDialogue(dialogQueue.Dequeue(), this);
        if (animator)
            animator.SetBool("Talking", true);
    }

    public void EndDialog()
    {
        cameraDialog.gameObject.SetActive(false);

        if (questQueue.Count == 0)
        {
            Destroy(button.gameObject);
        }
        else
        {
            button.isActive = true;
        }

        if (animator)
            animator.SetBool("Talking", false);
    }

}
