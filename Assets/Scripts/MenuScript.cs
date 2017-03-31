using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadGameScene(){
		SceneManager.LoadScene ("03Game", LoadSceneMode.Single);
	}
	public void OptionGameScene(){
		SceneManager.LoadScene ("Opcoes", LoadSceneMode.Single);
	}
	public void LoadCreditosScene(){
		SceneManager.LoadScene ("Credito", LoadSceneMode.Single);
	}
	public void LoadTutorialScene(){
		SceneManager.LoadScene ("Tutorial", LoadSceneMode.Single);
	}
	public void QuitGameScene(){
		Application.Quit ();
	}
	public void MenuScene(){
		SceneManager.LoadScene ("02Menu", LoadSceneMode.Single);
	}
}
