using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallController : MonoBehaviour {

    Camera mainCamera;

    protected void Init()
    {
        mainCamera = Camera.main;
    }

    float leftEnd;      //左端
    float rightEnd;     //右端
    float width;
    float height;

    /// <summary>
    /// スクリーンの端の座標を得る
    /// </summary>
    protected void InitRestrictionsData()
    {
        //左端
        leftEnd  = Camera.main.ViewportToWorldPoint(Vector2.zero).x;
        //右端
        rightEnd = Camera.main.ViewportToWorldPoint(Vector2.one).x;

        //画像の幅
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        //画像の高さ
        height = GetComponent<SpriteRenderer>().bounds.size.y;

        leftEnd += width / 2;
        rightEnd -= width / 2;

    }

    /// <summary>
    /// 移動制限
    /// </summary>
    protected float MovementRestrictions(float moveX)
    {
        if (moveX < leftEnd)
        {
            moveX = leftEnd;
        }
        if (moveX > rightEnd)
        {
            moveX = rightEnd;
        }

        return moveX;
    }



}
