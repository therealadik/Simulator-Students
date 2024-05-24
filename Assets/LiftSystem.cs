using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftSystem : MonoBehaviour
{
    [SerializeField] List<Lift> lifts;

    [SerializeField] PlayerController playerController;
    public void LiftTo(Lift from, int to) 
    { 
        StartCoroutine(Lift(from, to));
    }

    private IEnumerator Lift(Lift from, int to)
    {
        from.Close();
        playerController.SetControll(false);
        yield return new WaitForSeconds(1);

        foreach (var lift in lifts) 
        {
            if (lift.Floor == to)
            {
                PlayerTeleporter.TeleportTo(playerController, lift.point.position);
                lift.OpenLift();
                break;
            }
        }

        playerController.SetControll(true);

        from.Work();
    }
}
