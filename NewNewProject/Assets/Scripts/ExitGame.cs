using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // 유니티 에디터에서 실행 중일 경우
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 실제 애플리케이션에서 실행 중일 경우
        Application.Quit();
#endif
    }
}
