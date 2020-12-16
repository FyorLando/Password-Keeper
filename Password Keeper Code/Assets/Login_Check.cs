using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Login_Check : MonoBehaviour
{
    public static bool isLogined;
    public Text Login_Check_Text;
    public Text Are_U_Logined;
    public InputField Password_enter;
    string enter_password;
    void Start()
    {
        isLogined = false;

        using (StreamReader sr = new StreamReader("PKF/entpass.txt"))
        {
            enter_password = sr.ReadLine();
        }
    }

    void Update()
    {
        if (Login_Check_Text.text == "0")
        {
            isLogined = false;
            Are_U_Logined.text = "You are not logged in";
            Are_U_Logined.color = Color.red;
        }
        else
        {
            isLogined = true;
            Are_U_Logined.text = "You are logged in";
            Are_U_Logined.color = Color.green;
        }
    }

    public void Autorisation()
    {
        if (Login_Check_Text.text == "0" && Password_enter.text == enter_password)
        {
            Login_Check_Text.text = "1";
            Password_enter.text = "";


        }
        else
        {
            Login_Check_Text.text = "0";
        }
    }
}
