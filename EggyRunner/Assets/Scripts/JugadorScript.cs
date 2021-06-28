using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    public int PotSalto;
    public float VelMovimiento;
    bool EnPiso = false;
    private AudioSource Sonido;
    public AudioClip Salto;
    public float SegIncremento;
    float TiempoActual;


    // Start is called before the first frame update
    void Start(){
        Sonido = GetComponent<AudioSource>();
        TiempoActual = SegIncremento * 300;
    }

    // Update is called once per frame
    void Update(){
        TiempoActual -= 1f;
        if (Input.GetKeyDown("space") && EnPiso){
            Sonido.PlayOneShot(Salto, 1f);
            EnPiso = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PotSalto));
        }
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(VelMovimiento,
            this.GetComponent<Rigidbody2D>().velocity.y);
        if(TiempoActual < 0){
            VelMovimiento += 1;
            TiempoActual = SegIncremento * 300;
        }
    }

    private void OnCollisionEnter2D(Collision2D C1){
        EnPiso = true;
        if (C1.collider.gameObject.tag == "Obstacle"){
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D C1){
        EnPiso = true;
        if (C1.gameObject.tag == "Obstacle"){
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision){
        EnPiso = true;
    }

}
