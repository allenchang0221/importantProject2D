using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class showImage : MonoBehaviour
{
    public RawImage myRawImage;
    Texture2D texture;
    public static bool correct = false;
    static char ans = 'Z';
    void Start()
    {
        int n = 2;
        List<Object> files = Resources.LoadAll("electronic").ToList();
        //載入 Resources 資料夾內名為 electronic 的圖片
        texture = (Texture2D)(files[Random.Range(0, files.Count)]);

        if (texture != null)
        {
            myRawImage.texture = texture;
        }
        correct=texture.name.Last()==ans;
    }
    private void Update()
    {
    }
    public void chooseAnswer(GameObject gameObject)
    {
        ans = gameObject.name[0];
    }
    public void submit()
    {
        SceneManager.LoadScene("showIsTrue");
    }
}
