using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manual : MonoBehaviour
{
    public void manualinfo()
    {
        //���\�b�h�̌Ăяo��
        StartCoroutine("ManualInfo");
    }

    IEnumerator ManualInfo()
    {
        //��Ԏ��̒x��
        yield return new WaitForSeconds(1.0f);
        //�I�u�W�F�N�g�̔j��
        Destroy(gameObject);
        //��ԃV�[����
        SceneManager.LoadScene("Manual");
    }
}