using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    public int PotSalto;
    public AudioClip Salto;
    public ParticleSystem Explosion;
    public ParticleSystem Webito;

    private bool SaltoDoble = false;
    private bool EnPiso = false;
    private AudioSource Sonido;

    // Start is called before the first frame update
    void Start(){
        Sonido = GetComponent<AudioSource>();
        SaltoDoble = false;
        Explosion.Pause();
        Webito.Pause();
        this.GetComponent<JugadorScript>().Webito.transform.position = new Vector3(
             this.GetComponent<JugadorScript>().Webito.transform.position.x,
              this.GetComponent<JugadorScript>().Webito.transform.position.y,
               -13);
    }

    // Update is called once per frame
    void Update(){
        if (this.GetComponent<SpriteRenderer>().enabled != false){
            if (Input.GetKeyDown("space") && SaltoDoble){
                Sonido.PlayOneShot(Salto, 1f);
                SaltoDoble = false;
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PotSalto / 4));
            }
            if (Input.GetKeyDown("space") && EnPiso){
                Sonido.PlayOneShot(Salto, 1f);
                EnPiso = false;
                SaltoDoble = true;
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PotSalto));
            }
            if (Input.GetKeyDown("down") && !EnPiso){
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -PotSalto));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D C1){
        EnPiso = true;
        SaltoDoble = false;
        if (C1.collider.gameObject.CompareTag("Obstacle") && (this.GetComponent<SpriteRenderer>().enabled != false)){
            this.GetComponent<JugadorScript>().Webito.transform.position = new Vector3(
             this.GetComponent<JugadorScript>().Webito.transform.position.x,
              this.GetComponent<JugadorScript>().Webito.transform.position.y,
               -8);
            Explosion.Play();
            Webito.Play();
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.transform.position = new Vector3(this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z);
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnTriggerStay2D(Collider2D collision){
        EnPiso = true;
        SaltoDoble = false;
    }

}
