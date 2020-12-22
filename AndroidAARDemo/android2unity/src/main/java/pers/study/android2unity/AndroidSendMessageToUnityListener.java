package pers.study.android2unity;

public interface AndroidSendMessageToUnityListener {
    /**
     * 定义接口返回格式 可自定义 可以定义json  自己解析
     * @param json
     */
    void OnCallback(String json);
}
