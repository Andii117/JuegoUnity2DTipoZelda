using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //Traget para este caso jugador
    public GameObject target;
    //Posición del jugador
    private Vector3 targetPosition;
    //Valocidad de la camara
    public float cameraSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Se obtiene la posción del jugador(posición en x,posición en y), (posición de la camara en Z)No se debe modificar
        targetPosition = new Vector3(target.transform.position.x,target.transform.position.y,this.transform.position.z);


    }

    private void LateUpdate() {
        //Actualizamos la posición de la camara con una interpolación que inicia desde la posición actual de la camara, 
        //hasta la posición del jugador con un tiempo delta multiplicado por la velocidad que se inicializó en la variable
        //Movimiento de la camara suavizado
        this.transform.position = Vector3.Lerp(this.transform.position,targetPosition,Time.deltaTime*cameraSpeed);
    }
}
