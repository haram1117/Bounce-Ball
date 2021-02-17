using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using System.Threading.Tasks;
using System;

public class Ranking : MonoBehaviour
{
    public Text rankinglist;
    DatabaseReference reference;
    string rankingtext = "";
    string temp = "";
    int user_num;
    // Start is called before the first frame update
    public async void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        await GetResult();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async Task GetResult()
    {
        //await Load_num();
        try
        {
            var snapshot1 = await reference.Child("Users").GetValueAsync().ConfigureAwait(false);
            Debug.Log(snapshot1);

            rankingtext += "NAME: " + snapshot1.Child("name").ToString() + "  DEATH: " + snapshot1.Child("death").ToString();
            Debug.Log(rankingtext);

        }
        catch
        {
            Debug.Log("½ÇÆÐ");
        }
    }
    public async Task Load_num()
    {
        try
        {
            var snapshot = FirebaseDatabase.DefaultInstance.GetReference("User_num").GetValueAsync().ConfigureAwait(false);
            user_num = int.Parse(snapshot.ToString());
            Debug.Log(user_num);
        }
        catch(Exception e)
        {
            Debug.Log("Can't Get the UserNum" + e.ToString());
        }
    }
}
