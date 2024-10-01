using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material woodMaterial;
    public Material originalMaterial; // ���� ������ ������ ����
    private GameManager gameManager;
    private Retry retryScript; // Retry ��ũ��Ʈ ���� ����
    private bool isWood = false; // ���� ������Ʈ�� ���� ����
    private bool hasStepped = false; // �÷��̾ �̹� ��Ҵ��� Ȯ���ϴ� ����

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        retryScript = FindObjectOfType<Retry>(); // Retry ��ũ��Ʈ�� ã���ϴ�.
        // ���� ������ �����մϴ�.
        originalMaterial = GetComponent<MeshRenderer>().material;
    }

    // �浹�� ���۵� ��
    private void OnCollisionEnter(Collision collision)
    {
        ChangeMaterial(collision);
    }

    // �浹�� �߻��� ���� ������ �����ϴ� �Լ�
    private void ChangeMaterial(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null && woodMaterial != null)
            {
                if (!isWood && !hasStepped)
                {
                    // �÷��̾ ó�� ������ ���� �� ���� ������ ����
                    meshRenderer.material = woodMaterial;
                    isWood = true;
                    hasStepped = true; // �÷��̾ �ѹ� ������� ���
                    gameManager.ObjectChanged(this, isWood);
                }
                else if (isWood && hasStepped)
                {
                    // �̹� ���� ������ ����� ������ �ٽ� ���� �� Retry
                    if (retryScript != null)
                    {
                        retryScript.RestartGame();
                    }
                }
                else
                {
                    // ���� ������ ����
                    meshRenderer.material = originalMaterial;
                    isWood = false;
                    gameManager.ObjectChanged(this, isWood);
                }
            }
        }
    }
}