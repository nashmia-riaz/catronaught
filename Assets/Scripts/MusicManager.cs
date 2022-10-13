using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> musicClips = new List<AudioClip>();

    AudioSource audioSource;

    int currentMusicClip = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentMusicClip = Random.Range(0, musicClips.Count);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void PlayMusic()
    {
        audioSource.clip = musicClips[currentMusicClip];
        audioSource.Play();
        currentMusicClip++;
        if (currentMusicClip >= musicClips.Count)
            currentMusicClip = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayMusic();
        }
    }
}
