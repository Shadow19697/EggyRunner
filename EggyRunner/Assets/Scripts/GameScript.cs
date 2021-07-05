using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public GameObject Player;
    public Text GameText;
    public Text Puntaje;
    public AudioSource Music;
    public ParticleSystem Fondo;
    public Text HighScore;
    
    public bool Fin;
    public bool Comienzo = true;
    public float Contador;
    
    // Start is called before the first frame update
    void Start()
    {
        Fin = false;
        Fondo.Play();
        Music.Pause();
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update() {
        if (Player.GetComponent<SpriteRenderer>().enabled != false){ //-------------------------------Con webo
            if (Comienzo){ //----------------------Inicio
                GameText.text = "Press Space to start\nPress Esc to exit";
                if (Input.GetKeyDown("space")){
                    Comienzo = false;
                    GameText.text = "";
                    Music.Play();
                }
                if (Input.GetKeyDown(KeyCode.Escape)){
                    Application.Quit();
                }
                //if (Input.GetKeyDown("q"))
                //{
                //    PlayerPrefs.DeleteAll();
                //}
            } else{ // ---------------------------Jugando
                Contador += Time.deltaTime * 8;
                Puntaje.text = "Score: " + (int)Contador;
                if ((int)Contador > PlayerPrefs.GetInt("HighScore",0)){
                    PlayerPrefs.SetInt("HighScore", (int)Contador);
                    HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
                }
            }
        } else{ //-----------------------------------------------------------------------------------Sin webo
            if (!Fin){
                Music.Stop();
                Fin = true;
                GameText.text = "Game Over\nPress R to restart\nPress Escape to exit";
                Fondo.Stop();
            }
            if (Fin){
                if (Input.GetKeyDown("r")){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                if (Input.GetKeyDown(KeyCode.Escape)){
                    Application.Quit();
                }
            }
        }
    }
}
