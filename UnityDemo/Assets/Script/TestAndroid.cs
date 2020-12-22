using System;
using UnityEngine;
using UnityEngine.UI;

public class TestAndroid : MonoBehaviour
{
    public Text text;
    public Button button;
    public Text text2;
    // Start is called before the first frame update


    public AndroidSendMessageToUnityListener listener;

    void Start()
    {
        if (listener == null) {
            listener = new AndroidSendMessageToUnityListener(CallBack);
        }
        AndroidJavaObject helper = new AndroidJavaObject("pers.study.android2unity.Helper");
        helper.Call("setAndroudForUntiyListener", listener);


        //调用继承unityplayerActivity 的 安卓activity 的非静态方法
        AndroidJavaClass jclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jcontext = jclass.GetStatic<AndroidJavaObject>("currentActivity");
        text.text = jcontext.Call<int>("add", 10, 30).ToString();

        button.onClick.AddListener(SendMsg);
    }

    private void SendMsg()
    {
        AndroidJavaObject helper = new AndroidJavaObject("pers.study.android2unity.Helper");
        helper.CallStatic("getMessageFormUnity", "我是 unity ===");

    }

    private void CallBack(string json)
    {
        if (!String.IsNullOrEmpty(json)) {
            text2.text = json;
        }
    }

    // Unity 监听手机按返系统回键
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showToast();
            
            Application.Quit();
        }
    }


    private void OnDestroy()
    {
        listener = null;
        button.onClick.RemoveListener(SendMsg);
    }

    private void showToast() {
        //调用继承unityplayerActivity 的 安卓activity 的 静态方法
        AndroidJavaClass jclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jcontext = jclass.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass loginObject = new AndroidJavaClass("pers.study.android2unity.SplashActivity");
        loginObject.CallStatic("showToast", jcontext); //给安卓传过去context 
    }
}
