using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    float fallSpeed = 1;

    [SerializeField]
    float fallSpeedMin;

    [SerializeField]
    float fallSpeedMax;

    private AudioSource audio;
    public AudioClip crushing;
    private BoxCollider2D colider;
    private SpriteRenderer renderer;
    Timer waitFrameTimer;

    // Use this for initialization
    void Start()
    {
        FallSpeedSet();
        audio = GetComponent<AudioSource>();
        colider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        clipPlayTime = new Timer(audio.clip.length);

        audio.clip = crushing;
        waitFrameTimer = new Timer(0.06f);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void FallSpeedSet()
    {
        fallSpeed = Random.Range(fallSpeedMin, fallSpeedMax);
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

        if(isDead)
        {
            clipPlayTime.TimerUpdate();
            if(clipPlayTime.IsTime())
            {
                Destroy(this.gameObject);
                clipPlayTime.Initialize();
            }
        }

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

    bool isDead = false;
    Timer clipPlayTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //隕石に触れたら即死。
        if (!collision.tag.Equals("Emit_meteroite")) return;

        audio.Play();
        colider.enabled = false;
        renderer.enabled = false;
        isDead = true;

        Destroy(collision.gameObject);
    }

    public bool IsDead()
    {
        return isDead;
    }
    
}
