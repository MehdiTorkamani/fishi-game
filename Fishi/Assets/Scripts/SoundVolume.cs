using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour {

	public AudioMixer audioMixer;
	static bool volumeOn = true;
	static float vol = 0f;
	Slider slider;
	Toggle toggle;

	void Start()
	{
		slider = GetComponentInChildren<Slider> ();
		toggle = GetComponentInChildren<Toggle> ();
		slider.value = vol;
		audioMixer.SetFloat ("mainVolume", vol);
		toggle.isOn = volumeOn;
	}


	public void ChangeVolume(float volFloat)
	{
		if (volFloat == -30)
		{
			vol = -80;
		}
		else
		vol = volFloat;

		if(volumeOn)
		audioMixer.SetFloat ("mainVolume", vol);
	}

	public void TurnOffOn(bool turnOn)
	{
		if (!turnOn) {
			audioMixer.SetFloat ("mainVolume", -80);
			volumeOn = false;
		} 
		else 
		{
			audioMixer.SetFloat("mainVolume", vol);
			volumeOn = true;
		}
	}


}
