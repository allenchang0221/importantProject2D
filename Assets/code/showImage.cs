using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showImage : MonoBehaviour
{
    public RawImage myRawImage;

    void Start()
    {
        int n = 2;
        // 載入 Resources 資料夾內名為 MyPhoto 的圖片
        Texture2D texture = Resources.Load<Texture2D>(Random.Range(1,n+1).ToString());

        if (texture != null)
        {
            myRawImage.texture = texture;
        }
    }
}
