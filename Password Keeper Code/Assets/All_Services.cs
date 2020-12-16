using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Security.Cryptography;

public class All_Services : MonoBehaviour
{
    bool StringsAreEqual(string s1, string s2)
    {
        for (int i = 0; i < s2.Length; i++)
        {
            if (s2[i] != s1[i])
            {
                return false;
            }
        }
        return true;
    }

    bool Total_Equal(string s1, string s2)
    {
        if (s1.Length == s2.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static string[] Services; // Все сервисы с индексами
    public Text Searching_Service;
    public Text Services_Output;
    public string SS;
    string Service_to_find;

    void Start()
    {
        
    }

    void Update()
    {
        using (StreamReader sr = new StreamReader("PKF/services.txt"))
        {
            Services = sr.ReadLine().Split();
        }
        SS = Searching_Service.text;
        Search_By_Word(SS);
    }

    void Search_By_Word(string SS)
    {
        
        if (SS.Length >= 1)
        {
            string output = "";
            for (int i = 0; i < Services.Length; i++)
            {
                if (Services[i].Length >= SS.Length)
                {
                    if (StringsAreEqual(Services[i], SS))
                    {
                        output += Services[i];
                        if (Total_Equal(Services[i], SS))
                        {
                            Service_to_find = SS;
                            output += " - НАЙДЕНО";
                            break;
                        }
                        output += '\n';
                    }
                }          
            }

            Services_Output.text = output;
        }
        else
        {
            Services_Output.text = "";
        }
        
    }

    public static Service answer = new Service();

    public void Searchig_Login_Password()
    {
        string[] current_service = new string[3];
        using (StreamReader sr = new StreamReader("PKF/lpall.txt"))
        {
            while (true)
            {
                current_service = sr.ReadLine().Split();
                if (Service_to_find == current_service[0])
                {
                    answer.Name = current_service[0];
                    answer.Login = current_service[1];
                    answer.Password = current_service[2];
                    break;
                }
            } 
        }
        
    }

    
}
