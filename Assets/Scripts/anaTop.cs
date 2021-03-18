using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anaTop : MonoBehaviour
{
    float donushizi;

    private void Start()
    {
        InvokeRepeating("DonusHizi", 0.0f, Random.Range(2f, 5f));
    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, donushizi * Time.deltaTime, 0));
    }

    void DonusHizi()
    {
        int[] donusHizListesi = new int[] { -90, -70, -50, -30, 30, 50, 70, 90 };
        int donusRandom = Random.Range(0, 8);
        donushizi = donusHizListesi[donusRandom];        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ok")
        {
            collision.gameObject.tag = "carpmisok";

            collision.transform.SetParent(gameObject.transform);

            GameObject.Find("Plane").GetComponent<yonetici>().OkSpawn();

            GameObject.Find("Plane").GetComponent<yonetici>().OkSayisiAzalt();
        }
    }
}
