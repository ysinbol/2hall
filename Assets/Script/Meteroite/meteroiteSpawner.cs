using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteroiteSpawner : MonoBehaviour {

    Vector3 spawnPoint;
    public GameObject[] metroites;

    [SerializeField]
    float interval = 0.2f;
    Timer spawnInterval;
    Timer waitTimer;

    // Use this for initialization
    void Start () {
        spawnInterval = new Timer(interval);
        waitTimer = new Timer(3);
	}

    /// <summary>
    /// 初期化
    /// </summary>
    private void SetSpawnPoint()
    {
        float spawnPointX = Random.Range(-10.01f, 10.01f);
        
        float spawnPointY = 11;

        spawnPoint = new Vector3(spawnPointX, spawnPointY,0);
    }
    
    private GameObject metroite;
    /// <summary>
    /// 生成する隕石の種類を決定
    /// </summary>
    private void SetSpawnMetroite()
    {
        int random = Random.Range(0, 3);
        metroite = metroites[random];
    }

    /// <summary>
    /// 生成
    /// </summary>
    void Spawn()
    {
        SetSpawnPoint();
        SetSpawnMetroite();
        
        spawnInterval.TimerUpdate();
        if(spawnInterval.IsTime())
        {
            Instantiate(metroite,spawnPoint,Quaternion.identity);
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
