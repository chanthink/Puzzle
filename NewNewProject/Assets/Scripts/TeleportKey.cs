using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TeleportKey : MonoBehaviour
{
    public Transform targetPosition; // ������ ������ ��ġ
    private GameObject player; // ���� ���� �ִ� �÷��̾ �����ϱ� ���� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ ���� ���� ������ ǥ��
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            // �÷��̾ ������ ���
            player = null;
        }
    }

    private void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.Space))
        {
            // �÷��̾ ���� ���� �ְ� �����̽��ٸ� ������ ���� ����
            player.transform.position = targetPosition.position;
        }
    }
}