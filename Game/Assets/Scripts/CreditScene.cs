using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour
{
    public void LoadIntro() {
		SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.anyKey) {
			LoadIntro ();
		}
    }
}
