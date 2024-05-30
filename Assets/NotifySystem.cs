using UnityEngine;

public class NotifySystem : MonoBehaviour
{
    [SerializeField] Nofify notify;

    public void ShowNofity(string text)
    {
        notify.ShowNofity(text);
    }
}
