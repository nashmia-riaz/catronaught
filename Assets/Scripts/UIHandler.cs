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

    private void Start()
    {
        DontDestroyOnLoad(blackScreen.gameObject);
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
