using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    public GameObject enemy;
    private Enemy enemyScript;

    [SerializeField]
    private AudioClip enemyDown;
    private AudioSource audio;

    // Use this for initialization
    void Start () {
        Debug.Log(enemy);
        enemyScript = enemy.GetComponent<Enemy>();
        audio = GetComponent<AudioSource>();
        audio.clip = enemyDown;
        audioPlayTime =  new Timer(audio.clip.length);
	}

    bool isPlay = false;
    Timer audioPlayTime;
	// Update is called once per frame
	void Update () {
		if(enemyScript.IsDead())
        {
            isPlay = true;
            Debug.Log("Dead");
        }

        if(isPlay)
        {
            audio.PlayOneShot(enemyDown);
            audioPlayTime.TimerUpdate();
        }

        if(audioPlayTime.IsTime())
        {
            isPlay = false;
            audioPlayTime.Initialize();
        }
	}
}
