using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title2 : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKey("joystick button 3"))�@//���R����Y�{�^���������ꂽ��if���̒��ɓ���
        {
            //��ԃV�[����
           Startmain();
        }

        if (Input.GetKey("joystick button 2")) //���R����X�{�^���������ꂽ��if���̒��ɓ���
        {
            //��ԃV�[����
            Manualmain();
        }
    }
    public void Startmain()
    {
        //���\�b�h�̌Ăяo��
        StartCoroutine("GameStart");
    }

    public void Manualmain()
    {
        //���\�b�h�̌Ăяo��
        StartCoroutine("ManualStart");
    }

    IEnumerator GameStart()
    {
        //��Ԏ��̒x��
        yield return new WaitForSeconds(1.0f);
        //�I�u�W�F�N�g�̔j��
        Destroy(gameObject);
        //��ԃV�[����
        SceneManager.LoadScene("Stage1");
    }
    IEnumerator ManualStart()
    {
        //��Ԏ��̒x��
        yield return new WaitForSeconds(1.0f);
        //�I�u�W�F�N�g�̔j��
        Destroy(gameObject);
        //��ԃV�[����
        SceneManager.LoadScene("Manual");
    }
}