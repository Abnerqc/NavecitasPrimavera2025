using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisparosNave : MonoBehaviour
{
    [SerializeField] private Transform puntoDeDisparo;
    [SerializeField] private float velocidadDisparo;
    [SerializeField] private float fireRate; // intervalo entre disparos

    private ObjectPooling pooling;
    private float tiempoDesdeUltimoDisparo;

    private void OnFire()
    {
        // Verificamos si ya pasó el tiempo suficiente desde ultimo disparo
        if(tiempoDesdeUltimoDisparo >= fireRate)
        {
            //Debug.Log("disparo");
            // le pregunto al pool si me presta un disparo
            GameObject disparo = pooling.GetObjeto();
            // si no hubo disparo, me salgo
            if(disparo == null)
                return;
            
            // si sí hubo disparo
            // coloco el disparo en el punto de disparo
            disparo.transform.position = puntoDeDisparo.position;
            // lo roto en dirección de la nave
            disparo.transform.rotation = transform.rotation;
            // le asigno una velocidad
            disparo.GetComponent<Rigidbody2D>().velocity = 
                transform.right * velocidadDisparo;

            // reinicio el tiempo transcurrido
            tiempoDesdeUltimoDisparo = 0f;
        }
    }

    void Start()
    {
        pooling = GetComponent<ObjectPooling>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDesdeUltimoDisparo += Time.deltaTime;
    }
}
