﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    
    public Transform enemyPrefab1;
    public Transform enemyPrefab1Boss;
    public Transform enemyPrefab2;
    public Transform enemyPrefab2Boss;
    /*public Transform enemyPrefab3;
    public Transform enemyPrefab4;
    public Transform enemyPrefab5;
    public Transform enemyPrefab6;
    public Transform enemyPrefab7;
    public Transform enemyPrefab8;
    public Transform enemyPrefab9;*/
    //public Transform[] enemyPrefab = { enemy1, enemy2 };
    public Transform spawnPoint;

    private float timeBetweenWaves = 1f; // 20f
    private float countdown = 3f; // 40f Prepare Skill before Game Start
    
    private int waveNumber = 0;
    private int waveIndex = 2; //20

    public Text RoundCountText;
    public Text waveCountdownText;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        //else if (LivesUI.enemyCount == 0)
        //{
        //    StartCoroutine(SpawnWave());
        //    countdown = timeBetweenWaves;
        //}
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawnWave ()
    {
        waveNumber++;
        TextFadeIn.FadeIn(waveNumber);
        RoundCountText.text = (waveNumber).ToString();

        if (waveNumber == 10)
        {
            Instantiate(enemyPrefab1Boss, spawnPoint.position, spawnPoint.rotation);
        }
        if (waveNumber == 20)
        {
            Instantiate(enemyPrefab2Boss, spawnPoint.position, spawnPoint.rotation);
        }
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        if (0 < waveNumber && waveNumber <= 10)
        {
            Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation);

        }

        if (10 < waveNumber && waveNumber <= 20)
        {
            Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
        }
        
        /*switch (waveNumber)
        {
            case 1:
                Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation);
                break;
            case 2:
                Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
                break;
            default:
                break;
        }*/
        
    }

}