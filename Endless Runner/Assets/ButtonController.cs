using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
	public Button button;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(restartGame);
	}

	void restartGame()
	{ 
		Debug.Log("You have clicked the restart button!");
		SceneManager.LoadScene("mainScene");
	}
}
