using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCarParts : MonoBehaviour
{

    public int b_roof1, b_roof2, b_bump1, b_bump2, b_wheels1, b_wheels2, c_red, c_blue;
    public GameObject roof1, roof2, wheels1, wheels2, bump1, bump2;
    public Renderer car;

    // Start is called before the first frame update
    void Start()
    {
        LoadParts();
        ActivateCarParts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadParts()
    {
        //Load player prefs data saved

        b_roof1 = PlayerPrefs.GetInt("b_roof1"); //1 for true, 0 for false
        b_roof2 = PlayerPrefs.GetInt("b_roof2");
        b_bump1 = PlayerPrefs.GetInt("b_bump1");
        b_bump2 = PlayerPrefs.GetInt("b_bump2");
        b_wheels1 = PlayerPrefs.GetInt("b_wheels1");
        b_wheels2 = PlayerPrefs.GetInt("b_wheels2");
        c_red = PlayerPrefs.GetInt("c_red");
        c_blue = PlayerPrefs.GetInt("c_blue");
    }

    void ActivateCarParts()
    {
        //Get all info and activate car parts
        
        if(b_roof1==1)
        {
            roof1.SetActive(true);
            roof2.SetActive(false);
        }
        if(b_roof2==1)
        {
            roof1.SetActive(false);
            roof2.SetActive(true);
        }
        if(b_bump1==1)
        {
            bump1.SetActive(true);
            bump2.SetActive(false);
        }
        if(b_bump2==1)
        {
            bump2.SetActive(true);
            bump1.SetActive(false);
        }
        if(b_wheels1==1)
        {
            wheels1.SetActive(true);
            wheels2.SetActive(false);
        }
        if(b_wheels2==1)
        {
            wheels1.SetActive(false);
            wheels2.SetActive(true);
        }
        if(c_red==1)
        {
            car.material.SetColor("_Color", Color.red);
        }
        if(c_blue==1)
        {
            car.material.SetColor("_Color", Color.blue);
        }
    }
}
