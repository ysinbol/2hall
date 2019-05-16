using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadController : ICharacterController {

    /// <summary>
    /// ブラックホールの左右移動
    /// </summary>
    /// <returns></returns>
    public Vector2 Black_HorizontalMove()
    {
        Vector2 velocity = Vector2.zero;

        if (Input.GetAxis("Horizontal") >= 0)
        {
            velocity.x = 1;
        }
        if (Input.GetAxis("Horizontal") <= 0)
        {
            velocity.x = -1;
        }

        return velocity;
    }

    /// <summary>
    /// ブラックホールの上下移動
    /// </summary>
    /// <returns></returns>
    public Vector2 Black_VerticalMove()
    {
        Vector2 velocity = Vector2.zero;

        if (Input.GetAxis("Vertical") >= 0)
        {
            velocity.x = 1;
        }
        if (Input.GetAxis("Vertical") <= 0)
        {
            velocity.x = -1;
        }

        return velocity;
    }

    /// <summary>
    /// ホワイトホールの左右移動
    /// </summary>
    /// <returns></returns>
    public Vector2 White_HorizontalMove()
    {
        Vector2 velocity = Vector2.zero;

        if (Input.GetAxisRaw("Horizontal2") >= 0)
        {
            velocity.x = 1;
        }
        if (Input.GetAxisRaw("Horizontal2") <= 0)
        {
            velocity.x = -1;
        }

        return velocity;
    }

    /// <summary>
    /// ホワイトホールの上下移動
    /// </summary>
    /// <returns></returns>
    public Vector2 White_VerticalMove()
    {
        return Vector2.zero;
    }

    public float MosuePositionX()
    {
        return 0;
    }

}
