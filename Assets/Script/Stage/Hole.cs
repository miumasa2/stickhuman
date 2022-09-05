using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //public Vector2 pos;               // 値の取得
    GameObject HP;                      // HPスクリプト
    HP hp;                              // HPクラス

    private void Start()
    {
        HP = GameObject.Find("H");      // HPをオブジェクトの名前から取得して変数に格納
        hp = HP.GetComponent<HP>();     // HPの中にあるHPを取得して変数に格納
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.transform.position = new Vector2(pos.x, pos.y);      // ワープ判定
            //hp.Damage();
            hp.ollDamage();
        }
    }
}
