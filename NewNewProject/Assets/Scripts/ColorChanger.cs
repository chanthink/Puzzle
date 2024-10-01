using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material woodMaterial;
    public Material originalMaterial; // 기존 재질을 저장할 변수
    private GameManager gameManager;
    private Retry retryScript; // Retry 스크립트 참조 변수
    private bool isWood = false; // 현재 오브젝트의 재질 상태
    private bool hasStepped = false; // 플레이어가 이미 밟았는지 확인하는 변수

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        retryScript = FindObjectOfType<Retry>(); // Retry 스크립트를 찾습니다.
        // 기존 재질을 저장합니다.
        originalMaterial = GetComponent<MeshRenderer>().material;
    }

    // 충돌이 시작될 때
    private void OnCollisionEnter(Collision collision)
    {
        ChangeMaterial(collision);
    }

    // 충돌이 발생할 때만 재질을 변경하는 함수
    private void ChangeMaterial(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null && woodMaterial != null)
            {
                if (!isWood && !hasStepped)
                {
                    // 플레이어가 처음 발판을 밟을 때 나무 재질로 변경
                    meshRenderer.material = woodMaterial;
                    isWood = true;
                    hasStepped = true; // 플레이어가 한번 밟았음을 기록
                    gameManager.ObjectChanged(this, isWood);
                }
                else if (isWood && hasStepped)
                {
                    // 이미 나무 재질로 변경된 발판을 다시 밟을 때 Retry
                    if (retryScript != null)
                    {
                        retryScript.RestartGame();
                    }
                }
                else
                {
                    // 원래 재질로 복구
                    meshRenderer.material = originalMaterial;
                    isWood = false;
                    gameManager.ObjectChanged(this, isWood);
                }
            }
        }
    }
}