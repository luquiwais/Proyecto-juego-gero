using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variable entera para llevar la cuenta de los objetos recolectados
    private int objetosRecolectados = 0;

    // Este método se ejecuta automáticamente cuando otro objeto entra en el Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto con el que chocamos tiene la etiqueta "Coleccionable"
        if (other.CompareTag("Coleccionable"))
        {
            // Sumamos 1 al contador
            objetosRecolectados++;

            // Mostramos el total actual en la consola de Unity
            Debug.Log("¡Objeto recolectado! Total: " + objetosRecolectados);

            // Destruimos el objeto con el que se ha colisionado (la taza)
            Destroy(other.gameObject);
        }
    }
}