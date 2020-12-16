using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

public class MyDataBase
{
    /// <summary>
    /// Searchs and returns data from DB
    /// </summary>
    public static Service Search_Data(string service_name)
    {
        Service current_service = new Service(); // Current service from DB
        using (StreamReader sr = new StreamReader("PKF/lpall.txt"))
        {
            while (true)
            {
                current_service = new Service(sr.ReadLine().Split());
                if (service_name == current_service.Name)
                {
                    return current_service.Copy();
                }
            }
        }
    }

    /// <summary>
    /// Writes data into DataBase
    /// </summary>
    public static void Write_Data(string name, string login, string password)
    {
        using (StreamWriter sw = File.AppendText("PKF/services.txt"))
        {
            sw.Write(" " + name);
        }

        using (StreamWriter sw = File.AppendText("PKF/lpall.txt"))
        {
            sw.WriteLine(name + " " + login + " " + password + '\n');
        }

        UpdateServices();
    }

    /// <summary>
    /// Edits data in DataBase
    /// </summary>
    public static void Edit_Data(string name, string login, string password)
    {
        string rewrite = "";

        using (StreamReader sr = new StreamReader("PKF/lpall.txt"))
        {
            string st = sr.ReadLine();
            string[] curr_data = st.Split();
            while (curr_data[0] != name)
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
            sw.WriteLine(rewrite + name + " " + login + " " + password + '\n');
        }
    }

    /// <summary>
    /// Edits data in DataBase
    /// </summary>
    public static void Delete_Data(string name)
    {
        string rewrite = "";

        using (StreamReader sr = new StreamReader("PKF/lpall.txt"))
        {
            string st = sr.ReadLine();
            string[] curr_data = st.Split();
            while (curr_data[0] != name)
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
            if (curr_data[0] != name)
            {
                rewrite += curr_data[0];
            }
            else
            {
                ch = true;
            }
            for (int i = 1; i < curr_data.Length; i++)
            {
                if (curr_data[i] != name)
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

        UpdateServices();
    }

    /// <summary>
    /// Does service exists in DataBase
    /// </summary>
    public static bool Search_For_Service(string service_search, string[] services_names)
    {
        for (int i = 0; i < services_names.Length; i++)
        {
            if (services_names[i] == service_search)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Rewrites array of services names
    /// </summary>
    public static void UpdateServices()
    {
        using (StreamReader sr = new StreamReader("PKF/services.txt"))
        {
            All_Services.Services_Names = sr.ReadLine().Split();
        }
        
    }
}
