using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    void Start()
    {
        StartCoroutine(backToMain());
        
    }

    IEnumerator backToMain(){
        yield return new WaitForSeconds(2);
        Application.LoadLevel("Main Menu");
    }

}
