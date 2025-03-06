using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private List<GameObject> ElPool; // donde guardo los objetos
    [SerializeField] private int numeroObjetos; // cuantos voy a crear
    [SerializeField] private GameObject prefabOriginal;

    void Awake()
    {
        ElPool = new List<GameObject>(); // inicializamos la lista
    }

    private void CrearObjetos()
    {
        for(int i = 0; i < numeroObjetos; i++)
        {
            // creo la copia
            GameObject copia = Instantiate(prefabOriginal);
            // lo agrego al pool
            ElPool.Add(copia);
            // lo desactivamos
            copia.SetActive(false);
        }
    }

    void Start()
    {
        CrearObjetos();
    }

    public GameObject GetObjeto()
    {
        // revisamos la lista
        foreach(GameObject objeto in ElPool)
        {
            // revisar si está inactivo
            if( ! objeto.activeInHierarchy)
            {
                // lo activo
                objeto.SetActive(true);
                // se lo regreso a quien lo pida
                return objeto;
            }
        }
        // si llega a salir del foreach, quiere decir que ya no hay objetos
        return null;
    }

}
