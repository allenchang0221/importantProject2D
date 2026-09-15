using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class showImage : MonoBehaviour
{
    public RawImage myRawImage;

    void Start()
    {
        int n = 2;
        List<Object> files = Resources.LoadAll("electronic").ToList();
        // 載入 Resources 資料夾內名為 MyPhoto 的圖片
        Texture2D texture = Resources.Load<Texture2D>(files[Random.Range(0,files.Count)].name);

        if (texture != null)
        {
            myRawImage.texture = texture;
        }
    }
    private void Update()
    {
        int n = 2;
        List<Object> files = Resources.LoadAll("electronic").ToList();
         //載入 Resources 資料夾內名為 MyPhoto 的圖片
        Texture2D texture = (Texture2D)(files[Random.Range(0, files.Count - files.Count)]);

        if (texture != null)
        {
            myRawImage.texture = texture;
        }
        Debug.Log(Resources.Load<Texture2D>(files[Random.Range(0, files.Count)].name));
    }
}
