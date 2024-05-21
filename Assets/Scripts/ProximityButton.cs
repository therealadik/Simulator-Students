using UnityEngine;
using UnityEngine.Events;

public class ProximityButton : MonoBehaviour
{
    public GameObject canvas;

    public UnityEvent playerEntered;
    public UnityEvent playerExited;

    public UnityEvent playerInteract;

    private void Start()
    {
        canvas.SetActive(false);
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            playerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            playerExited?.Invoke();
        }
    }

    public void Interact()
    {
        playerInteract?.Invoke();
    }
}
