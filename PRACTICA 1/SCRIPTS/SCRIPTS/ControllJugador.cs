using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{

    //MOVIMIENTO 
    public float velocidad = 5f; //Velocidad para el movimiento del jugador.
    public float gravedad = -9.8f;  //Controlar la velocidad o fuerza de gravedad en el juego.
    private CharacterController controller; //Permite registrar movimiento en el juego. 
    private Vector3 VelocidadVertical; 

    //Variables Vista
    public Transform camara; //Registra qué cámara funciona como los ojos del jugador.
    public float sensibilidadMouse = 200f; //Grados de visión del jugador
    private float rotacionXVertical = 0f; 




    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); //Busca el componente CharacterController 
        //Esta línea bloquea el puntero del mouse en los límites de la pantalla.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ManejadorVista();
        ManejadorMovimiento();
    }
    void ManejadorVista()
    {
        // 1. Leer el input del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        // 2. Construir la rotación horizontal 

        transform.Rotate(Vector3.up * mouseX);

        // 3. Registro de la rotación vertical
        rotacionXVertical -= mouseY;

        // 4. Limitar la rotación vertical

        Mathf.Clamp(rotacionXVertical, -90f, 90f);

        // 5. Aplicar la rotación 
        // Son los ejes
        camara.localRotation = Quaternion.Euler(rotacionXVertical, 0, 0);

    }
    void ManejadorMovimiento()
    {
        // 1. Leer el input de movimiento. (WASD o las flechas de dirección)
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        // 2. Crear el vector de movimiento.
        //Se almacena en forma local el registro de dirección de movimiento.
        Vector3 direccion = transform.right * inputX + transform.forward * inputZ;

        // 3. Mover el CharacterController
        controller.Move(direccion * velocidad * Time.deltaTime);

        // 4. Aplicar la gravedad 
        //Registro si estoy en el piso para un futuro comportamiento de salto
        if (controller.isGrounded && VelocidadVertical.y <0)
        {
            VelocidadVertical.y = -2f; //Una pequeña fuerza hacia abajo para mantenerlo pegado al piso.

        }
        //Aplicamos la aceleración de la gravedad
        VelocidadVertical.y += gravedad * Time.deltaTime;

        //Movemos el controlador hacia abajo
        controller.Move(VelocidadVertical * Time.deltaTime);


    }
}
