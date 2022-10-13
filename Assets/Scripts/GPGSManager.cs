using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class GPGSManager : MonoBehaviour
{
    public static GPGSManager instance;

    bool signedIn = false;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Awake()
    {
        SignIn();
    }

    public void SignIn()
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

        Social.ReportScore((long) score, GPGSIds.leaderboard_top_players, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Reported score successfully");
            }
            else
            {
                Debug.Log("Failed to report score");
            }
        });
    }

    public void ShowLeaderboard()
    {
        if (!signedIn) return;

        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }
}
