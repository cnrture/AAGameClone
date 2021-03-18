using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class yonetici : MonoBehaviour
{
    public TextMeshProUGUI kalanOkText;
    public TextMeshProUGUI oyunBittiText;
    public GameObject oyunBittiEkran;
    public GameObject tekrarOynaButton;
    public GameObject sonrakiSeviyeButton;
    public GameObject dusmanokset1;
    public GameObject dusmanokset2;
    public GameObject dusmanokset3;
    public GameObject ok;
    int ilkkalanOk = 5;
    int yedekkalanOk;
    int guncelkalanOk;

    void Start()
    { 
        Time.timeScale = 1.0f;

        OkSpawn();
        DusmanOkSetSpawn();

        guncelkalanOk = PlayerPrefs.GetInt("levelup") + ilkkalanOk;
        yedekkalanOk = guncelkalanOk;
        kalanOkText.text = guncelkalanOk.ToString();
    }

    void Update()
    {
        OyunWin();
    }

    public void DusmanOkSetSpawn()
    {
        GameObject[] dusmansetleri = new GameObject[] { dusmanokset1, dusmanokset2, dusmanokset3 };
        int dusmansetleriindex = Random.Range(0, 3);
        GameObject yeniset =  Instantiate(dusmansetleri[dusmansetleriindex]);
        yeniset.transform.SetParent(GameObject.Find("anaTop").GetComponent<Transform>());
    }

    public void OkSpawn()
    {
        Instantiate(ok, new Vector3(529.1164f, 202f, -173f), Quaternion.Euler(new Vector3(180, 0, 0)));
    }

    public void OkSayisiAzalt()
    {
        guncelkalanOk--;
        kalanOkText.SetText(guncelkalanOk.ToString());
    }

    public void OyunWin()
    {
        if (guncelkalanOk == 0)
        {
            Time.timeScale = 0.0f;
            PlayerPrefs.SetInt("levelup", yedekkalanOk);
            oyunBittiEkran.SetActive(true);
            oyunBittiText.SetText("TEBRİKLER");
            sonrakiSeviyeButton.SetActive(true);
        }
    }

    public void OyunLose()
    {
        Time.timeScale = 0.0f;
        PlayerPrefs.SetInt("levelup", yedekkalanOk-5);
        oyunBittiEkran.SetActive(true);
        oyunBittiText.SetText("KAYBETTİN");
        tekrarOynaButton.SetActive(true);
    }

    public void SonrakiSeviyeButton()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void TekrarOynaButton()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
