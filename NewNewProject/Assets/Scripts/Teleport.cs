using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform targetPosition; // 워프할 목적지 위치
    private GameObject player; // 발판 위에 있는 플레이어를 추적하기 위한 변수
    private float playerStayTime; // 플레이어가 발판에 머무른 시간
    private bool warpActivated = true; // 워프 기능 활성화 여부

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && warpActivated)
        {
            player = other.gameObject;
            playerStayTime = 0f; // 시간 초기화
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player = null;
            playerStayTime = 0f; // 시간 초기화
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && warpActivated)
        {
            playerStayTime += Time.deltaTime; // 시간 업데이트

            if (playerStayTime >= 1f) // 1초 이상 발판에 머물렀다면
            {
                player.transform.position = targetPosition.position; // 워프 실행
                warpActivated = false; // 워프 기능 비활성화
            }
        }
    }
}