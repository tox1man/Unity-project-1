using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public float _volumeValue;

    public static void PlaySound(string soundObjectName)
    {
        GameObject.Find(soundObjectName).GetComponent<AudioSource>().Play();
    }
    public static void StopSound(string soundObjectName)
    {
        GameObject.Find(soundObjectName).GetComponent<AudioSource>().Stop();
    }

    public void ChangeVolume()
    {
        float newVolume = GameObject.Find("Slider").GetComponent<Slider>().value;
        AudioSource[] childrenList = gameObject.transform.GetComponentsInChildren<AudioSource>();

        foreach (AudioSource src in childrenList)
        {
            src.volume = newVolume;
        }
    }
}
