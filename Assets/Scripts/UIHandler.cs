using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    GameObject helmet, backpack;

    [SerializeField]
    SpriteRenderer text1, text2;

    [SerializeField]
    Sprite replacementText1, replacementText2;

    [SerializeField]
    Animator menuAnimator, martyAnimator, canvasAnimator;

    [SerializeField]
    AudioClip crashSound;

    [SerializeField]
    Image soundImage;

    [SerializeField]
    Sprite muteSprite, unmuteSprite;

    bool isAudioMuted = false;

    [SerializeField]
    AudioSource musicSource, sfxSource;

    private void Start()
    {
        isAudioMuted = PlayerPrefs.GetInt("Sound", 1) == 0;
        SetAudio();
        DontDestroyOnLoad(blackScreen.gameObject);
    }

    public void ClickLink(string link)
    {
        Application.OpenURL(link);
    }
    void SetAudio()
    {
        if (!isAudioMuted)
        {
            soundImage.sprite = unmuteSprite;
            musicSource.volume = sfxSource.volume = 0.5f;
        }
        else
        {
            musicSource.volume = sfxSource.volume = 0;
            soundImage.sprite = muteSprite;
        }

    }

    public void MuteAudio()
    {
        isAudioMuted = !isAudioMuted;

        SetAudio();

        PlayerPrefs.SetInt("Sound", isAudioMuted ? 0 : 1);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Loaded scene " + scene.name);
        this.GetComponent<Canvas>().worldCamera = Camera.main;

    }
    public void OnClickPlay()
    {
        Debug.Log("Click play");
        blackScreen.gameObject.SetActive(true);
        canvasAnimator.SetTrigger("FadeOut");

        menuAnimator.SetTrigger("Collision");
        StartCoroutine(Helper.waitBeforeExecution(5.5f, () => {
            SFXAudioScript.instance.PlaySound(crashSound, 0.1f);

            text1.sprite = replacementText1;
            text2.sprite = replacementText2;

            martyAnimator.SetTrigger("Panic");
        }));

        StartCoroutine(Helper.waitBeforeExecution(7.5f, () =>
        {
            StartCoroutine(blackScreen.Transition());
        }));
    }

    [SerializeField]
    LoadingScreen blackScreen;

}
