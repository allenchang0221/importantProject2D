using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class createMonster : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject=Instantiate(monster);
    }
    List<GameObject> monsters=new List<GameObject> ();
    // Update is called once per frame
    void Update()
    {
        monsters = GameObject.FindGameObjectsWithTag("monster").ToList();
        Debug.Log(monsters.Count());
    }
}
