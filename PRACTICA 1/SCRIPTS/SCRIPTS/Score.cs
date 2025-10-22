using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Calcula cuántos pinos están caídos y muestra el puntaje en pantalla.
/// </summary>
public class Score : MonoBehaviour
{
    // TODO: Texto UI
    public TextMeshProUGUI textoPuntaje;

    // TODO: Variables internas
    private int puntajeActual = 0;
    [SerializedField]
    

    void Start()
    {
        // PISTA: Buscar todos los objetos tipo Pin
        textoPuntaje.text="Puntos"
    }

    public void CalcularPuntaje()
    {
        int puntaje = 0;

        puntaje++;

        puntajeActual = puntaje;

        // PISTA: Actualizar texto del puntaje (validar si textoPuntaje != null)
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntos: " + puntajeActual;
        }
    }
}
