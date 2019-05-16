using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteHallController : HallController {

    ICharacterController controller;

    [SerializeField]
    float moveSpeed = 1;
    Animator anim;

    // Use this for initialization
    void Start () {
        Initialize();

    }

    private void Initialize()
    {
        controller = GameManager.Instance.GetController();
        anim = GetComponent<Animator>();

        InitRestrictionsData();
    }

    // Update is called once per frame
    void Update ()    {
        //Move();
        MouseMove();
	}

    /// <summary>
    /// 移動
    /// </summary>
    private void Move(){
        Vector2 velocity = Vector2.zero;

        velocity += controller.White_HorizontalMove();

        float moveX = transform.position.x + velocity.x * moveSpeed * Time.deltaTime;
        moveX = MovementRestrictions(moveX);

        transform.position = new Vector3(moveX, transform.position.y, 0);
        
    }

    private void MouseMove()
    {
        Vector2 velocity = Vector2.zero;

        float moveX = controller.MosuePositionX();
        moveX = MovementRestrictions(moveX);

        transform.position = new Vector3(moveX, transform.position.y, 0);

    }

    public void PlayAnimEmit(string animName)
    {
        anim.SetTrigger(animName);
    }

}
