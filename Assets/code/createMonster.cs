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
    public static List<Vector2> monstersPos = new List<Vector2>();
    // Update is called once per frame
    void Update()
    {
        List<GameObject> monsters = GameObject.FindGameObjectsWithTag("monster").ToList();
        //Debug.Log(monsters.Count());
        if (monsters.Count < 5)
        {
            GameObject copy = Instantiate(monster);
            monsters.Add(copy);
            if (monstersPos.Count < monsters.Count)
            {
                monstersPos.Add(new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)));
            }
            monsters[monsters.Count - 1].transform.position = monstersPos[monsters.Count - 1];

        }
        for (int i = 0; i < monsters.Count; i++)
        {
            monsters[i].transform.Translate(new Vector2(Random.Range((1 / -60f), (1 / 60f)), Random.Range((1 / -60f), (1 / 60f))));
        }
    }
}
