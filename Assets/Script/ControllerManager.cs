using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager  {

    private KeyBoardController keyboard_Controller;     //キーボードコントローラー
    private GamePadController gamePad_Controller;       //ゲームパッドコントローラー

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ControllerManager()
    {
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        keyboard_Controller = new KeyBoardController();
        gamePad_Controller = new GamePadController();
    }

    /// <summary>
    /// キーボードコントローラーを返す
    /// </summary>
    /// <returns></returns>
    public ICharacterController KeyBoard
    {
        get {return keyboard_Controller;}
    }

    /// <summary>
    /// ゲームパッドコントローラーを返す
    /// </summary>
    /// <returns></returns>
    public ICharacterController Pad
    {
        get { return gamePad_Controller; }

    }

}
