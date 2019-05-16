using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metroite : MonoBehaviour {

    float fallSpeed = 5;

    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        fallSpeed = Random.Range(1, 10);
    }

    /// <summary>
    /// 落ちる速度の変更
    /// </summary>
    /// <param name="fallspeed"></param>
    public void RevrseFall()
    {
        this.fallSpeed = -fallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
        Death();
    }

    /// <summary>
    /// 下に落ちる
    /// </summary>
    void Fall()
    {
        float moveY = transform.position.y - fallSpeed * Time.deltaTime;
        
        transform.position = new Vector3
            (transform.position.x, moveY, 0);
    }

    [SerializeField]
    float screenBottomPosY = -7;
    /// <summary>
    /// 下の画面端に行ったら消える。
    /// </summary>
    void Death()
    {
        float posY = transform.position.y;
        if(posY < screenBottomPosY)
        {
            Destroy(this.gameObject);
        }
    }
}
