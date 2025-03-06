using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    [SerializeField] private GameObject prefabAsteroideMenor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // preguntar si me pega un laser de jugador
        if(collision.gameObject.tag == "disparo")
        {
            // verificar si me tengo que dividir
            if(prefabAsteroideMenor) // if(prefabAsteroideMenor != null)
            {
                Vector3 desplazamiento = Vector3.up * 0.2f;
                Instantiate(
                    prefabAsteroideMenor, transform.position + desplazamiento, Quaternion.identity);
                Instantiate(
                    prefabAsteroideMenor, transform.position - desplazamiento, Quaternion.identity);
            }

            // efecto de explosión

            // sfx

            // Destruir
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
