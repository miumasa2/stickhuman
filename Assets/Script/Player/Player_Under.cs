using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Under : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnterGround;
    [SerializeField] UnityEvent OnExitGround;
    [SerializeField] Animator animator;

    // 地面、オブジェクトの接触判定
    void OnTriggerStay2D(Collider2D other)
    {
        animator.SetBool("jump", false);
        animator.SetBool("jumping", false);
        if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Rope"))
        {
            OnEnterGround.Invoke();
        }
    }

    //空中のジャンプ不可設定
    void OnTriggerExit2D(Collider2D other)
    {
        OnExitGround.Invoke();
        animator.SetBool("jumping", true);
    }
}
