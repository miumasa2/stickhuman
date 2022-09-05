using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manual : MonoBehaviour
{
    public void manualinfo()
    {
        //メソッドの呼び出し
        StartCoroutine("ManualInfo");
    }

    IEnumerator ManualInfo()
    {
        //飛ぶ時の遅延
        yield return new WaitForSeconds(1.0f);
        //オブジェクトの破壊
        Destroy(gameObject);
        //飛ぶシーン名
        SceneManager.LoadScene("Manual");
    }
}