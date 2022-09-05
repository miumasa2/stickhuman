using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDirector : MonoBehaviour
{
    private Tree tree;

    void Start()
    {
        GameObject Tree = this.gameObject.transform.GetChild(0).gameObject;
        tree = Tree.GetComponent<Tree>();
    }

    void Update()
    {
        
    }

    public void TreeDirect()
    {
        tree.CutTree();
    }
}
