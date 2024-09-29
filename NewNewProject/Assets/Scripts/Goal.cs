using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static bool goal;
    // Start is called before the first frame update
    void Start()
    {
        goal = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("You win!");
            goal = true;
        }
    }
}
