using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement_balanceTheObjects : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    public float movementSpeed = 10f;
    private float walking = 0;
    public Animator animator;

    public AudioSource source;
    public AudioClip Audio;
    public AudioClip AudioFinish;
    int audioSpacer;

    void Start()
    {
        GameManager.instance.StartGame(7f, false, "Balance!");
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            walking = 1f;

            audioSpacer++;

            if (audioSpacer > 150)
            {
                source.clip = Audio;
                source.Play();
                audioSpacer = 0;
            }
        } else
        {
            walking = 0f;
        }

        animator.SetFloat("Speed", walking);
    }

    void FixedUpdate()
    {
        Rigidbody.velocity = new Vector2(walking * movementSpeed, 0);
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag.Equals("Finish") == true)
        {
            Debug.Log("player finished");
            gameObject.GetComponent<playerMovement_balanceTheObjects>().enabled = false;
            gameObject.GetComponentInChildren<objectDetector_balanceTheObjects>().enabled = false;

            source.clip = AudioFinish;
            source.Play();

            animator.SetFloat("Speed", 0f);
            GameManager.instance.SetWon(true);
        }
    }
}
 