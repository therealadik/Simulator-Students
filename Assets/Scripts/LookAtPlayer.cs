using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        if (playerTransform != null)
        {
            // ��������� Canvas, ����� �� ������� �� ������
            transform.LookAt(playerTransform);

            // ��������� Canvas �� 180 �������� �� ��� Y
            //transform.Rotate(0, 180, 0);
        }
    }
}
