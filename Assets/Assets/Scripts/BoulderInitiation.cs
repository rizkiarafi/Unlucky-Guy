using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderInitiation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject boulder;
    [SerializeField] GameStage gameStageScr;
    [SerializeField] GameObject gameOverText;

    [SerializeField] float boulderX;
    [SerializeField] float boulderY;

    int count = 1;
    GameObject tempObject;
    [SerializeField] bool hasSpawned = false;

    void Start()
    {
        gameStageScr = FindObjectOfType<GameStage>();
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateBoulder();
    }

    private void InstantiateBoulder()
    {
        float randomBoulderX = Random.Range(-boulderX, boulderX);

        int maxCount = 1;

        if (gameStageScr.GetStage() == true && hasSpawned == false)
        {
            Instantiate(boulder, new Vector3(randomBoulderX, boulderY, 0), Quaternion.identity);
            if (count == maxCount)
            {
                hasSpawned = true;
            }
            count++;
        }
    }

    public void ShatterBoulder()
    {
        for (int i = 0; i < tempObject.transform.childCount; i++)
        {
            tempObject.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void SetHasSpawned(bool spawn, int one)
    {
        count = one;
        hasSpawned = spawn;
    }

    public void HitPlayer()
    {
        gameOverText.SetActive(true);
    }
}
