using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    private float speed = 3f;
    private float force = 13f;
    public LayerMask groundLayer;
    private bool canJump;
    private Animator animator;
    public UIGameManager uigamemanager;
    public Image HpImage;
    public GameObject HPbar;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        float directionx = 0;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            directionx = -1;
            transform.localScale = new Vector3(-1, 1, 1);
            HPbar.transform.localScale = new Vector3(-1,1,1);
            animator.SetBool("CheckRun",true);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            HPbar.transform.localScale = new Vector3(1, 1, 1);
            directionx = 1;
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("CheckRun",true);
        }
        else
        {
            directionx = 0;
            animator.SetBool("CheckRun",false);
        }
        rigidbody2d.velocity = new Vector2(directionx*speed, rigidbody2d.velocity.y);
        if (canJump && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rigidbody2d.AddForce(Vector2.up*force,ForceMode2D.Impulse);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.jump);
        }

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down,1.1f,groundLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.black);
        if (raycastHit2D.collider != null)
        {
            canJump = true;
            animator.SetBool("CheckJump", false);
        }
        else
        {
            canJump = false;
            animator.SetBool("CheckJump",true);
        }

        animator.SetFloat("yVelocity", rigidbody2d.velocity.y);
        if (PlayerData.checkKill)
        {
            PlayerData.score += 10;
            PlayerData.HP += 10;
            HpImage.fillAmount = PlayerData.HP * 1f / 50;
            uigamemanager.scoretext.text = "Score: " + PlayerData.score;
            PlayerData.checkKill = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            PlayerData.HP -= 10;
            HpImage.fillAmount = PlayerData.HP * 1f / 50;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.block);
            if (PlayerData.HP <= 0)
            {
                uigamemanager.lossGamePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (other.gameObject.tag == "Apple")
        {
            PlayerData.score += 5;
            Destroy(other.gameObject);
            uigamemanager.scoretext.text = "Score: " + PlayerData.score;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.apple);
        }

        if (other.gameObject.tag == "EndPoint")
        {
            uigamemanager.winGamePanel.SetActive(true);
            Time.timeScale = 0;
            uigamemanager.scoreFinalText.text = "Score: " + PlayerData.score;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            PlayerData.HP -= 10;
            HpImage.fillAmount = PlayerData.HP * 1f / 50;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.block);
            if (PlayerData.HP <= 0)
            {
                uigamemanager.lossGamePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void LateUpdate()
    {
        Camera.main.transform.position =
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
    }
}
