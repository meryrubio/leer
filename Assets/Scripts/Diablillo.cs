using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diablillo : Character
{    //constructor                                                  herencia que recibe de la clase Character
    public Diablillo(string name) : base(name, 1000, Resources.Load<Sprite>("Sprites/panda"))
    {

    }
    public override float Attack() // Metodo Attack que  recibe de Character
    {
       
        int spanw = Random.Range(0, 3);
        if (spanw != 0)
        {
            return damage;
        }
        else { SceneManager.LoadScene("Menu");return damage; }//carga la escena del menu debido a que hay un rango entre 0 y 3 para que suicididarse

    }
   
    public override float Heal()    // Metodo Heal que recibe de Character
    {
        health += 10;
        base.Heal();
        return 10;
    }

}
