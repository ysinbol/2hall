using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EScene
{
    Title,
    Main,
    Result,
    GameOver
};

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    private ControllerManager controllerManager;

    [SerializeField]
    private EController e_debugController;

    [SerializeField]
    private bool cursolVisible;                     //カーソルの表示するか否か

	// Use this for initialization
	void Awake () {
        CreateInstance();

        Cursor.visible = cursolVisible;
    }

    /// <summary>
    /// シングルトンにする
    /// </summary>
    void CreateInstance()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Initialize();

    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        controllerManager = new ControllerManager();
    }

    /// <summary>
    /// コントローラーを得る
    /// </summary>
    /// <returns></returns>
    public ICharacterController GetController()
    {
        if (e_debugController == EController.KEYBOARD)
            return controllerManager.KeyBoard;
       
        return controllerManager.Pad;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SceneChange(EScene eScene)
    {
        SceneManager.LoadScene(eScene.ToString());
    }
}
