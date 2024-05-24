using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private string namePeople;
    [SerializeField] private Quest quest;
    [SerializeField] private Dialog dialog;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera cameraDialog;

    private ProximityButton button;

    private DialogueManager dialogueManager;
    private Animator animator;

    public Quest GetQuest => quest;

    // Start is called before the first frame update

    private void Awake()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
        button = GetComponentInChildren<ProximityButton>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        namePeople = name;
    }

    public void PlayerInteract()
    {
         StartDialog();
    }

    public void StartDialog()
    {
        cameraDialog.gameObject.SetActive(true);
        dialogueManager.StartDialogue(dialog, this);
        animator.SetBool("Talking", true);
    }

    public void TakeQuest()
    {
        cameraDialog.gameObject.SetActive(false);
        Destroy(button.gameObject);
        animator.SetBool("Talking", false);
    }

}
