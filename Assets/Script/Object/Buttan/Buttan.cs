using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttan : MonoBehaviour
{
    private BoxCollider2D[] bc2d;
    private SpriteRenderer bsr;
    private Sprite bbs;
    [SerializeField] Sprite abs;
    private ButtanDirector bds;
    private bool on = false;
    [SerializeField] int color;

    void Start()
    {
        bc2d = this.gameObject.GetComponents<BoxCollider2D>();
        bsr = gameObject.GetComponent<SpriteRenderer>();
        bbs = bsr.sprite;
        GameObject ButtanDirector = this.gameObject.transform.parent.gameObject;
        bds = ButtanDirector.GetComponent<ButtanDirector>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Under") && !on)
        {
            on = true;
            bc2d[1].enabled = false;
            bsr.sprite = abs;
            bds.ButtanNumberDirector(color);
        }
    }

    public void Reset()
    {
        bc2d[1].enabled = true;
        bsr.sprite = bbs;
        on = false;
    }
}
