using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SecondStage : MonoBehaviour
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
        // GameManager의 인스턴스를 찾아 승리 상태 확인
        GameManager gameManager = FindObjectOfType<GameManager>();
        bool canTeleport = gameManager != null && gameManager.isVictory2;

        if (player != null && canTeleport && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Stage Clear");
            // 플레이어가 발판 위에 있고 승리 상태이며 스페이스바를 누르면 워프 실행
            player.transform.position = targetPosition.position;
        }
    }
}