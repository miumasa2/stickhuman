using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKey("joystick button 2")) //���R����X�{�^���������ꂽ��if���̒��ɓ���
        {
            Backmain();
        }
    }

    public void Backmain()
    {
        //���\�b�h�̌Ăяo��
        StartCoroutine("back");
    }

    IEnumerator back()
    {
        //��Ԏ��̒x��
        yield return new WaitForSeconds(1.0f);
        //�I�u�W�F�N�g�̔j��
        Destroy(gameObject);
        //��ԃV�[����
        SceneManager.LoadScene("Title");
    }
}