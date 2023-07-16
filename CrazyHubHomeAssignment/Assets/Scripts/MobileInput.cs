using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput instance;   // Diger Script'ler uzrerinden erisimi saglar

    [Header("Controllers")]
    public bool tap;
    public bool hold;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        // Butun boollari sifirliyoruz
        tap = hold =  false; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
        }

        if (Input.GetMouseButton(0))
        {   // Mosue tusuna basili tutuldugunda veya ekranda parmak ile basili tutularak gidildigindeki son pozisyonun degerini al?r
            hold = true;   // Kaydirma aktif olur
        }

        if (Input.GetMouseButtonUp(0))
        {   // Mosue tusuna basma birakildiginda veya ekranda parmak basma birakildiginda
            tap = false;
            hold = false;
        }
        
    }

}