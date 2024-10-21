using System;
using System.Collections;
using System.Collections.Generic;\
using System.Threading.Tasks;
using UnityEngine;




public class SQLManager: MonoBehaviour

{
    readonly static string SERVER_URL = "localhost:80/CyberlyBackend/Cyberly";
    public static Type async Task<bool> NewUserReg(string f_name, string lname, string user_name, string password, string email, DateTime DOB);

    public string f_name;
    public string l_name;
    public string user_name;
    public string password;
    public string email;
    public DateTime DOB;


    public void Start()
    {
        
    }

    public void Update()
    {
        
    }
}