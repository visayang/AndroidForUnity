package pers.study.android2unity;

import android.util.Log;

public class Helper {

    //这里如果不写 静态 就写为 单例 一样的
    private static AndroidSendMessageToUnityListener listener;

    public void setAndroudForUntiyListener(AndroidSendMessageToUnityListener listener2) {
        this.listener = listener2;
    }

    //当untiy 绑定了接口后 就可以发送消息到 unity 了
    public static void setLoginResponseToUnity(String json){
        if (listener != null) {
            listener.OnCallback(json);
        }
    }

    /**
     * 这个方法 可由Unity 某个条件出发，然后由 安卓端处理数据 再返回 unity；也可以安卓端主动调用，发送消息给 unity
     * @param json
     */
    public static void getMessageFormUnity(String json){
        setLoginResponseToUnity(json.replace("unity","android"));
    }

}
