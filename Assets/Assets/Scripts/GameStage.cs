using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement playerMovementScr;
    private Animator playerAnim;

    [SerializeField] private bool playingStage;
    [SerializeField] private GameObject playButton;

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
            IsPlayingStage();
        }

        ChangeGameStage();
    }

    public void IsPlayingStage()
    {
        playingStage = true;
    }

    private void ChangeGameStage()
    {
        if (playingStage == true)
        {
            playerAnim.SetBool("isMoving", false);
            playerMovementScr.enabled = false;
            playerMovementScr.FlipSprite(false);
            playButton.SetActive(false);
        }
        else
        {
            playerMovementScr.enabled = true;
            playButton.SetActive(true);
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
