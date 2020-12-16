using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Show_All : MonoBehaviour
{

    public Text All;
    private string[] Services_Sorted;
    public GameObject Show_All_Menu;
    public GameObject Main_Screen;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void Show_Them_All()
    {
        if (Login_Check.isLogined)
        {
            Services_Sorted = All_Services.Services_Names;
            Array.Sort(Services_Sorted);

            for (int i = 0; i < Services_Sorted.Length; i++)
            {
                All.text += Services_Sorted[i] + "\n";
            }

        
            Show_All_Menu.SetActive(true);
            Main_Screen.SetActive(false);
        }
        
    }

    public void Back()
    {
        All.text = "";
        Show_All_Menu.SetActive(false);
        Main_Screen.SetActive(true);
    }
}
