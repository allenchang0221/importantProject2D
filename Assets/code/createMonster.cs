using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMonster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    List<GameObject> monsters=new List<GameObject> ();
    // Update is called once per frame
    void Update()
    {
        monsters = GameObject.FindGameObjectsWithTag("monster").ToList();
        Debug.Log(monsters[0].name);
    }
}
