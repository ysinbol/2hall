using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHallController : HallController {

    ICharacterController controller;    //コントローラ

    [SerializeField]
    float moveSpeed = 1;                //移動スピード
    GameObject whiteHall;
    GameObject meteroite;
    WhiteHallController whiteH_Controller;
    Animator anim;


    // Use this for initialization
    void Start () {
        Initialize();

    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        controller = GameManager.Instance.GetController();
        whiteHall = GameObject.Find("WhiteHall");
        whiteH_Controller = whiteHall.GetComponent<WhiteHallController>();
        anim = GetComponent<Animator>();

        InitRestrictionsData();
    }



    // Update is called once per frame
    void Update () {
        Move();
        
	}

    /// <summary>
    ///　移動
    /// </summary>
    private void Move()
    {
        Vector2 velocity = Vector2.zero;

        velocity += controller.White_HorizontalMove();

        float moveX = transform.position.x + velocity.x * moveSpeed * Time.deltaTime;
        moveX = MovementRestrictions(moveX);

        transform.position = new Vector3(moveX, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //隕石を入れる
        if (!col.tag.Equals("meteroite")) return;

        //ホワイトホールから吐き出された隕石を再び吸い込まないようにタグを改名
        col.gameObject.tag = "Emit_meteroite";

        Vector3 meteroiteScale = col.transform.localScale;
        col.transform.localScale = new Vector3(meteroiteScale.x, -meteroiteScale.y, 1);

        //隕石の位置をホワイトホールの位置に移動させる
        col.transform.position = whiteHall.transform.position;

        //隕石の方向を反転させてホワイトホールから吐き出せるようにする
        col.gameObject.GetComponent<Metroite>().RevrseFall();

        PlayAnimEmit("absorption");
        whiteH_Controller.PlayAnimEmit("Emit");
    }

    public void PlayAnimEmit(string animName)
    {
        //if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.9f) return;
        anim.SetTrigger(animName);
    }

}
