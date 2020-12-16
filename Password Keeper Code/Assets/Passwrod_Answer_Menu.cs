﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Passwrod_Answer_Menu : MonoBehaviour
{
    public GameObject Pass_Answer;
    public GameObject Main_Screen;

    public Text Service;
    public Text Login;
    public Text Password;

    public void Back()
    {
        Pass_Answer.SetActive(false);
        Main_Screen.SetActive(true);
    }

    public void Start_Password()
    {
        if (Login_Check.isLogined)
        {
            Pass_Answer.SetActive(true);
            Main_Screen.SetActive(false);

            Service.text = All_Services.answer[0];
            Login.text = All_Services.answer[1];
            Password.text = All_Services.answer[2];
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Service.text = All_Services.answer[0];
        Login.text = All_Services.answer[1];
        Password.text = All_Services.answer[2];
    }

    public void Copy(int position)
    {
        if (position == 0)
        {
            GUIUtility.systemCopyBuffer = Service.text;
        }
        else if (position == 1)
        {
            GUIUtility.systemCopyBuffer = Login.text;
        }
        else
        {
            GUIUtility.systemCopyBuffer = Password.text;
        }
    }
}
