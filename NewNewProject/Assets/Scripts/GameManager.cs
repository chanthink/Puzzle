using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private Dictionary<ColorChanger, bool> objectStates1;
    private Dictionary<ColorChanger, bool> objectStates2;
    private Dictionary<ColorChanger, bool> objectStates3;
    private int totalObjects1;
    private int totalObjects2;
    private int totalObjects3;
    private GameObject player; // 'player' 객체 참조
    private GameObject start;  // 'start' 객체 참조
    public delegate void VictoryAction();
    public static event VictoryAction OnVictory;
    public bool isVictory1 = false; // ButtonFloor에 대한 승리 상태를 저장하는 변수
    public bool isVictory2 = false; // ButtonFloor2에 대한 승리 상태를 저장하는 변수
    public bool isVictory3 = false; // ButtonFloor3에 대한 승리 상태를 저장하는 변수

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        start = GameObject.FindWithTag("Start");

        if (player != null && start != null)
        {
            // 'player' 객체를 'start' 위치로 이동
            player.transform.position = start.transform.position;
        }

        objectStates1 = new Dictionary<ColorChanger, bool>();
        objectStates2 = new Dictionary<ColorChanger, bool>();
        objectStates3 = new Dictionary<ColorChanger, bool>();
        ColorChanger[] changers = FindObjectsOfType<ColorChanger>();

        foreach (var changer in changers)
        {
            if (changer.gameObject.tag == "ButtonFloor")
            {
                objectStates1[changer] = false; // 초기 상태는 false (나무 재질 아님)
                totalObjects1++;
            }
            else if (changer.gameObject.tag == "ButtonFloor2")
            {
                objectStates2[changer] = false;
                totalObjects2++;
            }
            else if (changer.gameObject.tag == "ButtonFloor3")
            {
                objectStates3[changer] = false;
                totalObjects3++;
            }
        }
    }

    public void ObjectChanged(ColorChanger changer, bool isWood)
    {
        if (objectStates1.ContainsKey(changer))
        {
            objectStates1[changer] = isWood;
            CheckWinConditionButtonFloor();
        }
        else if (objectStates2.ContainsKey(changer))
        {
            objectStates2[changer] = isWood;
            CheckWinConditionButtonFloor2();
        }
        else if (objectStates3.ContainsKey(changer))
        {
            objectStates3[changer] = isWood;
            CheckWinConditionButtonFloor3();
        }
    }

    void CheckWinConditionButtonFloor()
    {
        foreach (var state in objectStates1.Values)
        {
            if (!state) // 'ButtonFloor' 중 하나라도 나무 재질이 아니면 승리 조건을 만족하지 않음
            {
                isVictory1 = false;
                return;
            }
        }
        StageOneClear(); // 모든 'ButtonFloor' 객체가 나무 재질일 때
    }

    void CheckWinConditionButtonFloor2()
    {
        foreach (var state in objectStates2.Values)
        {
            if (!state) // 'ButtonFloor2' 중 하나라도 나무 재질이 아니면 승리 조건을 만족하지 않음
            {
                isVictory2 = false;
                return;
            }
        }
        StageTwoClear(); // 모든 'ButtonFloor2' 객체가 나무 재질일 때
    }

    void CheckWinConditionButtonFloor3()
    {
        foreach (var state in objectStates3.Values)
        {
            if (!state) // 'ButtonFloor3' 중 하나라도 나무 재질이 아니면 승리 조건을 만족하지 않음
            {
                isVictory3 = false;
                return;
            }
        }
        StageThreeClear(); // 모든 'ButtonFloor2' 객체가 나무 재질일 때
    }

    public void StageOneClear()
    {
        if (!isVictory1) // 승리 상태가 이미 true가 아닐 때만 승리 로직을 실행
        {
            Debug.Log("You can clear stage 1");
            OnVictory?.Invoke();
            isVictory1 = true; // 승리 상태를 true로 설정
        }
    }

    public void StageTwoClear()
    {
        if (!isVictory2) // 승리 상태가 이미 true가 아닐 때만 승리 로직을 실행
        {
            Debug.Log("You can clear stage 2");
            OnVictory?.Invoke();
            isVictory2 = true; // 승리 상태를 true로 설정
        }
    }

    public void StageThreeClear()
    {
        if (!isVictory3) // 승리 상태가 이미 true가 아닐 때만 승리 로직을 실행
        {
            Debug.Log("You can clear stage 3");
            OnVictory?.Invoke();
            isVictory3 = true; // 승리 상태를 true로 설정
        }
    }
}