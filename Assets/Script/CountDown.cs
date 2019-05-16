using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    public Sprite[] sprites;
    private SpriteRenderer renderer;
    private Timer countDownTimer;

    // Use this for initialization
    void Start() {
        countDownTimer = new Timer(3);
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (1 == (int)countDownTimer.CurrentTime)
        {
            renderer.sprite = sprites[0];
        }
        if (2 == (int)countDownTimer.CurrentTime)
        {
            renderer.sprite = sprites[1];
        }
        if (3 == (int)countDownTimer.CurrentTime)
        {
            renderer.sprite = sprites[2];
        }

        countDownTimer.TimerUpdate();

        if (countDownTimer.IsTime())
        {
            Destroy(this.gameObject);
        }

    }
}
