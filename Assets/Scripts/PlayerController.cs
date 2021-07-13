using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //para que se cargue una unica vez el jugador
    public static bool playerCreated;

    //Valocidad del player
    public float speed = 5.0f;

    //Variable para validar si esta caminando
    private bool walking = false;
    //Variable para saber cual es el ultimo movimiento para dejar ese sprite en pantalla Mirar ultima ubicación
    public Vector2 lastMovement = Vector2.zero;

    //Constante para los nombres que comunican el Hardware con el Software Input configuration
    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical";

    //Variable para ejecutar el animator( del player)
    private Animator _anim;

    private Rigidbody2D _Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerCreated = true;
        
        //Se inicializa el componente animator del player
        _anim        = GetComponent<Animator>();
        //Componente para mover al personaje con la fisica del motor
        _Rigidbody   = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Todo frame inciara con variable false
        walking = false;
        if(Mathf.Abs(Input.GetAxisRaw(AXIS_H))> 0.2f){
             
            /*Mover el personaje sin el motor de fisicas 
                                        //  X                                                 y z
            Vector3 traslation = new Vector3(Input.GetAxisRaw(AXIS_H) * speed* Time.deltaTime,0,0); 
            //Ejecuta el movimiento en el personaje Vertical (<>)
            this.transform.Translate(traslation);
            */
            //Mover al personaje con el motor de fisicas
            _Rigidbody.velocity = new Vector2(Input.GetAxisRaw(AXIS_H)*this.speed, _Rigidbody.velocity.y);
            //Estoy caminando
            walking = true;
            //Guardar el ultimo movimiento conocido en H
            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H),0);
        }
        if(Mathf.Abs(Input.GetAxisRaw(AXIS_V))> 0.2f){
           /*Mover el personaje sin el motor de fisicas
                                           //x  y                                              z 
            Vector3 traslation = new Vector3(0 ,Input.GetAxisRaw(AXIS_V)* speed*Time.deltaTime,0); 
            //Ejecuta el movimiento en el personaje Vertical (^v)
            this.transform.Translate(traslation);
            */

            //Mover al personaje con el motor de fisicas
            _Rigidbody.velocity = new Vector2(_Rigidbody.velocity.x, Input.GetAxisRaw(AXIS_V)*this.speed);
            //Estoy caminando
            walking = true;
            //Guardar el ultimo movimiento conocido en V
            lastMovement = new Vector2(0,Input.GetAxisRaw(AXIS_V));
        }
    }

    //Para la animación en 2D se utiliza el método LateUpdate(Se ejecuta en el ultimo frame)
    private void LateUpdate() {

        //Se corrige el movimiento para que no patine
        if(!walking){
            _Rigidbody.velocity = Vector2.zero;
        }

        //Envia la acción del ejecutar la animación con las variables de los parámetros del
        //Animator "Horizontal","Vertical" dado la tecla que se este ejecutando
        //Los set reciben dos parámetros (como se llama la variable en el animator, el valor de la variable)
        _anim.SetFloat(AXIS_H,Input.GetAxisRaw(AXIS_H));
        _anim.SetFloat(AXIS_V,Input.GetAxisRaw(AXIS_V));

        //Se esta ejecutando la función de caminar
        _anim.SetBool("Walking",walking);
        //Ultima posición en H (Las variables tipo Vector2 permiten consultar el resultado en x)
        _anim.SetFloat("LastH",lastMovement.x);
        //Ultima posición en V (Las variables tipo Vector2 permiten consultar el resultado en y)
        _anim.SetFloat("LastV",lastMovement.y);
        
    }
}
