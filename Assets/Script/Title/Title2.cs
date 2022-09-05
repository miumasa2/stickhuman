using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title2 : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKey("joystick button 3"))　//箱コンのYボタンが押されたらif文の中に入る
        {
            //飛ぶシーン名
           Startmain();
        }

        if (Input.GetKey("joystick button 2")) //箱コンのXボタンが押されたらif文の中に入る
        {
            //飛ぶシーン名
            Manualmain();
        }
    }
    public void Startmain()
    {
        //メソッドの呼び出し
        StartCoroutine("GameStart");
    }

    public void Manualmain()
    {
        //メソッドの呼び出し
        StartCoroutine("ManualStart");
    }

    IEnumerator GameStart()
    {
        //飛ぶ時の遅延
        yield return new WaitForSeconds(1.0f);
        //オブジェクトの破壊
        Destroy(gameObject);
        //飛ぶシーン名
        SceneManager.LoadScene("Stage1");
    }
    IEnumerator ManualStart()
    {
        //飛ぶ時の遅延
        yield return new WaitForSeconds(1.0f);
        //オブジェクトの破壊
        Destroy(gameObject);
        //飛ぶシーン名
        SceneManager.LoadScene("Manual");
    }
}