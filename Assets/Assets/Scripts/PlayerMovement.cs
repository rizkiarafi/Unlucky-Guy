using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed, tempSpeed;
    private Animator playerAnim;
    private SpriteRenderer playerSR;
    private AudioSource audio;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

        tempSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (playerAnim.GetBool("isMoving") == true) audio.enabled = true;
        else audio.enabled = false;
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 position = new Vector3(horizontal, 0, 0);

        transform.Translate(position * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.A))
        {
            MovementAnimation(false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MovementAnimation(true);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isMoving", false);
            playerSR.flipX = false;
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
