using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoad : MonoBehaviour
{
    public void LoadLobbyScene()
    {
        // "Lobby" ������ ��ȯ
        SceneManager.LoadScene("Lobby");
    }

}
