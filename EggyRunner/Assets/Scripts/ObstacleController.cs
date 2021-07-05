using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject Juego;
    public GameObject[] Obstaculos;

    private int Contador;
    private bool Vel1;
    private bool Vel2;
    private bool Vel3;
    private bool Vel4;
    private int Velocidad;
    private int Indice;
    private bool Arranca;

    // Start is called before the first frame update
    void Start()
    {
        Vel1 = true;
        Vel2 = true;
        Vel3 = true;
        Vel4 = true;
        Velocidad = 0;
        Arranca = true;
        Indice = 0;
    }

    // Update is called once per frame
    void Update(){
        Contador = (int)Juego.GetComponent<GameScript>().Contador;
        if (!Juego.GetComponent<GameScript>().Comienzo){
            if (Obstaculos[Indice].GetComponent<ObstacleScript>().Molino || Arranca){
                do{
                    Indice = Random.Range(0, 3);
                    Arranca = false;
                } while (!Obstaculos[Indice].GetComponent<ObstacleScript>().Disponible);
            }
            Obstaculos[Indice].GetComponent<ObstacleScript>().Velocidad = 0;
            if (Contador % Random.Range(8, 50) == 0){
                Obstaculos[Indice].GetComponent<ObstacleScript>().Velocidad = Velocidad;
            }
            if (Contador == 0){
                Velocidad = 11;
            }
            if (Contador == 100 && Vel1){
                Velocidad += 1;
                Vel1 = false;
            }
            if (Contador == 200 && Vel2){
                Velocidad += 1;
                Vel2 = false;
            }
            if (Contador == 300 && Vel3){
                Velocidad += 2;
                Vel3 = false;
            }
            if (Contador == 400 && Vel4){
                Velocidad += 1;
                Vel4 = false;
            }
            if ((Contador % 75 == 0) && Contador != 0  && (Obstaculos[3].GetComponent<ObstacleScript>().Disponible))
            {
                Obstaculos[3].GetComponent<ObstacleScript>().Velocidad = (Velocidad * 2) - 4;
            }
        }
        if (Juego.GetComponent<GameScript>().Fin){
            Velocidad = 0;
            Obstaculos[Indice].GetComponent<ObstacleScript>().Velocidad = Velocidad;
        }
    }
}
