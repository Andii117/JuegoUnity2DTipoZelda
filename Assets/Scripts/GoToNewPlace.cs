using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New scene Name here!!!";

    public bool clicked = false;

    private void OnTriggerEnter2D(Collider2D other) {
        //Si coliciona con el player
        if(other.gameObject.name == "Player"){
            //Carga la escena si no necesita click
            if(!clicked){
                SceneManager.LoadScene(newPlaceName);
            }            
        }   
    }

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Esta en el OnCollisionStay2D");
        //Si coliciona con el player

        if(other.gameObject.name == "Player"){
            if(clicked && Input.GetMouseButtonDown(0)){
                 //Carga la escena
                SceneManager.LoadScene(newPlaceName);
                Debug.Log("Deberia cargar la escena");
            }
        }
    }
}
