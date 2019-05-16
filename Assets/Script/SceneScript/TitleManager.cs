using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {

    AudioSource audio;
    public AudioClip clip1;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = clip1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audio.Play();
            SceneChange();
        }
    }

    void SceneChange()
    {
        FadeManager.Instance.LoadScene("Main");
    }
}
