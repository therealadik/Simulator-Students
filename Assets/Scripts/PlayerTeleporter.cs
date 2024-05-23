using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] Transform point;

    private void Awake()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    public void Teleport()
    {
        playerController.SetControll(false);
        playerController.transform.position = point.position;
        playerController.SetControll(true);
    }
}
