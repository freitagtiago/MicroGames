using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        int numMusicPlayerInstances = FindObjectsOfType<MusicPlayer>().Length;
        if(numMusicPlayerInstances > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
