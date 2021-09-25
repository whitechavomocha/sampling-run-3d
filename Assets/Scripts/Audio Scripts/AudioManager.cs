using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static AudioSource audioSource;
 

    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    public static void Initialize(AudioSource source)
    {
        audioSource = source;

        if (!audioClips.ContainsKey(AudioClipName.CollectWateringCan))
        {
        audioClips.Add(AudioClipName.CollectWateringCan,
        Resources.Load<AudioClip>("Sounds/Collect_Can"));
        }

        if (!audioClips.ContainsKey(AudioClipName.Confetti))
        {
        audioClips.Add(AudioClipName.Confetti,
        Resources.Load<AudioClip>("Sounds/Confetti Sound"));
        }

        if (!audioClips.ContainsKey(AudioClipName.Trap))
        {
        audioClips.Add(AudioClipName.Trap,
        Resources.Load<AudioClip>("Sounds/Cut_Effect"));
        }

        if (!audioClips.ContainsKey(AudioClipName.CartoonBubble))
        {
            audioClips.Add(AudioClipName.CartoonBubble,
            Resources.Load<AudioClip>("Sounds/Cartoon Bubble"));
        }

        if (!audioClips.ContainsKey(AudioClipName.Victory))
        {
            audioClips.Add(AudioClipName.Victory,
            Resources.Load<AudioClip>("Sounds/Victory"));
        }

        if (!audioClips.ContainsKey(AudioClipName.Failed))
        {
            audioClips.Add(AudioClipName.Failed,
            Resources.Load<AudioClip>("Sounds/Failed"));
        }






    }
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name], GameManager.Sound);
    }

    public static void ClearSound()
    {
        audioClips.Clear();
        Initialize(audioSource);
    }

 
}
