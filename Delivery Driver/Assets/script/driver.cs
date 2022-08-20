using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driver : MonoBehaviour
{
    [SerializeField] float Ddelay;
    [SerializeField] float movespeed;
    [SerializeField] float steerspeed;
    [SerializeField] float slowspeed;
    [SerializeField] float boostspeed;
    bool package;

    
    void Update()
    {
        float steer = Input.GetAxis("Horizontal") * steerspeed * Time.deltaTime;
        float move = Input.GetAxis("Vertical") * movespeed * Time.deltaTime;
        transform.Rotate (0,0, -steer);
        transform.Translate(0, move, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "package" && !package)
        {
            Debug.Log("teslimat alýndý");
            package = true;
            Destroy(collision.gameObject, Ddelay);
        }

        if (collision.tag == "customer" && package)
        {
            Debug.Log("teslim etti");
            package=false;
            Destroy(collision.gameObject, Ddelay);
        }

        if (collision.tag == "boost")
        {
            movespeed = boostspeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movespeed = slowspeed;
    }
}
