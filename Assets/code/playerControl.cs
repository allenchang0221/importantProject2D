using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public static Vector2 playerPos = new Vector2(0, 0);
    public bool isTalking = false;
    public GameObject camera, mainNPC, textBox,textBoxContainGameObject;
    public Transform canvasTranform;
    TextMeshProUGUI textBoxContain, textBoxContainControl=null;
    GameObject controlNPC = null,controlTextBox;
    // Start is called before the first frame update
    void Start()
    {
        textBoxContain= textBoxContainGameObject.GetComponent<TextMeshProUGUI>();
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
            textBoxContainControl = Instantiate(textBoxContain, canvasTranform);
            textBoxContainControl.gameObject.SetActive(true);
            controlTextBox = Instantiate(textBox);
            controlNPC = Instantiate(mainNPC);
        }
        if (!isTalking)
        {
            Destroy(controlNPC);
            Destroy(textBoxContainControl.gameObject);
            Destroy(controlTextBox);
            controlNPC = null;
        }
        if (controlNPC != null)
        {
            controlNPC.transform.position = playerPos + new Vector2(mainNPC.transform.position.x, mainNPC.transform.position.y);
            if (clock % 240 > 120)
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
            if (rigidbody2D.totalForce.magnitude == 0)
            {
                rigidbody2D.velocity *= 0f;
            }
            else
            {
                if(rigidbody2D.velocity.magnitude>0)
                rigidbody2D.velocity *= 2 / rigidbody2D.velocity.magnitude;
            }
        }
        playerPos = transform.position;
    }
}
