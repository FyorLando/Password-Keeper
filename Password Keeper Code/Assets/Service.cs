using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Service
{
    protected int ID;

    /// <summary>
    /// Service name
    /// </summary>
    public string Name;

    /// <summary>
    /// Login of the service
    /// </summary>
    public string Login;

    /// <summary>
    /// Password of the service
    /// </summary>
    public string Password;

    public Service(string name = "None", string login = "None", string password = "None", int id = -1)
    {
        this.Name = name;
        this.Login = login;
        this.Password = password;
        this.ID = id;
    }
}
