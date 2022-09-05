using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDaihuku : MonoBehaviour
{
    public float dex;
    private int rev = 1;
    private Player pr;
    private bool dash;
    private Vector2 pos;
    public Vector2 range1, range2;

    void Start()
    {
        GameObject Player = GameObject.Find("player");
        pr = Player.GetComponent<Player>();
        pos = transform.position;
    }

    void Update()
    {
        transform.position += new Vector3(dex * Time.deltaTime * rev, 0, 0);
        if (transform.position.x < range1.x || transform.position.x > range2.x || transform.position.y < range1.y || transform.position.y > range2.y)
            transform.position = pos;
    }
}