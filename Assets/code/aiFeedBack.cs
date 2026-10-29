using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class aiFeedBack : MonoBehaviour
{
    private string apiKey;
    private string modelName = "gemini-3.8-flash";

    [Serializable]
    public class Part
    {
        public string text;
    }

    [Serializable]
    public class Content
    {
        public Part[] parts;
    }

    [Serializable]
    public class RequestData
    {
        public Content[] contents;
    }

    [Serializable]
    public class Candidate
    {
        public Content content;
    }

    [Serializable]
    public class ResponseData
    {
        public Candidate[] candidates;
    }

    void Start()
    {
        Debug.Log("① Start() 已執行");

        string key = System.Environment.GetEnvironmentVariable(
            "GEMINI_API_KEY",
            System.EnvironmentVariableTarget.User
        );

        Debug.Log(
            string.IsNullOrWhiteSpace(key)
                ? "② 使用者環境變數讀取失敗"
                : "② 成功讀取使用者環境變數"
        );

        if (string.IsNullOrWhiteSpace(key))
            return;

        apiKey = key;

        Debug.Log("③ 準備呼叫 Gemini");
        StartCoroutine(SendToGemini("你好"));
    }

    IEnumerator SendToGemini(string prompt)
    {
        Debug.Log("④ SendToGemini 協程已開始");
        string url =
            "https://generativelanguage.googleapis.com/" +
            "v1beta/models/" + modelName + ":generateContent";

        // 建立請求 JSON
        RequestData data = new RequestData
        {
            contents = new Content[]
            {
                new Content
                {
                    parts = new Part[]
                    {
                        new Part { text = prompt }
                    }
                }
            }
        };

        string jsonBody = JsonUtility.ToJson(data);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);

        using (UnityWebRequest request =
            new UnityWebRequest(url, "POST"))
        {
            request.uploadHandler =
                new UploadHandlerRaw(bodyRaw);

            request.downloadHandler =
                new DownloadHandlerBuffer();

            request.SetRequestHeader(
                "Content-Type", "application/json");

            request.SetRequestHeader(
                "x-goog-api-key", apiKey);
            request.timeout = 60;

            Debug.Log("⑤ URL 已建立，準備送出請求");
            Debug.Log("⑥ JSON 長度：" + bodyRaw.Length);

            UnityWebRequestAsyncOperation operation;

            try
            {
                operation = request.SendWebRequest();
                Debug.Log("⑦ 已呼叫 SendWebRequest()");
            }
            catch (Exception e)
            {
                Debug.LogError("送出請求時發生例外：" + e);
                yield break;
            }
            float elapsed = 0f;

            while (!operation.isDone && elapsed < 70f)
            {
                Debug.Log(
                    "請求進行中，已等待：" +
                    elapsed.ToString("F0") +
                    " 秒"
                );

                yield return new WaitForSecondsRealtime(1f);
                elapsed += 1f;
            }

            if (!operation.isDone)
            {
                Debug.LogError("請求超過 70 秒仍未完成，準備中止。");
                request.Abort();

                yield return null;
            }

            Debug.Log("⑧ 協程恢復執行");
            Debug.Log("HTTP 狀態碼：" + request.responseCode);
            Debug.Log("請求結果：" + request.result);
            Debug.Log("錯誤訊息：" + request.error);

            Debug.Log("⑧ 請求已完成");
            Debug.Log("HTTP 狀態碼：" + request.responseCode);
            Debug.Log("請求結果：" + request.result);
            Debug.Log("錯誤訊息：" + request.error);
            Debug.Log("⑨ API 原始回應：" +
    request.downloadHandler.text);
            if (request.result ==
                UnityWebRequest.Result.Success)
            {
                string jsonResponse =
                    request.downloadHandler.text;

                ResponseData result = null;

                try
                {
                    result = JsonUtility.FromJson<ResponseData>(
                        jsonResponse
                    );
                }
                catch (Exception e)
                {
                    Debug.LogError("JSON 解析失敗：" + e.Message);
                }

                if (result != null &&
                    result.candidates != null &&
                    result.candidates.Length > 0 &&
                    result.candidates[0].content != null &&
                    result.candidates[0].content.parts != null)
                {
                    StringBuilder answer = new StringBuilder();

                    foreach (Part part in
                        result.candidates[0].content.parts)
                    {
                        if (part != null && part.text != null)
                            answer.Append(part.text);
                    }

                    Debug.Log("Gemini 回答：" + answer);
                }
                else
                {
                    Debug.LogWarning(
                        "API 有回應，但沒有可顯示的文字：" +
                        jsonResponse
                    );
                }
            }
            else
            {
                Debug.LogError(
                    "HTTP 狀態碼：" + request.responseCode +
                    "\n錯誤：" + request.error +
                    "\n回應：" + request.downloadHandler.text
                );
            }
        }
    }
}
