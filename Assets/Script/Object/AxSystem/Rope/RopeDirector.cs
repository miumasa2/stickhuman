using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeDirector : MonoBehaviour
{
    private bool shake = false;
    private Rope rope;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject Rope = this.gameObject.transform.GetChild(0).gameObject;
        rope = Rope.GetComponent<Rope>();
    }

    public void RopeDirect()
    {
        if(shake)
            rope.CutRope();
    }

    public void AttackDirect(bool shake)
    {
        this.shake = shake;
    }
}
