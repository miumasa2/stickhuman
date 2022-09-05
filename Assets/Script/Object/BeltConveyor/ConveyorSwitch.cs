using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSwitch : MonoBehaviour
{
    private bool switching = false;
    public BeltConveyor bc;
    private string direction;
    public Sprite s_right;
    public Sprite s_left;
    private SpriteRenderer cssr;

    void Start()
    {
        direction = bc.getDirection;
        cssr = gameObject.GetComponent<SpriteRenderer>();
        if (direction == "right")
            cssr.sprite = s_right;        
        else           
            cssr.sprite = s_left;
    }

    void Update()
    {
        if (Input.GetKeyDown("left ctrl") && switching == true)
        {
            if (direction == "right")
            {
                direction = "left";
                cssr.sprite = s_left;
            }
            else
            {
                direction = "right";
                cssr.sprite = s_right;
            }

            bc.setDirection(direction);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            switching = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            switching = false;
    }
}
