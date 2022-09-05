using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float dex; // ‘¬‚³
    [SerializeField] int rev;       // Œü‚«
    private Player pr;
    private Vector2 pos;
    [SerializeField] Vector2 range1, range2;
    Rigidbody2D rb2d;

    void Start()
    {
        GameObject Player = GameObject.Find("player");
        pr = Player.GetComponent<Player>();
        pos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // dex‚Ì‘¬‚³•ª“™‘¬ˆÚ“®
        transform.position += new Vector3(dex * Time.deltaTime * rev, 0, 0);
        if (transform.position.x < range1.x)
        {
            rev = 1;//is•ûŒü‚Ì”½“]
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (transform.position.x > range2.x)
        {
            rev = -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        // ‰½‚©‚ÉÕ“Ë‚µ‚½ê‡‚Ì”½“]ˆ—
        if (!other.gameObject.CompareTag("Ground") && !other.gameObject.CompareTag("BeltConveyor"))
        {
            if (!(!other.gameObject.CompareTag("Player") || pr.jump))
            {
                Destroy(gameObject);
            }

            rev *= -1;          //is•ûŒü‚Ì”½“]
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z * -1);
        }
    }

}
