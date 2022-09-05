using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit1 : MonoBehaviour
{
    private float step_time; //経過時間用カウント
    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;　//経過時間初期化
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間をカウント
        step_time += Time.deltaTime;
        if(step_time >= 60.0f) //６０秒後にタイトル画面に遷移
        {
            SceneManager.LoadScene("Title");
        }
    }
}
