using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterController {

    Vector2 Black_HorizontalMove();
    Vector2 Black_VerticalMove();
    Vector2 White_HorizontalMove();
    Vector2 White_VerticalMove();
    float MosuePositionX();

}
