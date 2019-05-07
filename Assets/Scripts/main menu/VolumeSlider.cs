using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] private string ParameterName;
    [SerializeField] private Vector2 _VolumeRange = new Vector2(-80f, 0);

    private Slider _slider;

	// Use this for initialization
	void Start () {
        _slider = GetComponent<Slider>();
        _slider.value = PlayerPrefs.GetFloat(ParameterName, 1f);
	}
	
	// Update is called once per frame
	private void Update () {
        float mixerValue = Mathf.Lerp(_VolumeRange.x, _VolumeRange.y, _slider.value);
        AudioMixer.SetFloat(ParameterName, mixerValue);
        PlayerPrefs.SetFloat(ParameterName, _slider.value);
	}
}
