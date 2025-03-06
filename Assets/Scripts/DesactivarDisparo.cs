using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarDisparo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Siempre que choca con algo, se desactiva el disparo
        gameObject.SetActive(false);
    }

    private void VerificarPosicionEnViewport()
    {
        // convertir la coordenada del mundo del objeto a
        // una posición del viewport
        Vector3 posicionVista = 
            Camera.main.WorldToViewportPoint(transform.position);

        bool salio = false;
        // chequemos si sale por arriba
        if(posicionVista.y > 1f)
            salio = true;

        
        // si está fuera de la vista, hay que desactivarlo
        if(salio)
            gameObject.SetActive(false);
    }

    void Update()
    {
        VerificarPosicionEnViewport();
    }
}
