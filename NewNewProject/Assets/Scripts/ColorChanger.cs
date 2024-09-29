using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColorChanger : MonoBehaviour
{
    public Material woodMaterial;
    public Material originalMaterial; // 기존 재질을 저장할 변수
    private GameManager gameManager;
    private bool isWood = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // 기존 재질을 저장합니다.
        originalMaterial = GetComponent<MeshRenderer>().material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null && woodMaterial != null)
            {
                if (!isWood)
                {
                    meshRenderer.material = woodMaterial;
                    isWood = true;
                    gameManager.ObjectChanged(this,isWood);
                }
                else
                {
                    meshRenderer.material = originalMaterial;
                    isWood = false;
                    gameManager.ObjectChanged(this,isWood);
                }
            }
        }
    }
}