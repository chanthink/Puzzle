using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform targetPosition; // ������ ������ ��ġ
    private GameObject player; // ���� ���� �ִ� �÷��̾ �����ϱ� ���� ����
    private float playerStayTime; // �÷��̾ ���ǿ� �ӹ��� �ð�
    private bool warpActivated = true; // ���� ��� Ȱ��ȭ ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && warpActivated)
        {
            player = other.gameObject;
            playerStayTime = 0f; // �ð� �ʱ�ȭ
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player = null;
            playerStayTime = 0f; // �ð� �ʱ�ȭ
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && warpActivated)
        {
            playerStayTime += Time.deltaTime; // �ð� ������Ʈ

            if (playerStayTime >= 1f) // 1�� �̻� ���ǿ� �ӹ����ٸ�
            {
                player.transform.position = targetPosition.position; // ���� ����
                warpActivated = false; // ���� ��� ��Ȱ��ȭ
            }
        }
    }
}