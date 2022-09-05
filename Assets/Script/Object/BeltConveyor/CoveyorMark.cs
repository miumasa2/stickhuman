using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoveyorMark : MonoBehaviour
{
    public BeltConveyor bc;
    private string direction;

    void Start()
    {
        direction = bc.getDirection;
        if (direction == "right")
            this.gameObject.transform.localRotation = new Quaternion(-180, 0, 0, 0);
        else if (direction == "left")
            this.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
    
    void Update()
    {
        if (direction != bc.getDirection)
        {
            direction = bc.getDirection;
            if (direction == "right")
                this.gameObject.transform.localRotation = new Quaternion(-180, 0, 0, 0);
            else if (direction == "left")
                this.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        if (direction == "right")
            transform.Rotate(new Vector3(0, 0, 1.0f));
        else if (direction == "left")
            transform.Rotate(new Vector3(0, 0, 1.0f));
    }
}
