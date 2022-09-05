using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKey("joystick button 2")) //箱コンのXボタンが押されたらif文の中に入る
        {
            Backmain();
        }
    }

    public void Backmain()
    {
        //メソッドの呼び出し
        StartCoroutine("back");
    }

    IEnumerator back()
    {
        //飛ぶ時の遅延
        yield return new WaitForSeconds(1.0f);
        //オブジェクトの破壊
        Destroy(gameObject);
        //飛ぶシーン名
        SceneManager.LoadScene("Title");
    }
}