using System.Collections;
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
        Service.text = "";
        Login.text = "";
        Password.text = "";
        Pass_Answer.SetActive(false);
        Main_Screen.SetActive(true);
    }

    public void Start_Password()
    {
        if (Login_Check.isLogined && All_Services.SearchedService.Name != null)
        {
            Pass_Answer.SetActive(true);
            Main_Screen.SetActive(false);

            Service.text = All_Services.SearchedService.Name;
            Login.text = All_Services.SearchedService.Login;
            Password.text = All_Services.SearchedService.Password;
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Copy(int position)
    {
        switch (position)
        {
            case 0:
                GUIUtility.systemCopyBuffer = Service.text;
                break;
            case 1:
                GUIUtility.systemCopyBuffer = Login.text;
                break;
            case 2:
                GUIUtility.systemCopyBuffer = Password.text;
                break;
    }
        
    }
}
