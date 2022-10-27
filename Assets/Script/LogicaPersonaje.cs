using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{

    //Correr
    public int velCorrer;

    //Movimiento
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;

    public float velocidadInicial;
    public float velocidadAgachado;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoDeGolpe = 10f;


    private void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();

        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.8f;
    }

    private void FixedUpdate()
    {
        if(!estoyAtacando)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }
        

        if(avanzoSolo)
        {
            rb.velocity=transform.forward * impulsoDeGolpe;
        }
    }

    // Update is called once per frame
    void Update()
    {

        ///Correr///
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadMovimiento = velCorrer;
            if (y > 0)
            {
                anim.SetBool("correr", true);
            }
            else
            {
                anim.SetBool("correr", false);
            }
        }
        
        ////
        

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        
        if(Input.GetKeyDown(KeyCode.Return)&& puedoSaltar && !estoyAtacando)
        {
            anim.SetTrigger("golpeo");
            estoyAtacando = true;
        }

        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

        if (puedoSaltar)
        {
            if(!estoyAtacando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                anim.SetBool("salte", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
                }
                
                if (Input.GetKey(KeyCode.LeftControl))
                {
                anim.SetBool("agachado", true);
                velocidadMovimiento = velocidadAgachado;
                }
                else
                {
                anim.SetBool("agachado", false);
                velocidadMovimiento = velocidadInicial;
                }
            }
            

            anim.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }        
    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }

    public void DejeDeGolpear()
    {
        estoyAtacando = false;
        
    }

    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejoDeAvanzar()
    {
        avanzoSolo = false;
    }
}
