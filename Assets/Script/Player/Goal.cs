using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private Player pr;

    void Start()
    {
        GameObject Player = GameObject.Find("player");
        pr = Player.GetComponent<Player>();
    }

    void OnCollisionStay2D(Collision2D other)
    {

        // �����ɏՓ˂����ꍇ�̔��]����
        if (other.gameObject.CompareTag("Player"))
        {
            //�I�u�W�F�N�g�̔j��
            Destroy(gameObject);
            //�V�[���J��
            SceneManager.LoadScene("QRcord");
        }
    }
}
