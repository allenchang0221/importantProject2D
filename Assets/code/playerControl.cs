using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {

        rigidbody2D=this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(transform.position.x,transform.position.y,camera.transform.position.z);
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, 1, 0);
            //rigidbody2D.AddForce(new Vector2(0, 1)*10);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-1, 0, 0);
            //rigidbody2D.AddForce(new Vector2(-1, 0) * 10);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -1, 0);
            //rigidbody2D.AddForce(new Vector2(0, -1) * 10);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(1, 0, 0);
            //rigidbody2D.AddForce(new Vector2(1, 0) * 10);
        }
    }
}
