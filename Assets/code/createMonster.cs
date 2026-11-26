using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class createMonster : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        while (monstersPos.Count < 5)
        {
            monstersPos.Add(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)));
        }
        foreach (var pos in monstersPos)
        {
            GameObject copy= Instantiate(monster);
            copy.transform.position = pos;
            copy.GetComponent<SpriteRenderer>().sprite= Resources.LoadAll<Sprite>("monsterImage").ToList()[(int)Mathf.Abs(pos.x*pos.y*100)% 60];
        }
    }
    public static List<Vector2> monstersPos = new List<Vector2>();
    void Update()
    {
        
    }
}
