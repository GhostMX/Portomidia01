using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	private int PontosFinal;

	public Text Pontos;

	// Use this for initialization
	void Start () {
		//PontosFinal = GameManager.instance.GetPontos();
		Pontos.text = PontosFinal.ToString();
	}

	// Update is called once per frame
	void Update () {

	}

	public void MenuGame(){
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}

	public void ExitGame(){
		SceneManager.LoadScene ("Sair", LoadSceneMode.Single);
	}
}
