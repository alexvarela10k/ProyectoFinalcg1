using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManejoCanvas : MonoBehaviour
{
    public Text titulo;
    public GameObject panelmM1;
    public GameObject panelmM2;
    // Start is called before the first frame update
    void Start()
    {
        titulo.text = "KINGDOM";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarEscena1()
    {
        panelmM1.SetActive(false);
        panelmM2.SetActive(true);
    }

    public void CambiarEscena2()
    {
        panelmM1.SetActive(true);
        panelmM2.SetActive(false);
    }
}
