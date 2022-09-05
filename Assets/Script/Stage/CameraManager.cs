using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;

        //カメラとプレイヤーの位置を同じにする
        transform.position = new Vector3(playerPos.x,playerPos.y+2,-10 );
    }
}
