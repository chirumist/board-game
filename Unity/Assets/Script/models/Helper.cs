using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Helper : MonoBehaviour
{
    private static string token = PlayerPrefs.GetString("access_token");
    private static string type = PlayerPrefs.GetString("token_type");

    internal static IEnumerator FetchData(string url, System.Action<string, bool> callback)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Authorization", type+" "+ token);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            callback(www.error, false);
        } else {
            callback(www.downloadHandler.text, true);
        }
    }

    internal static IEnumerator SendData(string url, WWWForm form, System.Action<string, bool> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                callback(www.error, false);
            } else {
                callback(www.downloadHandler.text, true);
            }
        }
    }

    public void checkAuth()
    {
        //PlayerPrefs.DeleteKey("access_token");
    }
}
