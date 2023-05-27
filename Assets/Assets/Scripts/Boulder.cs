using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    GameStage gameStageScr;
    BoulderInitiation boulderInitiationScr;
    PowerUps powerUpsScr;
    Coins coinScr;
    Scores_UI scoreScr;
    AudioManager audioManagerScr;

    [SerializeField] float boxSize;

    private void Start()
    {
        gameStageScr = FindObjectOfType<GameStage>();
        boulderInitiationScr = FindObjectOfType<BoulderInitiation>();
        powerUpsScr = FindObjectOfType<PowerUps>();
        coinScr = FindObjectOfType<Coins>();
        scoreScr = FindObjectOfType<Scores_UI>();
        audioManagerScr = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        CheckNearObject();
    }

    private void ChangeStage()
    {
        Destroy(this.gameObject);
        gameStageScr.SetStage(false);
        coinScr.SetHasSpawned(false);
        powerUpsScr.SetHasSpawned(false);
        boulderInitiationScr.SetHasSpawned(false, 1);
        scoreScr.AddScores();
    }

    public void CheckNearObject()
    {
        Collider2D boxCol = Physics2D.OverlapBox(this.transform.GetChild(this.transform.childCount - 1).position, new Vector2(boxSize + 2f, boxSize), 0f);
        if (boxCol != null)
        {
            audioManagerScr.BoulderFallSound(2);
            if (boxCol.tag == "Player" || boxCol.tag == "Ground")
            {
                StartCoroutine(DisableShield());
                Invoke("ChangeStage", 4f);
                ChildColliders();

            }

            if (boxCol.tag == "Player") boulderInitiationScr.HitPlayer();
            else if (boxCol.tag == "Shield")
            {
                ChildColliders();
                Debug.Log("Anjay");
                StartCoroutine(DisableShield());
                Invoke("ChangeStage", 4f);
                Destroy(this.transform.GetComponent<Rigidbody2D>());
            }
        }
    }

    private void ChildColliders()
    {
        for (int i = 0; i < this.transform.childCount - 1; i++)
        {
            this.transform.GetChild(i).GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

    IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(3.9f);
        powerUpsScr.DeactivateShield();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.GetChild(this.transform.childCount - 1).position, new Vector2(boxSize + 2f, boxSize));
    }

}
