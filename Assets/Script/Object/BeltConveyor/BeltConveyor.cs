using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyor : MonoBehaviour
{
    public bool IsOn = false;
    public float TargetDriveSpeed = 3.0f;
    private Vector2 DriveDirection;
    [SerializeField] private float _forcePower = 50f;
    private List<Rigidbody2D> _rigidbodies = new List<Rigidbody2D>();
    public string Direction;

    void Start()
    {
        switch (Direction)
        {
            case "right":
                DriveDirection = Vector2.right;
                break;

            case "left":
                DriveDirection = Vector2.left;
                break;
            default:
                DriveDirection = Vector2.right;
                break;
        }
                //方向は正規化しておく
                DriveDirection = DriveDirection.normalized;
    }

    void FixedUpdate()
    {
        // _currentSpeed = IsOn ? TargetDriveSpeed : 0;
        if (IsOn == true)
        {
            //消滅したオブジェクトは除去する
            _rigidbodies.RemoveAll(r => r == null);

            foreach (var r in _rigidbodies)
            {
                //物体の移動速度のベルトコンベア方向の成分だけを取り出す
                var objectSpeed = Vector2.Dot(r.velocity, DriveDirection);

                //目標値以下なら加速する
                if (objectSpeed < Mathf.Abs(TargetDriveSpeed))
                {
                    r.AddForce(DriveDirection * _forcePower, ForceMode2D.Force);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var rigidBody = other.gameObject.GetComponent<Rigidbody2D>();
        _rigidbodies.Add(rigidBody);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        var rigidBody = other.gameObject.GetComponent<Rigidbody2D>();
        _rigidbodies.Remove(rigidBody);
    }

    public void setDirection(string Direction)
    {
        this.Direction = Direction;

        if (Direction == "right")
            DriveDirection = Vector2.right;
        else if (Direction == "left")
            DriveDirection = Vector2.left;
    }

    public string getDirection
    {
        get { return this.Direction; }
    }
}
