using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;

    private PlayButton playButtonScr;
    private Animator playerAnim;
    private SpriteRenderer playerSR;
    private AudioSource audio;
    void Start()
    {
        playButtonScr = FindObjectOfType<PlayButton>();
        playerAnim = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        MovementByTouch();

        if (playerAnim.GetBool("isMoving") == true) audio.enabled = true;
        else audio.enabled = false;
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 position = new Vector3(horizontal, 0, 0);

        MovePlayer(position);

        if (Input.GetKey(KeyCode.A)) MovementAnimation(false);
        else if (Input.GetKey(KeyCode.D)) MovementAnimation(true);
        else
        {
            playerAnim.SetBool("isMoving", false);
            playerSR.flipX = false;
        }
    }

    private void MovePlayer(Vector3 pos)
    {
        transform.Translate(pos * Time.deltaTime * speed);
    }

    private void MovementByTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (playButtonScr.isPressed == false)
            {
                if (touchPos.x < 0f)
                {
                    MovePlayer(-Vector3.right);
                    MovementAnimation(false);
                }
                else if (touchPos.x > 0f)
                {
                    MovePlayer(Vector3.right);
                    MovementAnimation(true);
                }
                if (Input.touchCount == 0)
                {
                    playerAnim.SetBool("isMoving", false);
                    playerSR.flipX = false;
                }
            }
        }
    }

    private void MovementAnimation(bool flip)
    {
        playerAnim.SetBool("isMoving", true);
        FlipSprite(flip);
    }

    public void EmptySpeed(float accel)
    {
        speed = accel;
    }

    public void FlipSprite(bool flip)
    {
        playerSR.flipX = flip;
    }

    public void TestButton()
    {
        Debug.Log("Anjay");
    }
}
