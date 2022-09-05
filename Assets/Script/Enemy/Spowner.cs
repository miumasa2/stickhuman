using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spowner : MonoBehaviour
{
    private GameObject enemy;

    void Start()
    {
        enemy = this.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            enemy.SetActive(true);
        }
    }
}
