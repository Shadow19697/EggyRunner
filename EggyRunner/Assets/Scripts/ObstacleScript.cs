using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public int Velocidad;
    public int PosX;
    public int PosY;
    public bool Disponible;
    public bool Molino;

    // Start is called before the first frame update
    void Start(){
        this.transform.position = new Vector3(PosX, PosY, 0);
        this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Disponible = true;
        Molino = false;
    }

    // Update is called once per frame
    void Update(){
        if (Velocidad != 0){
            this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-Velocidad,
                    this.GetComponent<Rigidbody2D>().velocity.y);
            Disponible = false;
        }
        int aux = Random.Range(-2, 10);
        if ((int)this.transform.position.x < aux){
            Molino = true;
        }

        if ((int)this.transform.position.x == -4){
            this.transform.position = new Vector3(PosX,
                PosY,
                this.transform.position.z);
            Velocidad = 0;
            this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-Velocidad,
                    this.GetComponent<Rigidbody2D>().velocity.y);
            Disponible = true;
            Molino = false;
        }
    }
}
