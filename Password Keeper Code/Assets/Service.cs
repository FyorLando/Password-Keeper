using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Service
{
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

    public Service(string name = null, string login = null, string password = null)
    {
        this.Name = name;
        this.Login = login;
        this.Password = password;
    }

    public Service(string[] service)
    {
        this.Name = service[0];
        this.Login = service[1];
        this.Password = service[2];
    }

    public Service Copy()
    {
        return new Service(this.Name, this.Login, this.Password);
    }
}
