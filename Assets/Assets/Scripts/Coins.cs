using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject coin;

    GameStage gameStageScr;

    [SerializeField] float xPosition;
    [SerializeField] float spawnCoin;
    [SerializeField] TMP_Text coinsText;

    [SerializeField] bool hasSpawned = false;

    int coinsCount = 0;
    void Start()
    {
        gameStageScr = FindObjectOfType<GameStage>();
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(-xPosition, xPosition);

        InstantiateCoin(randomX);
    }

    private void InstantiateCoin(float randomX)
    {
        if (gameStageScr.GetStage() == false && hasSpawned == false)
        {
            spawnCoin = Random.Range(0, 3);
            if (spawnCoin == 1) Instantiate(coin, new Vector3(randomX, -2, 0), Quaternion.identity);

            hasSpawned = true;

        }
    }

    public void AddCoin(int multiply)
    {
        if (multiply == 2) coinsCount = coinsCount * multiply;
        else coinsCount++;

        coinsText.text = coinsCount.ToString();
    }

    public void SetHasSpawned(bool spawn)
    {
        hasSpawned = spawn;
    }
}
