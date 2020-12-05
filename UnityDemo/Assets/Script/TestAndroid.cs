using UnityEngine;
using UnityEngine.UI;

public class TestAndroid : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        //调用继承unityplayerActivity 的 安卓activity 的非静态方法
        AndroidJavaClass jclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jcontext = jclass.GetStatic<AndroidJavaObject>("currentActivity");
        text.text = jcontext.Call<int>("add", 10, 30).ToString();
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

    private void showToast() {
        //调用继承unityplayerActivity 的 安卓activity 的 静态方法
        AndroidJavaClass jclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jcontext = jclass.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass loginObject = new AndroidJavaClass("pers.study.android2unity.SplashActivity");
        loginObject.CallStatic("showToast", jcontext); //给安卓传过去context 
    }
}
