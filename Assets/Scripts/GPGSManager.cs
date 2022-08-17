using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GPGSManager : MonoBehaviour
{
    public static GPGSManager instance;

    bool signedIn = false;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);

    }
    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            signedIn = true;
        }
        else
        {
            signedIn = false;
        }
    }

    public void PostScore(float score)
    {
        if (!signedIn) return;

        Social.ReportScore((long) score, GPGSIds.leaderboard_top_10_players, (bool success) =>
        {
            if (success)
            {

            }
            else
            {

            }
        });
    }
}
