using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoad : MonoBehaviour
{
    public void LoadLobbyScene()
    {
        // "Lobby" 씬으로 전환
        SceneManager.LoadScene("Lobby");
    }

}
