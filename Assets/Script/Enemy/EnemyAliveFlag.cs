using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAliveFlag : MonoBehaviour {

    bool isDead = false;

    /// <summary>
    /// 死んだ
    /// </summary>
    public void Dead()
    {
        isDead = true;
    }

    /// <summary>
    /// 死んでるか
    /// </summary>
    /// <returns></returns>
    public bool IsDead()
    {
        return isDead;
    }

}
