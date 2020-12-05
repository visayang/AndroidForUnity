package pers.study.android2unity;

import android.content.Context;
import android.os.Bundle;
import android.widget.Toast;

import com.unity3d.player.UnityPlayerActivity;

public class SplashActivity extends UnityPlayerActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    //新增方法供unity 调用
    public int add(int a,int b) {
        return  a+b;
    }

    //新增方法供unity 调用
    public static void showToast(Context context) {
        Toast.makeText(context, "安卓发起 土司", Toast.LENGTH_SHORT).show();
    }
}
