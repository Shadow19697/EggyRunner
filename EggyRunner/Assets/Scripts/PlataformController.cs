using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformController : MonoBehaviour
{
    public GameObject Piso1;
    public GameObject Piso2;
    public GameObject Juego;

    private int Contador;
    private bool Vel1;
    private bool Vel2;
    private bool Vel3;
    private bool Vel4;


    // Start is called before the first frame update
    void Start(){
        Piso1.GetComponent<PlataformScript>().Velocidad = 8;
        Piso2.GetComponent<PlataformScript>().Velocidad = 8;
        Vel1 = true;
        Vel2 = true;
        Vel3 = true;
        Vel4 = true;
    }

    // Update is called once per frame
    void Update(){
        Contador = (int)Juego.GetComponent<GameScript>().Contador;
        if(!Juego.GetComponent<GameScript>().Fin){
            if (Contador == 50 && Vel1)
            {
                Piso1.GetComponent<PlataformScript>().Velocidad += 2;
                Piso2.GetComponent<PlataformScript>().Velocidad += 2;
                Vel1 = false;
            }
            if (Contador == 100 && Vel2)
            {
                Piso1.GetComponent<PlataformScript>().Velocidad += 2;
                Piso2.GetComponent<PlataformScript>().Velocidad += 2;
                Vel2 = false;
            }
            if (Contador == 150 && Vel3)
            {
                Piso1.GetComponent<PlataformScript>().Velocidad += 2;
                Piso2.GetComponent<PlataformScript>().Velocidad += 2;
                Vel3 = false;
            }
            if (Contador == 200 && Vel4)
            {
                Piso1.GetComponent<PlataformScript>().Velocidad += 2;
                Piso2.GetComponent<PlataformScript>().Velocidad += 2;
                Vel4 = false;
            }
        }
        else{
            Piso1.GetComponent<PlataformScript>().Velocidad = 0;
            Piso2.GetComponent<PlataformScript>().Velocidad = 0;
        }
    }
}
