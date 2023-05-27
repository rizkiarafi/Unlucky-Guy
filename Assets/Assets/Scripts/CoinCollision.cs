using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    GameStage gameStageScr;
    Transform player;

    protected Coins coinsScr;
    protected AudioManager audio;
    protected PowerUps powerUpsScr;

    [SerializeField] protected string sentence;
    void Start()
    {
        gameStageScr = FindObjectOfType<GameStage>();
        player = FindObjectOfType<PlayerMovement>().transform;
        coinsScr = FindObjectOfType<Coins>();
        audio = FindObjectOfType<AudioManager>();
        powerUpsScr = FindObjectOfType<PowerUps>();
    }

    private void Update()
    {
        CollectCoin();
        if (gameStageScr.GetStage() == true)
        {
            Destroy(this.gameObject);
        }

    }

    protected virtual void CollectCoin()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(this.transform.position, player.position) <= 0.5f)
        {
            Debug.Log(sentence);
            Destroy(this.gameObject);
            gameStageScr.SetStage(true);
            AddEffect();
        }
    }

    protected virtual void AddEffect()
    {
        audio.AddCoinSound(0);
        coinsScr.AddCoin(1);
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    Debug.Log("Entered");
    //    if (Input.GetKeyDown(KeyCode.E) && other.tag == "Player")
    //    {
    //        
    //    }
    //}

}
