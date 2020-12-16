using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Security.Cryptography;

public class All_Services : MonoBehaviour
{
    /// <summary>
    /// Is first string a part of second
    /// </summary>
    /// <param name="s_small"></param>
    /// <param name="s_big"></param>
    /// <returns></returns>
    private bool IsPartOfTheString(string s_small, string s_big)
    {
        if (s_small.Length > s_big.Length) { return false; }
        for (int i = 0; i < s_small.Length; i++)
        {
            if (s_small[i] != s_big[i])
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Lengths of two strings are equal
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    private bool Total_Equal(string s1, string s2)
    {
        return s1.Length == s2.Length;
    }

    /// <summary>
    /// All Services Names from DB
    /// </summary>
    public static string[] Services_Names;
    public Text Searching_Service;
    public Text Services_Output;

    /// <summary>
    /// Service from search-line
    /// </summary>
    public static Service SearchedService = new Service();

    void Start()
    {
        MyDataBase.UpdateServices();
    }

    private string PrevSearch = ""; // Previous service name in search-line

    void Update()
    {
        if (PrevSearch != Searching_Service.text)
        {
            Search_By_Word(Searching_Service.text);
            PrevSearch = Searching_Service.text;
        }
        
    }

    /// <summary>
    /// Searchs for typed service name
    /// </summary>
    /// <param name="searching_service"></param>
    private void Search_By_Word(string searching_service)
    {
        if (searching_service.Length >= 1)
        {
            string output = "";
            for (int i = 0; i < Services_Names.Length; i++)
            {
                if (IsPartOfTheString(searching_service, Services_Names[i]))
                {
                    output += Services_Names[i];
                    if (Total_Equal(Services_Names[i], searching_service))
                    {
                         output += " - НАЙДЕНО";
                         SearchedService = MyDataBase.Search_Data(Searching_Service.text); // Seting founded data into SearchedService
                    }
                    output += '\n';
                }
            }

            Services_Output.text = output;
        }
        else
        {
            Services_Output.text = "";
        }
        
    }

}
