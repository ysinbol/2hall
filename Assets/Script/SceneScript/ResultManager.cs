using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour{

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
