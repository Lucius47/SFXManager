// https://github.com/Lucius47/SFXManager



using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager ins;
    [SerializeField] AudioClip[] allClips;

    [SerializeField]
    private Dictionary<string, AudioClip> Clips = new Dictionary<string, AudioClip>();

    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (ins == null) ins = this;

        for (int i = 0; i < allClips.Length; i++)
        {
            Clips.Add(allClips[i].name, allClips[i]);
        }
    }

    /// <summary>
    /// Play the clip once.
    /// </summary>
    /// <param name="clipName">The name of the clip to play.</param>
    public void PlayByName(string clipName)
    {
        try
        {
            audioSource.PlayOneShot(Clips[clipName]);
        }
        catch (System.Exception)
        {
            Debug.LogError("Could not find \"" + clipName + "\" in the list of audio clips");
        }
    }
}
