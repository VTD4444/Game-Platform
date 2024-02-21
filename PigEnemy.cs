using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Vector2 = System.Numerics.Vector2;

public class PigEnemy : MonoBehaviour
{
    public LayerMask playerLayer;
    public float speed = 5;

    private void Update()
    {
        gameObject.transform.Translate(speed*Time.deltaTime*Vector3.left);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ChangeDirection")
        {
            speed *= -1;
            transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, UnityEngine.Vector2.up,1.25f,playerLayer);
            if (raycastHit2D.collider != null)
            {
                Destroy(gameObject);
                PlayerData.checkKill = true;
                AudioManager.Instance.PlaySFX(AudioManager.Instance.hit);
            }
        }
    }
}