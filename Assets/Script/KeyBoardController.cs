using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : ICharacterController
{
    /// <summary>
    /// ブラックホールの左右移動
    /// </summary>
    /// <returns></returns>
    public Vector2 Black_HorizontalMove()
    {
        Vector2 velocity = Vector2.zero;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
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

        if (Input.GetKey(KeyCode.W))
        {
            velocity.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.y = -1;
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

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
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
        Vector2 velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity.y = -1;
        }

        return velocity;

    }

    /// <summary>
    /// マウスの位置
    /// </summary>
    /// <returns></returns>
    public float MosuePositionX()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        return objPos.x;
    }
}
