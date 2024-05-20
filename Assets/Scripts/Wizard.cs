using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character
{
    private float damageMultiplier;
    //private float currentTime = 0f, MaxTime = 4f;

    //constructor                                                  herencia que recibe de la clase Character
    public Wizard(string name, float damage, float damageMultiplier) : base(name, damage, Resources.Load<Sprite>("Sprites/wizard"))
    {
        this.damageMultiplier = damageMultiplier;
    }

    public override float Attack()  // Metodo Attack que recibe de Character 
    {
        //Debug.Log("Wizard ataca");
        //return HasHat ? damage * 2 : damage;
        return damage * damageMultiplier;
    }

    public override float Heal()    // Metodo Heal que recibe de Character
    {
        //Debug.Log("Wizard se cura");
        float healing = Random.Range(damage, damage * damageMultiplier);//se cura un random entre el daño que hace y el daño por el multiplicadpor(entre 20 y 40)
        health += healing;
        base.Heal();//llama al metodo heal que hereda de character
        return healing;//devuelve heal
    }

}
