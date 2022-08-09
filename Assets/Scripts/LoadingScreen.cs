using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    Image blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        gameObject.SetActive(false);
        blackScreen = gameObject.GetComponent<Image>();
    }

    public IEnumerator Transition()
    {
        float alpha = blackScreen.color.a;
        while (alpha < 1)
        {
            alpha = blackScreen.color.a + Time.deltaTime;
            blackScreen.color = new Vector4(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, alpha);
            yield return null;
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");

        while (!asyncLoad.isDone)
            yield return null;

        while (alpha > 0)
        {
            alpha = blackScreen.color.a - Time.deltaTime;
            blackScreen.color = new Vector4(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, alpha);
            yield return null;
        }

        blackScreen.gameObject.SetActive(false);
    }
    
}
