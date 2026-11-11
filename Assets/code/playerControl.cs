using System;
using System.IO;
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
    Animator animator;
    int idx = 0;
    string[] data;
    // Start is called before the first frame update
    void Start()
    {
        textBoxContain= textBoxContainGameObject.GetComponent<TextMeshProUGUI>();
        transform.position = playerPos;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        data=File.ReadAllText(Path.Combine(Application.dataPath, "Resources/beginDialog.txt")).Replace("\r","").Split("\n",StringSplitOptions.RemoveEmptyEntries);
    }
    int clock = 0,subStringIdx=0;
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
            idx = 0;
            try
            {
                Destroy(controlNPC);
                Destroy(textBoxContainControl.gameObject);
                Destroy(controlTextBox);
                controlNPC = null;
            }
            catch { }
        }
        else
        {
            textBoxContainControl.text = data[idx%data.Length].Substring(0,Math.Min(data[idx%data.Length].Length,subStringIdx));
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
            if (subStringIdx-30> data[idx % data.Length].Length)
            {
                idx++;
                subStringIdx = 0;
            }
            if (clock % 6 == 0)
            {
                subStringIdx++;
            }
        }
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        if (!isTalking)
        {
            animator.speed = 1;
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 1/60f, 0);
                //rigidbody2D.AddForce(new Vector2(0, 1) * 50);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-1/60f, 0, 0);
                //rigidbody2D.AddForce(new Vector2(-1, 0) * 50);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, -1/60f, 0);
                //rigidbody2D.AddForce(new Vector2(0, -1) * 50);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(1/60f, 0, 0);
                //rigidbody2D.AddForce(new Vector2(1, 0) * 50);
            }
            //if (rigidbody2D.totalForce.magnitude == 0)
            //{
            //    rigidbody2D.velocity *= 0f;
            //}
            else
            {
                //if(rigidbody2D.velocity.magnitude>0)
                //rigidbody2D.velocity = Vector2.zero;
                animator.speed = 0;
            }
        }
        playerPos = transform.position;
    }
}
