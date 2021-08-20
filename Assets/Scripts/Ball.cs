using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 dir = new Vector3(-0.3f, -1f, 0).normalized;

        rb.velocity = dir * speed;
    }

    void Update()
    {
        if (transform.position.y < -7)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void invertXDir(Rigidbody2D rb)
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 newVelocity = new Vector3(-1 * currentVelocity.x, currentVelocity.y, 0);
        rb.velocity = newVelocity;
    }

    private void invertYDir(Rigidbody2D rb)
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 newVelocity = new Vector3(currentVelocity.x, -1 * currentVelocity.y, 0);
        rb.velocity = newVelocity;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // private void OnTriggerEnter2D(Collision2D other) {
        string otherTag = other.gameObject.tag;
        if (otherTag == "Player" || otherTag == "Ceiling")
        {
            invertYDir(rb);
        }
        else if (otherTag == "Wall")
        {
            invertXDir(rb);
        }
        else if (otherTag == "BlockLeft" || otherTag == "BlockRight")
        {
            invertXDir(rb);
            Destroy(other.transform.parent.gameObject);
        }
        else if (otherTag == "BlockTop" || otherTag == "BlockBot")
        {
            invertYDir(rb);
            Destroy(other.transform.parent.gameObject);
        }
    }
}
