using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] luz;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
        Item itemRecodigo = other.GetComponent<item>();
    If(itemRecodigo!=null)
    {
        itemRecodigo.Recoger();
    }
    {
        if (other.CompareTag("arcade"))
        {
           // luz.SetActive(true);
           foreach (var l in luces)
            {
                luz.SetActive(true);
            }
            Debug.Log("Hecha una ficha");
            if (other.CompareTag("item"))
            {
                Score.CalcularPuntaje();
                other.gameObject.SetActive(false);
                Debug.Log("Obtuviste un Dolar");
            }
        }
        if (other.CompareTag("item"))
        {
            // luz.SetActive(true);
            foreach (var l in luces)
            {
                luz.SetActive(false);
            }
            //luz.SetActive(false);
            Debug.Log("Game Over: Regresa cuando quieras")
        }
    }
}
