using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour {

    [SerializeField] int velocidad = 20;
    [SerializeField] int velocidadRotacion = 15;
    int marcha = 1;
    [SerializeField] int vel = 10;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // TB SE PRODIA HACER CON EL TRANSLATE
        //transform.Translate(Vector3.forward * Time.deltaTime * velocidad); VA MAL PORQUE VA CON EL EJE DEL MUNDO
        // SI GIRAMOS EL COCHE NO VA EL CHOCHE HACIA DELANTE
        //transform.position += Vector3.forward * Time.deltaTime * velocidad * marcha;
        // VA HACIA DELANTE 
       
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad * marcha);

        transform.Translate(Vector3.right * Time.deltaTime * vel );

        // SOLO HAREMOS LA ROTACION CUANDO LA MARCHA SEA -1
        if (marcha == -1)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * velocidadRotacion);
        }
     
	}



    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ha colisionado con la pared");
        Debug.Log("HE COLISIONADO " + collision.gameObject.name);
        // HE COLISIONADO CON LA PARED Y CAMBIO LA MARCHA EN NEGATIVO PARA QUE VAYA HACIA ATRAS
        if (collision.gameObject.tag == "Pared")
        {
            marcha = marcha * -1;
        }

        // SI COLISIONA CON EL TARGET TIENE QUE PARAR EL COCHE
        // ha encontrado el objetivo
        if (collision.gameObject.tag == "Target")
        {
            // o tambien podemos ponermos velocidad = 0
            Debug.Log("BEA HA ENCONTRADO EL OBJETIVO");
            marcha = 0;
            
        }
    }
}
