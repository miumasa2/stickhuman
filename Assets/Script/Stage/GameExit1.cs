using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit1 : MonoBehaviour
{
    private float step_time; //�o�ߎ��ԗp�J�E���g
    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;�@//�o�ߎ��ԏ�����
    }

    // Update is called once per frame
    void Update()
    {
        //�o�ߎ��Ԃ��J�E���g
        step_time += Time.deltaTime;
        if(step_time >= 60.0f) //�U�O�b��Ƀ^�C�g����ʂɑJ��
        {
            SceneManager.LoadScene("Title");
        }
    }
}
