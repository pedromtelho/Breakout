using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public GameObject vidas;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(vidas.GetComponent<UI_Vidas>().gm.vidas == 3) GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        if (vidas.GetComponent<UI_Vidas>().gm.vidas == 2 && gameObject.tag == "Vida3") GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
        if (vidas.GetComponent<UI_Vidas>().gm.vidas == 1 && gameObject.tag == "Vida2") GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
        if (vidas.GetComponent<UI_Vidas>().gm.vidas == 0 && gameObject.tag == "Vida") GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
    }

}
