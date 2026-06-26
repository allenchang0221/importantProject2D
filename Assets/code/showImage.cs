using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showImage : MonoBehaviour
{
    public RawImage myRawImage;

    void Start()
    {
        // 載入 Resources 資料夾內名為 MyPhoto 的圖片
        Texture2D texture = Resources.Load<Texture2D>("null");

        if (texture != null)
        {
            myRawImage.texture = texture;
        }
    }
}
