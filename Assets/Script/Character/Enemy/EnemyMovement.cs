using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //ナビ検索外になったら検索しない
        if (nav.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            return;
        }
        //目的地をプレイヤーの位置に
        nav.SetDestination(player.position);

    }
}
