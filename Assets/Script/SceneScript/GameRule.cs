using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRule : MonoBehaviour{

    [SerializeField]
    float gameOverTime;
    Timer gameTimer;
    Text timerText;

    private GameObject player;
    private PlayerHealth playerHealth;
    private Timer waitTimer;

	// Use this for initialization
	void Start () {
        gameTimer = new Timer(gameOverTime);
        timerText = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        waitTimer = new Timer(3);

    }

    // Update is called once per frame
    void Update () {
        waitTimer.TimerUpdate();
        if (!waitTimer.IsTime()) return;


        gameTimer.TimerUpdate();

        //時間まで耐えきったら
        if(gameTimer.IsTime())
        {
            SceneChangeClear();
            return;
        }

        //体力が0になったら
        if(playerHealth.IsDead())
        {
            SceneChangeOver();
            return;
        }

        TextUpdate();
	}


    void TextUpdate()
    {
        timerText.text = "援軍到着まで:" +gameTimer.CurrentTime.ToString()+"秒";
    }

    void SceneChangeClear()
    {
        FadeManager.Instance.LoadScene("Result");
        DeleteMyself();
    }

    void SceneChangeOver()
    {
        FadeManager.Instance.LoadScene("GameOver");
        DeleteMyself();
    }

    void DeleteMyself()
    {
        Destroy(this.gameObject);
    }
}
