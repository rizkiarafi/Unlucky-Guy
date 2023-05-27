using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement playerMovementScr;
    private Animator playerAnim;
    [SerializeField] private bool playingStage;

    void Start()
    {
        playerMovementScr = FindObjectOfType<PlayerMovement>();
        playerAnim = playerMovementScr.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playingStage = true;
        }

        ChangeGameStage();
    }

    private void ChangeGameStage()
    {
        if (playingStage == true)
        {
            playerAnim.SetBool("isMoving", false);
            playerMovementScr.enabled = false;
            playerMovementScr.FlipSprite(false);
        }
        else
        {
            playerMovementScr.enabled = true;
        }
    }

    public void SetStage(bool stage)
    {
        playingStage = stage;
    } 

    public bool GetStage()
    {
        return playingStage;
    }
}
