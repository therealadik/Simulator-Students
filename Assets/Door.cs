using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator animator;
    private AudioSource audioSource;
    private ProximityButton proximityButton;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        proximityButton = GetComponentInChildren<ProximityButton>();
    }

    public void OpenDoor()
    {
        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        animator.SetTrigger("Change");
        audioSource.Play();
        proximityButton.isActive = false;
        yield return new WaitForSeconds(3);
        proximityButton.isActive = true;
    }
}
