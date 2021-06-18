using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    public int PotSalto;
    public int VelMovimiento;
    bool EnPiso = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && EnPiso)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PotSalto));
        }
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(VelMovimiento,
            this.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnPiso = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnPiso = false;
    }
}
