using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    private List<AudioSource> AllSound = new List<AudioSource>();
    // Start is called before the first frame update
    void Awake()
    {
        foreach (AudioSource item in FindObjectsOfType(typeof(AudioSource)))
        {
            AllSound.Add(item);
        }
        Debug.Log(AllSound.Count);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in AllSound)
        {
            item.volume = Setting.soundValue;
        }

        
    }
}
