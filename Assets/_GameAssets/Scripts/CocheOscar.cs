using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheOscar : MonoBehaviour {


    [SerializeField] int speed = 20;
    [SerializeField] int speedRotation = 15;
    [SerializeField] float traqueteo = 0.5f;
    int marcha = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        transform.Translate (Vector3.forward * Time.deltaTime * speed * marcha);
        transform.Translate(Vector3.up * Time.deltaTime * traqueteo);

        if (marcha == -1)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speedRotation);
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pared")
        {
            marcha = marcha * -1;
           
        }

        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("HE ENCONTRADO EL OBJETIVO");
            marcha = 0;
            traqueteo = 0;
            
        }

    }
}
