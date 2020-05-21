using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginRequest 
{
    private string username;
    private string password;

    public string getUsername()
    {
        return username;
    }

    public void setUsername(string username)
    {
        this.username = username;
    }

    public string getPassword()
    {
        return password;
    }

    public void setPassword(string password)
    {
        this.password = password;
    }

    public string toString()
    {
        return "LoginRequest{" +
                "username='" + username + '\'' +
                ", password='" + password + '\'' +
                '}';
    }
}
