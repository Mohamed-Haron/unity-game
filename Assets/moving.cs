using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    private Rigidbody2D reg;
    public float speed = 10f;
    public Animator anm;
    public bool standing;
    public float speedslow = 0.3f;
     
    void Start()
    {
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        reg = GetComponent<Rigidbody2D>();

        
        float forceY = Mathf.Abs(reg.velocity.y);

        if (forceY < 0.2f)
            standing = true;
        else
            standing = false;

        var NewX = 0f;
        var NewY = 0f;

        if (Input.GetKey("right"))
        {
           
            NewX = standing ? speed : speed * speedslow;
            transform.localScale = new Vector3(1, 1, 1);
           
        }

       else if (Input.GetKey("left"))
        {
            
                NewX = standing ? -speed : -speed * speedslow;
                transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (Input.GetKey("up"))
        {
           
            NewY = speed;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(Input.GetKey("right") || Input.GetKey("left"))
        {
            anm.SetInteger("current-anmi", 1);
        } 
        else
        {
            anm.SetInteger("current-anmi", 0);
        }

        /*
         if (Input.GetKey("up"))
        {
            anm.SetInteger("current-anmi", 2);
        }
        else
        {
            anm.SetInteger("current-anmi", 3);
        }*/

        reg.AddForce(new Vector2(NewX, NewY));
    }


    // for hiding the coin
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
        }
    }

}

