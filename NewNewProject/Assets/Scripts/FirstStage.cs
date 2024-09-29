using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirstStage : MonoBehaviour
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
        // GameManager�� �ν��Ͻ��� ã�� �¸� ���� Ȯ��
        GameManager gameManager = FindObjectOfType<GameManager>();
        bool canTeleport = gameManager != null && gameManager.isVictory1;

        if (player != null && canTeleport && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Stage Clear");
            // �÷��̾ ���� ���� �ְ� �¸� �����̸� �����̽��ٸ� ������ ���� ����
            player.transform.position = targetPosition.position;
        }
    }
}