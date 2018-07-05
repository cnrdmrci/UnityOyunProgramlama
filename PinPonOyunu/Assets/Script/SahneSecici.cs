using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneSecici : MonoBehaviour {

	public void SahneyeGit(string sahneAdi)
    {
        SceneManager.LoadScene(sahneAdi); // ilgili sahneyi yükler
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
