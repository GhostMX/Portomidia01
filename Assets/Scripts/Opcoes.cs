using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opcoes : MonoBehaviour {
	public Toggle isMute;

	public void AtivarMudo (){
		if (isMute.isOn) {
			//GameManager.instance.SetMudo (true);
		} else {
			//GameManager.instance.SetMudo (false);
		}
	}

	public void VoltarScene(){
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}
}