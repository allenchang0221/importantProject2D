using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.SceneManagement;

public class gotoOutDoor : MonoBehaviour
{
    static int world = 1;
    GameObject player;
    Vector3 eP;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        eP = particle.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < 2 && Input.GetMouseButtonDown(0))
        {
            playerControl.playerPos = new Vector3(0,0,0);
            SceneManager.LoadScene("outDoor");
        }
        else
        {
            if((player.transform.position - transform.position).magnitude < 2){ particle.transform.position = transform.position;if(!particle.isPlaying)particle.Play(); }
            else {
                particle.transform.position = new Vector3(1000f, 1000f, 1000f);
                particle.Stop();
            }
        }
    }
}
