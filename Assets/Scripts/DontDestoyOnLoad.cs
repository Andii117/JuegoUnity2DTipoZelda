using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoyOnLoad : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
        //Valida si el jugador ya esta creado
        if(!PlayerController.playerCreated){
        //Se camgue la informaicón sin destruir
        DontDestroyOnLoad(this.transform.gameObject);
        }else{
            //Destruir más de un mismo objeto
            Destroy(gameObject);
        }
    }
}
