using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneChangeTitle();
        }

    }

    void SceneChangeTitle()
    {
        FadeManager.Instance.LoadScene("Title");
    }

}
