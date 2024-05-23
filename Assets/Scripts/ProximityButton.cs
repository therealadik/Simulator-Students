using UnityEngine;
using UnityEngine.Events;

public class ProximityButton : MonoBehaviour
{
    public UnityEvent playerInteract;
    public string actionName;

    public bool isActive = true;
    [SerializeField] Quest quest;

    private QuestManager manager;

    private void Awake()
    {
        manager =FindFirstObjectByType<QuestManager>();
    }

    public void Interact()
    {
        if (isActive)
        {
            playerInteract?.Invoke();

            if (quest)
            {
                manager.QuestCompete(quest);
            }
        }
    }
}
