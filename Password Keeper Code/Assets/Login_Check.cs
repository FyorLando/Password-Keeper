using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Login_Check : MonoBehaviour
{
    /// <summary>
    /// Is User logined?
    /// </summary>
    public static bool isLogined;

    public Text Login_Check_Text;
    public Text Are_U_Logined;
    public InputField Password_enter;

    private string enter_password; // Password to other passwords
    void Start()
    {
        isLogined = false;
        Login_Check_Text.text = "0";

        using (StreamReader sr = new StreamReader("PKF/entpass.txt"))
        {
            enter_password = sr.ReadLine();
        }
    }

    void Update()
    {
        
    }

    public void Autorisation()
    {
        if (Login_Check_Text.text == "0" && Password_enter.text == enter_password)
        {
            isLogined = true;
            Login_Check_Text.text = "1";
            Password_enter.text = "";
            Are_U_Logined.text = "You are logged in";
            Are_U_Logined.color = Color.green;
        }
        else
        {
            isLogined = false;
            Login_Check_Text.text = "0";
            Are_U_Logined.text = "You are not logged in";
            Are_U_Logined.color = Color.red;
        }
    }
}
