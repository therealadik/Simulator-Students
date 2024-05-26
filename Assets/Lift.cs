using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private AudioSource audioSource;
    private Animator animator;
    private ProximityButton[] proximityButton;

    public AudioClip openLift;

    public Transform point;

    [SerializeField] private int floor;

    public int Floor => floor;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        proximityButton = GetComponentsInChildren<ProximityButton>();
    }

    public void OpenLift()
    {
        StartCoroutine(Open());
    }
    public void Close()
    {
        StopAllCoroutines();
        animator.SetBool("IsOpen", false);
        buttonSet(false);
    }

    public void Work()
    {
        buttonSet(true);
    }

    private IEnumerator Open()
    {
        animator.SetBool("IsOpen", true);
        buttonSet(false);
        audioSource.Play();
        audioSource.PlayOneShot(openLift);
        yield return new WaitForSeconds(5);
        animator.SetBool("IsOpen", false);
        buttonSet(true);
    }

    private void buttonSet(bool value)
    {
        foreach (var button in proximityButton)
        {
            button.isActive = value;
        }
    }
}
