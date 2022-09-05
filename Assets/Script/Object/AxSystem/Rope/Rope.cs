using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] Sprite rs;
    private SpriteRenderer rsr;
    private RopeDirector rd;

    void Start()
    {
        rsr = gameObject.GetComponent<SpriteRenderer>();
        //GameObject RopeDirector = this.gameObject.transform.parent.gameObject;
        //rd = RopeDirector.GetComponent<RopeDirector>();
    }

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            this.gameObject.transform.SetSiblingIndex(0);
            //rd.RopeDirect();
        }
    }

    public void CutRope()
    {
        rsr.sprite = rs;
        this.tag = "AfterRope";
    }
}