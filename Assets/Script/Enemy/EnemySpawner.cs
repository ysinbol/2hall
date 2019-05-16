using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    Vector3 spawnPoint;
    Camera mainCamera;

    [SerializeField]
    float interval = 0.2f;
    Timer spawnInterval;
    Timer waitTimer;

    // Use this for initialization
    void Start () {
        spawnInterval = new Timer(interval);
        mainCamera = Camera.main;
        waitTimer = new Timer(3);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void SetSpawnPoint()
    {

        float spawnPointX = Random.Range(-10.01f, 10.01f);
        
        float spawnPointY = 10;

        spawnPoint = new Vector3(spawnPointX, spawnPointY,0);
    }
    
    public GameObject enemy;

    /// <summary>
    /// 生成
    /// </summary>
    void Spawn()
    {
        SetSpawnPoint();
        
        spawnInterval.TimerUpdate();
        if(spawnInterval.IsTime())
        {
            Instantiate(enemy,spawnPoint,Quaternion.identity);
            spawnInterval.Initialize();
        }     
    }

    // Update is called once per frame
    void Update () {

        waitTimer.TimerUpdate();
        if (!waitTimer.IsTime()) return;

        Spawn();
	}
}
