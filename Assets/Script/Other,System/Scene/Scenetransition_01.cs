using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenetransition_01 : MonoBehaviour {
    public string scene;
    //public string shift;

    // Use this for initialization
    void Start()
    {

    }

    public void toGameScene()
    {
        SceneManager.LoadScene(scene);
    }

    //public void toShiftScene()
    //{
    //    SceneManager.LoadScene(shift);
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button7) ||
            Input.GetKey(KeyCode.Space))
        {
            toGameScene();
        }

        //if (Input.GetKey(KeyCode.Joystick1Button6) ||
        //    Input.GetKey(KeyCode.LeftShift) ||
        //    Input.GetKey(KeyCode.RightShift))
        //{
        //    toShiftScene();
        //}
    }
}
