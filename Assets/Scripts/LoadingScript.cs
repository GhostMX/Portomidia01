using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

	public float loadingTime;
	public Image loadingBar;
	public Text percent;
	private float contagem;

	void Start () {
		contagem = 0f;
	}


	void Update () {
	
		if (contagem < 1.0f) {
			contagem += 1.0f / loadingTime * Time.deltaTime;
		}
		if (contagem >= 1.0f) {
			SceneManager.LoadScene("02Menu", LoadSceneMode.Single);
		}

	}
}
