using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    GameObject helmet, backpack;

    [SerializeField]
    SpriteRenderer text1, text2;

    [SerializeField]
    Sprite replacementText1, replacementText2;

    [SerializeField]
    Animator menuAnimator, martyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        menuAnimator.SetTrigger("Collision");
        StartCoroutine(Helper.waitBeforeExecution(5.5f, () => {
            //helmet.SetActive(true);
            //backpack.SetActive(true);

            text1.sprite = replacementText1;
            text2.sprite = replacementText2;

            martyAnimator.SetTrigger("Panic");
        }));
    }
}
