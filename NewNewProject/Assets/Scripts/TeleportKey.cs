using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TeleportKey : MonoBehaviour
{
    public Transform targetPosition; // 워프할 목적지 위치
    private GameObject player; // 발판 위에 있는 플레이어를 추적하기 위한 변수

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어가 발판 위에 있음을 표시
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            // 플레이어가 발판을 벗어남
            player = null;
        }
    }

    private void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.Space))
        {
            // 플레이어가 발판 위에 있고 스페이스바를 누르면 워프 실행
            player.transform.position = targetPosition.position;
        }
    }
}