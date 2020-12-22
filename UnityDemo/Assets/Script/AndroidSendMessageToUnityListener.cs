
using System;
using UnityEngine;

public class AndroidSendMessageToUnityListener : AndroidJavaProxy
{
    private Action<string> callback;

    public AndroidSendMessageToUnityListener(Action<string> callback) : base("pers.study.android2unity.AndroidSendMessageToUnityListener")
    {
        this.callback = callback;
    }

    public void OnCallback(string json) {
        if (callback != null)
        {
            callback(json);
        }
    }

}
