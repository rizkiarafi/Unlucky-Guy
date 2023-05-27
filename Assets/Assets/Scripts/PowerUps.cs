using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUps;

     GameStage gameStageScr;

    [SerializeField] GameObject shield;

    [SerializeField] float xPosition;
    [SerializeField] float spawnCoin;

    [SerializeField] bool hasSpawned = false;
    void Start()
    {
        gameStageScr = FindObjectOfType<GameStage>();
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(-xPosition, xPosition);

        InstantiatePowerUps(randomX);
    }

    private void InstantiatePowerUps(float randomX)
    {
        if (gameStageScr.GetStage() == false && hasSpawned == false)
        {
            spawnCoin = Random.Range(0, 100);
            if (spawnCoin < 30) Instantiate(powerUps[Random.Range(0, powerUps.Count)], new Vector3(randomX, -2, 0), Quaternion.identity);

            hasSpawned = true;

        }
    }

    public void ActivateShield()
    {
        shield.active = true;
    }

    public void DeactivateShield()
    {
        shield.active = false;
    }

    public void SetHasSpawned(bool spawn)
    {
        hasSpawned = spawn;
    }
}
