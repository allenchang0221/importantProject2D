using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public static Vector2 playerPos = new Vector2(0, 0);
    public bool isTalking = false;
    public GameObject camera, mainNPC, textBox;
    GameObject controlNPC = null;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerPos;
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }
    int clock = 0;
    // Update is called once per frame
    void Update()
    {
        clock++;
        if (isTalking && controlNPC == null)
        {
            controlNPC = Instantiate(mainNPC);
        }
        if (!isTalking)
        {
            Destroy(controlNPC);
            controlNPC = null;
        }
        if (controlNPC != null)
        {
            controlNPC.transform.position = playerPos + new Vector2(mainNPC.transform.position.x, mainNPC.transform.position.y);
            if (clock % 500 > 250)
            {
                controlNPC.transform.localScale = Vector3.one * 1.1f;
            }
            else
            {
                controlNPC.transform.localScale = Vector3.one;
            }
        }
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        if (!isTalking)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //transform.Translate(0, 1, 0);
                rigidbody2D.AddForce(new Vector2(0, 1) * 50);
            }
            if (Input.GetKey(KeyCode.A))
            {
                //transform.Translate(-1, 0, 0);
                rigidbody2D.AddForce(new Vector2(-1, 0) * 50);
            }
            if (Input.GetKey(KeyCode.S))
            {
                //transform.Translate(0, -1, 0);
                rigidbody2D.AddForce(new Vector2(0, -1) * 50);
            }
            if (Input.GetKey(KeyCode.D))
            {
                //transform.Translate(1, 0, 0);
                rigidbody2D.AddForce(new Vector2(1, 0) * 50);
            }
        }
        if (rigidbody2D.totalForce.magnitude == 0)
        {
            rigidbody2D.velocity *= 0f;
        }
        else
        {
            rigidbody2D.velocity *= 2 / rigidbody2D.velocity.magnitude;
        }
        playerPos = transform.position;
    }
}
