using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cena02Script : MonoBehaviour {
	private int Moedas;
	private int Pontos;
	private int Vidas;

	public Text MoedasT;
	public Text PontosT;
	public Text VidasT;

	// Use this for initialization
	void Start () {
		//Moedas = GameManager.instance.GetMoedas ();
		//Pontos = GameManager.instance.GetPontos ();
		//Vidas = GameManager.instance.GetVidas ();
	}

	// Update is called once per frame
	void Update () {

	}
}