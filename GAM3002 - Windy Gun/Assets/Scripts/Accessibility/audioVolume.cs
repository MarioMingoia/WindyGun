using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audioVolume : MonoBehaviour
{
    [SerializeField]
    private GameObject accessibility;

    public int typeOfAudio;

    [SerializeField]
    private AudioSource myAudioSource;

    private void Start()
    {
        accessibility = GameObject.Find("newPlayer").transform.GetChild(4).gameObject;
        myAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        switch (typeOfAudio)
        {
            case 0:
                myAudioSource.volume = accessibility.GetComponent<accessibilityOptions>().BGMSlider.value / 100;
                break;
            case 1:
                myAudioSource.volume = accessibility.GetComponent<accessibilityOptions>().VoiceSlider.value / 100;
                break;   
            case 2:
                myAudioSource.volume = accessibility.GetComponent<accessibilityOptions>().effectsSlider.value / 100;
                break;
            default:
                break;
        }
    }
}
