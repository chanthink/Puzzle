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
    private GameObject player; // 'player' ��ü ����
    private GameObject start;  // 'start' ��ü ����
    public delegate void VictoryAction();
    public static event VictoryAction OnVictory;
    public bool isVictory1 = false; // ButtonFloor�� ���� �¸� ���¸� �����ϴ� ����
    public bool isVictory2 = false; // ButtonFloor2�� ���� �¸� ���¸� �����ϴ� ����
    public bool isVictory3 = false; // ButtonFloor3�� ���� �¸� ���¸� �����ϴ� ����

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        start = GameObject.FindWithTag("Start");

        if (player != null && start != null)
        {
            // 'player' ��ü�� 'start' ��ġ�� �̵�
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
                objectStates1[changer] = false; // �ʱ� ���´� false (���� ���� �ƴ�)
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
            if (!state) // 'ButtonFloor' �� �ϳ��� ���� ������ �ƴϸ� �¸� ������ �������� ����
            {
                isVictory1 = false;
                return;
            }
        }
        StageOneClear(); // ��� 'ButtonFloor' ��ü�� ���� ������ ��
    }

    void CheckWinConditionButtonFloor2()
    {
        foreach (var state in objectStates2.Values)
        {
            if (!state) // 'ButtonFloor2' �� �ϳ��� ���� ������ �ƴϸ� �¸� ������ �������� ����
            {
                isVictory2 = false;
                return;
            }
        }
        StageTwoClear(); // ��� 'ButtonFloor2' ��ü�� ���� ������ ��
    }

    void CheckWinConditionButtonFloor3()
    {
        foreach (var state in objectStates3.Values)
        {
            if (!state) // 'ButtonFloor3' �� �ϳ��� ���� ������ �ƴϸ� �¸� ������ �������� ����
            {
                isVictory3 = false;
                return;
            }
        }
        StageThreeClear(); // ��� 'ButtonFloor2' ��ü�� ���� ������ ��
    }

    public void StageOneClear()
    {
        if (!isVictory1) // �¸� ���°� �̹� true�� �ƴ� ���� �¸� ������ ����
        {
            Debug.Log("You can clear stage 1");
            OnVictory?.Invoke();
            isVictory1 = true; // �¸� ���¸� true�� ����
        }
    }

    public void StageTwoClear()
    {
        if (!isVictory2) // �¸� ���°� �̹� true�� �ƴ� ���� �¸� ������ ����
        {
            Debug.Log("You can clear stage 2");
            OnVictory?.Invoke();
            isVictory2 = true; // �¸� ���¸� true�� ����
        }
    }

    public void StageThreeClear()
    {
        if (!isVictory3) // �¸� ���°� �̹� true�� �ƴ� ���� �¸� ������ ����
        {
            Debug.Log("You can clear stage 3");
            OnVictory?.Invoke();
            isVictory3 = true; // �¸� ���¸� true�� ����
        }
    }
}