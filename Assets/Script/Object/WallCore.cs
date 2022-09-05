using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCore: MonoBehaviour
{
    private int speed = 6;
    private bool on = false;
    private bool down = false;
    public bool vertical, horizontal;

    void Start()
    {
        /*if (vertical == true)
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        if (horizontal == true)
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;*/
    }

    void Update()
    {
        if (down == true)
        {
            if (vertical == true)
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            if (horizontal == true)
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    public void SlideUP()
    {
        if (vertical == true)
        {
            down = false;
            on = true;
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);    // 壁の上昇 
        }
        else if(horizontal == true)
        {
            down = false;
            on = true;
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") && on == true)
        {
            speed = 0;
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;   // 位置固定
        }

        if (other.gameObject.CompareTag("Ground") && down == true)
        {
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;   // 位置固定
            down = false;
            speed = 6;
        }
    }

    public void SlideDOWN()
    {
        if (vertical == true)
        {
            on = false;
            down = true;
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            speed = 6;
        }
        else if (horizontal == true)
        {
            on = false;
            down = true;
            speed = 6;
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}

