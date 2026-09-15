using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class createMonster : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    List<GameObject> monsters=new List<GameObject> ();
    // Update is called once per frame
    void Update()
    {
        monsters = GameObject.FindGameObjectsWithTag("monster").ToList();
        //Debug.Log(monsters.Count());
        if (monsters.Count < 5)
        {
            monsters.Add(Instantiate(monster));
            monsters[monsters.Count - 1].transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        }
        foreach (var m in monsters) 
        {
            m.transform.Translate(new Vector2(Random.Range((1 / -60f), (1 / 60f)), Random.Range((1 / -60f), (1/60f))));
        }
    }
}
