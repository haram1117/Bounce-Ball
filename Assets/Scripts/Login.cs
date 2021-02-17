using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using Firebase;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [Header("Login")]
    public GameObject Login_UI;
    public InputField login_id;
    public InputField login_pw;
    public Text TextMessage;

    [Header("Register")]
    public GameObject Register_UI;
    public InputField register_id;
    public InputField register_pw;
    public InputField register_name;
    public InputField register_pw_v;

    private bool LoggedIn = false;
    private bool PWerror = false;
    private bool IDerror = false;
    public static string id;
    private int usernum = 0;

    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register_Screen()
    {
        Register_UI.SetActive(true);
        Login_UI.SetActive(false);
    }
    public void Login_Screen()
    {
        Login_UI.SetActive(true);
        Register_UI.SetActive(false);
    }
    public async void CreateUser()
    {
        if(register_pw.text != register_pw_v.text)
        {
            Debug.Log("패스워드가 일치하지 않습니다.");
        }
        else
        {
            await Load_Num();
            usernum++;
            Debug.Log(usernum);
            User user = new User(register_id.text, register_name.text, register_pw.text);
            string json = JsonUtility.ToJson(user);
            await reference.Child("Users").Child(user.id).SetRawJsonValueAsync(json);
            await reference.Child("User_num").SetValueAsync(usernum);
            Login_Screen();
        }
    }
    public void User_remember(ref string id)
    {
        id = register_id.text;
    }
    void Logged_In()
    {
        SceneManager.LoadScene("Stage");
        id = login_id.text;
    }
    public async void Login_btn()
    {
        await Login_DB();
        if (LoggedIn)
        {
            Invoke("Logged_In", 2);
            TextMessage.text = "Logging In...";
        }else if (IDerror)
        {
            TextMessage.text = "아이디를 다시 확인해주세요.";
        }else if (PWerror)
        {
            TextMessage.text = "패스워드를 다시 확인해주세요.";
        }
        else { TextMessage.text = "에러발생!! 에러발생!!"; }
            
    }
    public async Task Login_DB()
    {
        try
        {
            var snapshot = await FirebaseDatabase.DefaultInstance.GetReference("Users").Child(login_id.text).Child("password").GetValueAsync().ConfigureAwait(false);
            if(snapshot.Value.ToString() == login_pw.text)
            {
                LoggedIn = true;
            }
            else
            {
                PWerror = true;
            }
        }
        catch
        {
            IDerror = true;
        }
    }
    public async Task Load_Num()
    {
        try
        {
            var snapshot = await FirebaseDatabase.DefaultInstance.GetReference("User_num").GetValueAsync().ConfigureAwait(false);
            usernum = int.Parse(snapshot.Value.ToString());
        }
        catch(Exception e)
        {
            Debug.Log("사용자수를 불러오는데 오류가 발생했습니다." + e.ToString());
        }
    }
}
class User
{
    public string id;
    public string name;
    public string password;
    public int stage = 0;
    public int death = 0;
    public User(string _id, string _name, string _password)
    {
        id = _id;
        name = _name;
        password = _password;
    }
    public void StageUp()
    {
        stage++;
    }
    public int StageInfo()
    {
        return stage;
    }
}