using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.SceneManagement;

public class gotoOutDoor : MonoBehaviour
{
    static int world = 1;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < 2 && Input.GetMouseButtonDown(0))
        {
            playerControl.playerPos = Vector2.zero;
            SceneManager.LoadScene("outDoor");
        }
    }
}
