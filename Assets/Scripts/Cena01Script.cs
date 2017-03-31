using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cena01Script : MonoBehaviour {
	private int Moedas = 0;
	private int Pontos = 0;
	private int Vidas = 3;

	public Text MoedasT;
	public Text PontosT;
	public Text VidasT;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DiminuirVidas()	{
		Vidas --;
		VidasT.text = Vidas.ToString();

		if (Vidas == 0)	{
			//GameManager.instance.SetPontos(Pontos);
			SceneManager.LoadScene("GameOverScene");
		}
	}

	public void SomarPontos(){
		Pontos += 100;
		PontosT.text = Pontos.ToString();
	}

}
