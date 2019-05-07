using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

    [SerializeField] private string SceneName;

    private Button _button;
	// Use this for initialization
	void Start () {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => LoadScene(SceneName));
        
	}
	
    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
