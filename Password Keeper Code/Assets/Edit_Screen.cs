using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Edit_Screen : MonoBehaviour
{
    

    public string[] answer = new string[3];
    public void Searchig_Login_Password()
    {
        string[] current_service = new string[3];
        using (StreamReader sr = new StreamReader("PKF/lpall.txt"))
        {
            while (true)
            {
                current_service = sr.ReadLine().Split();
                if (Service.text == current_service[0])
                {
                    answer[0] = current_service[0];
                    answer[1] = current_service[1];
                    answer[2] = current_service[2];
                    break;
                }
            }
        }

    }


    bool Search_For_Service(string s1, string[] s_arr)
    {
        for (int i = 0; i < s_arr.Length; i++)
        {
            if (s_arr[i] == s1)
            {
                return true;
            }
        }
        return false;
    }

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
            if (!Search_For_Service(Service.text, All_Services.Services))
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

    public void Search()
    {
        
        if (Service.text == "")
        {
            Edit_Windows("Tupoi User");
        }
        else if (Search_For_Service(Service.text, All_Services.Services))
        {
            Edit_Windows("Edit or Delete");
            Searchig_Login_Password();
            Old_Login.text = answer[1];
            Old_Password.text = answer[2];

        }
        else
        {
            if (Contains_(Service.text))
            {
                System_Text.text = "Уберите пробелы, а то бан!";
                System_Text.color = Color.red;
            }
            else 
            {
                Edit_Windows("New");
            }
        }
    }

    void Edit_Windows(string type_of_action)
    {
        if (type_of_action == "Edit or Delete")
        {
            Change_Button.SetActive(true);
            Delete_Button.SetActive(true);
            New_Button.SetActive(false);

            Login_Box.SetActive(true);
            Password_Box.SetActive(true);
            Back_Button.SetActive(true);

            System_Text.text = "Такой сервис уже есть. Измените данные или удалите запись.";
            System_Text.color = Color.green;
        }
        else if (type_of_action == "New")
        {
            Change_Button.SetActive(false);
            Delete_Button.SetActive(false);
            New_Button.SetActive(true);

            Back_Button.SetActive(true);
            Login_Box.SetActive(true);
            Password_Box.SetActive(true);
            System_Text.text = "Введите название сервиса, логин и пароль.";
            System_Text.color = Color.black;
        }
        else if (type_of_action == "Tupoi User")
        {
            Change_Button.SetActive(false);
            Delete_Button.SetActive(false);
            New_Button.SetActive(false);

            Back_Button.SetActive(true);
            Login_Box.SetActive(false);
            Password_Box.SetActive(false);
            System_Text.text = "Вы ничего не ввели.";
            System_Text.color = Color.red;
        }
        else
        {
            Change_Button.SetActive(false);
            Delete_Button.SetActive(false);
            New_Button.SetActive(false);

            Login_Box.SetActive(false);
            Password_Box.SetActive(false);
            Back_Button.SetActive(true);
            System_Text.text = "Введите название сервиса.";
            System_Text.color = Color.black;
        }
        
    }

    public void New_Data()
    {
        if (Search_For_Service(Service.text, All_Services.Services))
        {
            Edit_Windows("Edit or Delete");
            Searchig_Login_Password();
            Old_Login.text = answer[1];
            Old_Password.text = answer[2];
        }
        else
        {
            if (Login.text != "" && Password.text != "")
            {
                if (Contains_(Login.text) || Contains_(Password.text))
                {
                    System_Text.text = "Уберите пробелы, а то бан!";
                    System_Text.color = Color.red;
                }
                else
                {
                    using (StreamWriter sw = File.AppendText("PKF/services.txt"))
                    {
                        sw.Write(" " + Service.text);
                    }

                    using (StreamWriter sw = File.AppendText("PKF/lpall.txt"))
                    {
                        sw.WriteLine(Service.text + " " + Login.text + " " + Password.text + '\n');
                    }

                    System_Text.text = "Вы добавили запись.";
                    System_Text.color = Color.green;
                }
            }
            else
            {
                System_Text.text = "Вы что-то не ввели.";
                System_Text.color = Color.red;
            }
        }
        
    }

    bool Contains_(string s1)
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
            System_Text.text = "Уберите пробелы, а то бан!";
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
                string rewrite = "";

                using (StreamReader sr = new StreamReader("PKF/lpall.txt"))
                {
                    string st = sr.ReadLine();
                    string[] curr_data = st.Split();
                    while (curr_data[0] != Service.text)
                    {
                        rewrite += st + '\n';
                        st = sr.ReadLine();
                        curr_data = st.Split();
                    }

                    st = sr.ReadLine();
                    while (st != null && st != "")
                    {
                        curr_data = st.Split();
                        rewrite += st + '\n';
                        st = sr.ReadLine();
                    }

                }

                File.Delete("PKF/lpall.txt");

                using (StreamWriter sw = new StreamWriter("PKF/lpall.txt", true))
                {
                    sw.WriteLine(rewrite + Service.text + " " + curr_login + " " + curr_password + '\n');
                }

                System_Text.text = "Вы изменили запись.";
                System_Text.color = Color.green;
                Searchig_Login_Password();
                Old_Login.text = answer[1];
                Old_Password.text = answer[2];

            }
            else
            {
                System_Text.text = "Вы что-то не ввели.";
                System_Text.color = Color.red;
            }
        }
        
    }

    public void Delete_Data()
    {
        if (Search_For_Service(Service.text, All_Services.Services))
        {
            if (Contains_(Login.text) || Contains_(Password.text))
            {
                System_Text.text = "Уберите пробелы, а то бан!";
                System_Text.color = Color.red;
            }
            else
            {
                string rewrite = "";

                using (StreamReader sr = new StreamReader("PKF/lpall.txt"))
                {
                    string st = sr.ReadLine();
                    string[] curr_data = st.Split();
                    while (curr_data[0] != Service.text)
                    {
                        rewrite += st + '\n';
                        st = sr.ReadLine();
                        curr_data = st.Split();
                    }

                    st = sr.ReadLine();
                    while (st != null && st != "")
                    {
                        curr_data = st.Split();
                        rewrite += st + '\n';
                        st = sr.ReadLine();
                    }

                }

                File.Delete("PKF/lpall.txt");

                using (StreamWriter sw = new StreamWriter("PKF/lpall.txt", true))
                {
                    sw.WriteLine(rewrite);
                }

                rewrite = "";

                using (StreamReader reader = new StreamReader("PKF/services.txt", true))
                {
                    string st = reader.ReadLine();
                    string[] curr_data = st.Split();
                    bool ch = false;
                    if (curr_data[0] != Service.text)
                    {
                        rewrite += curr_data[0];
                    }
                    else
                    {
                        ch = true;
                    }
                    for (int i = 1; i < curr_data.Length; i++)
                    {
                        if (curr_data[i] != Service.text)
                        {
                            if (ch)
                            {
                                rewrite += curr_data[i];
                                ch = false;
                            }
                            else
                            {
                                rewrite += " " + curr_data[i];
                            }

                        }
                    }
                }

                File.Delete("PKF/services.txt");

                using (StreamWriter sw = new StreamWriter("PKF/services.txt", true))
                {
                    sw.Write(rewrite);
                }

                System_Text.text = "Вы удалили запись.";
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
            System_Text.text = "Введите название сервиса.";
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
        System_Text.text = "Введите название сервиса.";
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
