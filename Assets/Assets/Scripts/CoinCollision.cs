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
        CollectedByTouch();
        if (gameStageScr.GetStage() == true)
        {
            Destroy(this.gameObject);
        }

    }

    private void CollectCoin()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(this.transform.position, player.position) <= 0.5f)
        {
            GetCollected();
        }
    }

    private void GetCollected()
    {
        Debug.Log(sentence);
        Destroy(this.gameObject);
        gameStageScr.SetStage(true);
        AddEffect();
    }

    private void CollectedByTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector3.forward);
            
            if (hit.collider != null)
            {
                if (hit.transform.tag == "Collectible")
                {
                    Debug.Log(hit.collider.name);
                    GetCollected();
                }
            }
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
