using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoQuestion : MonoBehaviour
{
    GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("hunt");
    }
    int beHunted = 0;
    List<GameObject> monsters = GameObject.FindGameObjectsWithTag("monster").ToList();
    // Update is called once per frame
    void Update()
    {
        monsters = GameObject.FindGameObjectsWithTag("monster").ToList();
        foreach (GameObject moster in monsters)
        {
            if ((moster.transform.position - transform.position).magnitude < 0.5)
            {
                button.transform.position = new Vector2(1000, 1000);
                beHunted = monsters.IndexOf(moster);
                break;
            }
            else
            {
                button.transform.position = new Vector2(10000, 1000);
            }
        }
    }
    public void hunt()
    {
        monsters.RemoveAt(beHunted);
        SceneManager.LoadScene("question");
    }
}
