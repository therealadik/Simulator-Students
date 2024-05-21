using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private string namePeople;
    [SerializeField] private int questID;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera cameraDialog;
    [SerializeField] private ProximityButton proximityButton;

    private Quest.TypeComplete typeComplete;


    // Start is called before the first frame update
    void Start()
    {
        typeComplete = Quest.TypeComplete.NotTaken;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerInteract()
    {
        switch (typeComplete)
        {
            case Quest.TypeComplete.NotTaken:
                break;

            case Quest.TypeComplete.InProgress:
                break;

            case Quest.TypeComplete.Completed:
                break;
        }
    }

    public void StartDialog()
    {
        cameraDialog.gameObject.SetActive(true);
    }
}
