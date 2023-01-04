using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRun : MonoBehaviour
{
    public string sceneToLoad;
    public void OnTriggerEnter2D(Collider2D other)
    {
     
            SceneManager.LoadScene(sceneToLoad);
      
    }


}
