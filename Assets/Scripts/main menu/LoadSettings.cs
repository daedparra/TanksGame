using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadSettings : MonoBehaviour {

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string[] _AudioParameters;
    [SerializeField] private Vector2 _VolumeRange = new Vector2(-80f, 0f);
    // Use this for initialization
	private void Start () {
		for(int i=0; i < _AudioParameters.Length; i++)
        {
            string parameter = _AudioParameters[i];
            float savedValue = PlayerPrefs.GetFloat(parameter, 1f);
            float mixerValue = Mathf.Lerp(_VolumeRange.x, _VolumeRange.y, savedValue);
            _audioMixer.SetFloat(parameter, mixerValue);
        }
	}
	

}
