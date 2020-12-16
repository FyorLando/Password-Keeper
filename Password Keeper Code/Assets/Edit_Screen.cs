using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Edit_Screen : MonoBehaviour
{
    public Service answer = new Service(); // Answer to the request

    /// <summary>
    /// Searching for service in array of Services Names from DB
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s_arr"></param>
    /// <returns></returns>
    

    public InputField Service;
    public InputField Login;
    public InputField Password;
    public Text System_Text;

    public Text Old_Login;
    public Text Old_Password;

    public GameObject Login_Box;
    public GameObject Password_Box;

    public GameObject Edit_Window;
    public GameObject Main_Window;


    public GameObject Change_Button;
    public GameObject Delete_Button;
    public GameObject New_Button;
    public GameObject Search_Button;
    public GameObject Back_Button;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Service.text != "")
        {
            if (!MyDataBase.Search_For_Service(Service.text, All_Services.Services_Names))
            {
                Old_Login.text = "";
                Old_Password.text = "";

            }
        }
        else
        {
            Old_Login.text = "";
            Old_Password.text = "";
        }
    }

    /// <summary>
    /// Giving results of searching in DB
    /// </summary>
    public void Search()
    {
        if (Service.text == "")
        {
            Edit_Windows("Nothing Is Written");
        }
        else if (MyDataBase.Search_For_Service(Service.text, All_Services.Services_Names))
        {
            Edit_Windows("Edit or Delete");
            answer = MyDataBase.Search_Data(Service.text);
            Old_Login.text = answer.Login;
            Old_Password.text = answer.Password;

        }
        else
        {
            if (Contains_(Service.text))
            {
                System_Text.text = "No spaces between words!";
                System_Text.color = Color.red;
            }
            else 
            {
                Edit_Windows("New");
            }
        }
    }

    /// <summary>
    /// Changing system-state window and buttons
    /// </summary>
    /// <param name="type_of_action"></param>
    void Edit_Windows(string type_of_action)
    {
        switch (type_of_action)
        {
            case "Edit or Delete":
                Change_Button.SetActive(true);
                Delete_Button.SetActive(true);
                New_Button.SetActive(false);

                Login_Box.SetActive(true);
                Password_Box.SetActive(true);
                Back_Button.SetActive(true);

                System_Text.text = "The service already exitsts. Change or delete data.";
                System_Text.color = Color.green;
                break;
            case "New":
                Change_Button.SetActive(false);
                Delete_Button.SetActive(false);
                New_Button.SetActive(true);

                Back_Button.SetActive(true);
                Login_Box.SetActive(true);
                Password_Box.SetActive(true);
                System_Text.text = "Type the name of service, login and password.";
                System_Text.color = Color.black;
                break;
            case "Nothing Is Written":
                Change_Button.SetActive(false);
                Delete_Button.SetActive(false);
                New_Button.SetActive(false);

                Back_Button.SetActive(true);
                Login_Box.SetActive(false);
                Password_Box.SetActive(false);
                System_Text.text = "You didn't write anything.";
                System_Text.color = Color.red;
                break;
            default:
                Change_Button.SetActive(false);
                Delete_Button.SetActive(false);
                New_Button.SetActive(false);

                Login_Box.SetActive(false);
                Password_Box.SetActive(false);
                Back_Button.SetActive(true);
                System_Text.text = "Type the name of the service.";
                System_Text.color = Color.black;
                break;
        }
    }

    public void New_Data()
    {
        if (MyDataBase.Search_For_Service(Service.text, All_Services.Services_Names))
        {
            Edit_Windows("Edit or Delete");
            answer = MyDataBase.Search_Data(Service.text);
            Old_Login.text = answer.Login;
            Old_Password.text = answer.Password;
        }
        else
        {
            if (Login.text != "" && Password.text != "")
            {
                if (Contains_(Login.text) || Contains_(Password.text))
                {
                    System_Text.text = "No spaces between words!";
                    System_Text.color = Color.red;
                }
                else
                {
                    MyDataBase.Write_Data(Service.text, Login.text, Password.text);
                    System_Text.text = "You added new service.";
                    System_Text.color = Color.green;
                }
            }
            else
            {
                System_Text.text = "You forgot to write something.";
                System_Text.color = Color.red;
            }
        }
        
    }

    private bool Contains_(string s1)
    {
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] == ' ')
            {
                return true;
            }
        }
        return false;
    }

    public void Edit_Data()
    {
        if (Contains_(Login.text) || Contains_(Password.text))
        {
            System_Text.text = "No spaces between words!";
            System_Text.color = Color.red;
        }
        else
        {
            string curr_login = Old_Login.text;
            string curr_password = Old_Password.text;

            if (Login.text != "")
            {
                curr_login = Login.text;
            }
            if (Password.text != "")
            {
                curr_password = Password.text;
            }

            if (curr_login != "" && curr_password != "")
            {
                MyDataBase.Edit_Data(Service.text, curr_login, curr_password);

                System_Text.text = "You edited service data.";
                System_Text.color = Color.green;
                answer = MyDataBase.Search_Data(Service.text);
                Old_Login.text = answer.Login;
                Old_Password.text = answer.Password;

            }
            else
            {
                System_Text.text = "You forgot to write something.";
                System_Text.color = Color.red;
            }
        }
        
    }

    public void Delete_Data()
    {
        if (MyDataBase.Search_For_Service(Service.text, All_Services.Services_Names))
        {
            if (Contains_(Login.text) || Contains_(Password.text))
            {
                System_Text.text = "No spaces between words!";
                System_Text.color = Color.red;
            }
            else
            {
                MyDataBase.Delete_Data(Service.text);

                System_Text.text = "You deleted service.";
                System_Text.color = Color.red;
                Old_Login.text = "";
                Old_Password.text = "";
            }
        }
        else
        {
            Change_Button.SetActive(false);
            Delete_Button.SetActive(false);
            New_Button.SetActive(false);

            Login_Box.SetActive(false);
            Password_Box.SetActive(false);
            System_Text.text = "Write service name.";
            System_Text.color = Color.black;
        }
        
    }

    public void Back()
    {
        Service.text = "";
        Login.text = "";
        Password.text = "";
        Change_Button.SetActive(false);
        Delete_Button.SetActive(false);
        New_Button.SetActive(false);

        Login_Box.SetActive(false);
        Password_Box.SetActive(false);
        System_Text.text = "Write service name.";
        System_Text.color = Color.black;

        Edit_Window.SetActive(false);
        Main_Window.SetActive(true);
    }

    public void Edit_Start()
    {
        if (Login_Check.isLogined)
        {
            Edit_Window.SetActive(true);
            Main_Window.SetActive(false);
        }
        
    }
}
