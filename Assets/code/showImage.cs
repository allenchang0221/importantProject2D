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
    public static char correct = 'A';
    public Vector2 Vector2 = new Vector2();

    public static char ans = 'Z';
    void Start()
    {
        int n = 2;
        List<Texture2D> files = Resources.LoadAll<Texture2D>("electronic").ToList();
        //載入 Resources 資料夾內名為 electronic 的圖片
        texture = (Texture2D)(files[Random.Range(0, files.Count - 1)]);

        if (texture != null)
        {
            myRawImage.texture = texture;
            //myRawImage.GetComponent<AspectRatioFitter>().aspectRatio = texture.width / texture.height;
            //myRawImage.SetNativeSize();
            float longSide = Mathf.Max((float)texture.width, (float)texture.height);
            myRawImage.transform.localScale =10* new Vector2((float)texture.width / longSide, (float)texture.height*2 / longSide);
            //Vector2 = myRawImage.rectTransform.sizeDelta;

        }
        correct = texture.name.Last();
        Debug.Log(texture.name);
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
