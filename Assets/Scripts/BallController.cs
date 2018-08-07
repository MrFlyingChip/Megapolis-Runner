using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public bool collided;
    private Rigidbody2D _rigidbody2D;
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public bool left;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Sprite ballSprite = Resources.Load<Sprite>("BallSprites/" + PlayerPrefs.GetInt("Ball"));
    }

    public void BallJump()
    {
        if (collided)
        {
            _rigidbody2D.AddForce(new Vector2(50, 450f));
        }  
    }

    private void FixedUpdate()
    {
        float newAngle = _rigidbody2D.rotation - GameController.gameSpeed;
        _rigidbody2D.MoveRotation(newAngle);
        if(GetComponent<RectTransform>().anchoredPosition.x < -200 || GetComponent<RectTransform>().anchoredPosition.y < -200)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FlatController>())
        {
            collision.gameObject.GetComponent<FlatController>().building.TurnOnLightsInFlats();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Edge")
        {
            if (left)
            {
                collided = false;
            }
            else
            {
                collided = true;
            }    
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
        left = false;
    }

    

    private void Death()
    {
        GetComponent<AudioSource>().clip = deathClip;
        GetComponent<AudioSource>().Play();
        GameObject.FindObjectOfType<GameController>().PauseGame();
    }
}
