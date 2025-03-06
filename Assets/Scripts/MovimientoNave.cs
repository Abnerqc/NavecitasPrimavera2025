using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // para el "nuevo" sistema de entradas

public class MovimientoNave : MonoBehaviour
{
    [SerializeField] private float speed; // vel mov nave
    [SerializeField] private float rotationSpeed; // vel rotacion

    private Rigidbody2D rb;
    private Vector2 inputMovimiento; // para recibir el input

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Mover()
    {
        // lo que haya apretado el jugador por velocidad
        Vector2 velocidad = inputMovimiento * speed;
        rb.velocity = velocidad;
    }

    private void OnMove(InputValue valorEntrada)
    {
        inputMovimiento = valorEntrada.Get<Vector2>();
    }

    private void Rotar()
    {
        // si la nave tiene movimiento
        if(inputMovimiento != Vector2.zero)
        {
            // calculo el angulo de rotacion
            float angulo = 
                Mathf.Atan2(inputMovimiento.y, inputMovimiento.x) *
                Mathf.Rad2Deg;
            // Creo la rotacion que le voy a pasar a la nave
            Quaternion rotacionDestino = 
                Quaternion.AngleAxis(angulo, Vector3.forward);
            // Le asigno dicha rotacion
            transform.rotation = 
                Quaternion.RotateTowards(
                    transform.rotation, // desde donde
                    rotacionDestino, // hasta donde
                    rotationSpeed * Time.deltaTime);   
        }
    }

    void Update()
    {
        Mover();
        Rotar();
    }
}
