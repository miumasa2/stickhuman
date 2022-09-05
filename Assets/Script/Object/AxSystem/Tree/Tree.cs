using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] Sprite ts;
    private SpriteRenderer tsr;
    private TreeDirector td;
    private PolygonCollider2D[] pc2d;
    [SerializeField] Vector2 Position;

    void Start()
    {
        tsr = gameObject.GetComponent<SpriteRenderer>();
        pc2d = this.gameObject.GetComponents<PolygonCollider2D>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            this.gameObject.transform.SetSiblingIndex(0);
        }
    }

    public void CutTree()
    {
        pc2d[0].enabled = false;
        pc2d[1].enabled = true;
        tsr.sprite = ts;
        this.tag = "AfterTree";
        this.gameObject.transform.localPosition = Position;
    }
}
