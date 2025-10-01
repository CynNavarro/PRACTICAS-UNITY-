using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CONTROL_BOLA : MonoBehaviour
{
    public Transform CamaraPrincipal;
    public Rigidbody rb;
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;

    public float fuerzaDeLanzamiento = 1000f;
    private bool haSidoLanzada = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //EXPRESIÓN
        if (haSidoLanzada == false)
        {
            Apuntar();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }
        }
    }
    void Apuntar();
    {
    float inputHorizontal = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right* inputHorizontal * velocidadDeApuntado* Time.deltaTime);
    Vector3 posicionActual = transform.position;
    posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;
}
    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);

    if (CamaraPrincipal)
    {
        CamaraPrincipal.SetParent(transform);
    }
        
    }

} // BIENVENIDO A LA ENTRADA AL INFIERNO.
