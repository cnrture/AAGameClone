using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniktop : MonoBehaviour
{
    void Update()
    {
        if (gameObject.tag == "ok")
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -2500000 * Time.deltaTime);
            }
        }
        else if (gameObject.tag == "carpmisok")
        {

        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "carpmisok")
        {
            Time.timeScale = 0.0f;
            GameObject.Find("Plane").GetComponent<yonetici>().OyunLose();
        }
    }
}
