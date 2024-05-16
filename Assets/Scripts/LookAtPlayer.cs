using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        if (playerTransform != null)
        {
            // Повернуть Canvas, чтобы он смотрел на игрока
            transform.LookAt(playerTransform);

            // Повернуть Canvas на 180 градусов по оси Y
            //transform.Rotate(0, 180, 0);
        }
    }
}
