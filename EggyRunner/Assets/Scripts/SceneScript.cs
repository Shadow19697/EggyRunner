using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public GameObject Player;
    public Camera InGameCamera;
    public GameObject[] PrefabBlock;
    public float GamePointer;
    public float GenerationSpot=12;
    public Text GameText;
    public Text Puntaje;
    public bool Lose;
    public AudioSource Music;
    public ParticleSystem Fondo;
    public ParticleSystem Explosion;
    public ParticleSystem Webito;

    private AudioSource Sound;
    private bool Comienzo = true;
    private float Contador;
    

    // Start is called before the first frame update
    void Start()
    {
        GamePointer = -5;
        Lose = false;
        Fondo.Pause();
        Music.Pause();
        Explosion.Pause();
        Webito.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null){
            InGameCamera.transform.position = new Vector3(
                Player.transform.position.x,
                InGameCamera.transform.position.y,
                InGameCamera.transform.position.z);
            if (Comienzo){
                GameText.text = "Press Space to start\nPress Esc to exit";
                if (Input.GetKeyDown("space")){
                    Comienzo=false;
                    GameText.text = "";
                    Fondo.Play();
                    Music.Play();
                }
                if (Input.GetKeyDown(KeyCode.Escape)){
                    Application.Quit();
                }
            }
            else{
                Contador += Time.deltaTime*8;
                Puntaje.text = "Score: " + (int)Contador;
            }
        }
        else{
            if (!Lose){
                Music.Stop();
                Lose = true;
                GameText.text = "Game Over\nPress R to restart\nPress Escape to exit";
                Fondo.Stop();
            }
            if (Lose){
                Explosion.Play();
                Webito.Play();
                if (Input.GetKeyDown("r")){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                if (Input.GetKeyDown(KeyCode.Escape)){
                    Application.Quit();
                }
            }
        }

        while((Player!=null) && GamePointer<(Player.transform.position.x + GenerationSpot)){
            int BlockIndex = Random.Range(0, PrefabBlock.Length - 1);
            if(Comienzo){
                BlockIndex = 4;
            }

            GameObject ObjetoBloque = Instantiate(PrefabBlock[BlockIndex]);
            ObjetoBloque.transform.SetParent(this.transform);
            BlockScript Block = ObjetoBloque.GetComponent<BlockScript>();
            ObjetoBloque.transform.position = new Vector2(
                GamePointer + Block.Size / 2,
                0);
            GamePointer += Block.Size;
        }
    }
}
