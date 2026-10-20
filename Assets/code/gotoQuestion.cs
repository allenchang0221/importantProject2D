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
        monsters = GameObject.FindGameObjectsWithTag("monster").ToList();
        huntButtonOriginalPos = button.transform.position;
    }
    Vector2 huntButtonOriginalPos;
    int beHunted = 0;
    List<GameObject> monsters;
    // Update is called once per frame
    void Update()
    {
        foreach (Vector2 pos in createMonster.monstersPos)
        {
            if ((pos - new Vector2(transform.position.x,transform.position.y)).magnitude < 0.5)
            {
                button.transform.position = huntButtonOriginalPos;
                beHunted = createMonster.monstersPos.IndexOf(pos);
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
        createMonster.monstersPos.RemoveAt(beHunted);
        SceneManager.LoadScene("question");
    }
}
