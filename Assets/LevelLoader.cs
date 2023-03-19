using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
	public Animator transition ;

	public float transitionTime = 1f ;
   

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0))
		// {
		// 	LoadNextLevel();
		// }
    }

	public void LoadNextLevel()
	{
		Debug.Log("Timeout!!!") ;
		StartCoroutine(LoadLevel(1)) ;
	}

	public void LoadNextLevel2()
	{
		Debug.Log("Clear") ;
		StartCoroutine(LoadLevel(2)) ;
	}

	IEnumerator LoadLevel(int levelIndex)
	{
		transition.SetTrigger("Start") ;

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(levelIndex) ;
	}
}
