using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int cashAmount;
    public Text cashAmountTxt;
    public bool b_roof1, b_roof2, b_wheels1, b_wheels2, b_bump1, b_bump2, c_red, c_blue;
    public GameObject roof1, roof2, wheels1, wheels2, bump1, bump2;
    public Renderer car;
    public AudioSource uiSound;
    
    // Start is called before the first frame update
    void Start()
    {
        //load player cash every time you access the shop
        PlayerPrefs.SetInt("cash", cashAmount);
        cashAmountTxt.text = cashAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BuyRoof1()
    {
        if(cashAmount>0 && b_roof1==false )
        {
            b_roof1 = true;
            b_roof2 = false;
            cashAmount = cashAmount - 100;
            cashAmountTxt.text = cashAmount.ToString();
            roof1.SetActive(true);
            roof2.SetActive(false);
            PlayerPrefs.SetInt("b_roof1", 1); //1 for true, 0 for false
            PlayerPrefs.SetInt("b_roof2", 0);

            SaveCash();
            PlayUISound();
        }
    }
    public void BuyRoof2()
    {
        if(cashAmount>0 && b_roof2==false)
        {
            b_roof2 = true;
            b_roof1 = false;
            cashAmount = cashAmount - 100;
            cashAmountTxt.text = cashAmount.ToString();
            roof1.SetActive(false);
            roof2.SetActive(true);
            PlayerPrefs.SetInt("b_roof2", 1); //1 for true, 0 for false
            PlayerPrefs.SetInt("b_roof1", 0);

            SaveCash();
            PlayUISound();
        }
    }

    public void BuyWheels1()
    {
        if(cashAmount>0 && b_wheels1==false)
        {
            b_wheels1 = true;
            b_wheels2 = false;
            cashAmount = cashAmount - 200;
            cashAmountTxt.text = cashAmount.ToString();
            wheels1.SetActive(true);
            wheels2.SetActive(false);
            PlayerPrefs.SetInt("b_wheels1", 1); //1 for true, 0 for false
            PlayerPrefs.SetInt("b_wheels2", 0);

            SaveCash();
            PlayUISound();
        }
    }

    public void BuyWheels2()
    {
        if(cashAmount>0 && b_wheels2==false)
        {
            b_wheels2 = true;
            b_wheels1 = false;
            cashAmount = cashAmount - 200;
            cashAmountTxt.text = cashAmount.ToString();
            wheels2.SetActive(true);
            wheels1.SetActive(false);
            PlayerPrefs.SetInt("b_wheels2", 1); //1 for true, 0 for false
            PlayerPrefs.SetInt("b_wheels1", 0);

            SaveCash();
            PlayUISound();
        }
    }

    public void BuyBumper1()
    {
        if(cashAmount>0 && b_bump1==false)
        {
            b_bump1 = true;
            b_bump2 = false;
            cashAmount = cashAmount - 200;
            cashAmountTxt.text = cashAmount.ToString();
            bump1.SetActive(true);
            bump2.SetActive(false);
            PlayerPrefs.SetInt("b_bump1", 1); //1 for true, 0 for false
            PlayerPrefs.SetInt("b_bump2", 0);

            SaveCash();
            PlayUISound();
        }
    }
    public void BuyBumper2()
    {
        if(cashAmount>0 && b_bump2==false)
        {
            b_bump2 = true;
            b_bump1 = false;
            cashAmount = cashAmount - 200;
            cashAmountTxt.text = cashAmount.ToString();
            bump2.SetActive(true);
            bump1.SetActive(false);
            PlayerPrefs.SetInt("b_bump2", 1); //1 for true, 0 for false
            PlayerPrefs.SetInt("b_bump1", 0);

            SaveCash();
            PlayUISound();
        }
    }

    public void ColorRed()
    {
        if(cashAmount>0 && c_red == false)
        {
            car.material.SetColor("_Color", Color.red);
            cashAmount = cashAmount - 200;
            cashAmountTxt.text = cashAmount.ToString();
            c_red = true;
            c_blue = false;
            PlayerPrefs.SetInt("c_red", 1); //1 for true, 0 for false
            PlayerPrefs.SetInt("c_blue", 0);

            SaveCash();
            PlayUISound();
        }
    }
    public void ColorBlue()
    {
        if(cashAmount>0 && c_blue == false)
        {
            car.material.SetColor("_Color", Color.blue);
            cashAmount = cashAmount - 200;
            cashAmountTxt.text = cashAmount.ToString();
            c_blue = true;
            c_red = false;
            PlayerPrefs.SetInt("c_blue", 1); //1 for true, 0 for false
            PlayerPrefs.SetInt("c_red", 0);

            SaveCash();
            PlayUISound();
        }
    }

    public void DefaultCarSettings()
    {
        //Reset Car settings
        bump1.SetActive(false);
        bump2.SetActive(false);
        roof1.SetActive(false);
        roof2.SetActive(false);
        wheels1.SetActive(true);
        wheels2.SetActive(false);
        car.material.SetColor("_Color", Color.white);
        //Reset variables
        b_bump1=false;
        b_bump2=false;
        b_wheels1=true;
        b_wheels2=false;
        b_roof1=false;
        b_roof2=false;
        c_red=true;
        c_blue=false;
        //Reset Player Prefs
        PlayerPrefs.SetInt("b_bump1", 0);
        PlayerPrefs.SetInt("b_bump2", 0);
        PlayerPrefs.SetInt("b_wheels1", 0);
        PlayerPrefs.SetInt("b_wheels2", 0);
        PlayerPrefs.SetInt("b_roof1", 0);
        PlayerPrefs.SetInt("b_roof2", 0);
        PlayerPrefs.SetInt("c_red", 0);
        PlayerPrefs.SetInt("c_blue", 0);

        PlayUISound();
    }

    void SaveCash()
    {
        PlayerPrefs.SetInt("cash", cashAmount);
    }
    void PlayUISound()
    {
        uiSound.Play();
    }
}
