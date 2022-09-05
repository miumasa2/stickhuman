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

        // 何かに衝突した場合の反転処理
        if (other.gameObject.CompareTag("Player"))
        {
            //オブジェクトの破壊
            Destroy(gameObject);
            //シーン遷移
            SceneManager.LoadScene("QRcord");
        }
    }
}
