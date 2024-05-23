using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private string namePeople;
    [SerializeField] private Quest quest;
    [SerializeField] private Dialog dialog;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera cameraDialog;

    private ProximityButton button;

    private Quest.TypeComplete typeComplete;
    private DialogueManager dialogueManager;

    public Quest GetQuest => quest;

    // Start is called before the first frame update

    private void Awake()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
        button = GetComponentInChildren<ProximityButton>();
    }

    void Start()
    {
        typeComplete = Quest.TypeComplete.NotTaken;
        namePeople = name;
    }

    public void PlayerInteract()
    {
        if (typeComplete != Quest.TypeComplete.Completed)
        {
            StartDialog();
        }
    }

    public void StartDialog()
    {
        cameraDialog.gameObject.SetActive(true);
        dialogueManager.StartDialogue(dialog, this);
    }

    public void TakeQuest()
    {
        cameraDialog.gameObject.SetActive(false);
        Destroy(button.gameObject);
    }

}
