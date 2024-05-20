using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : Character
{
                        //constructor                 herencia que recibe de la clase Character
    public Cowboy(string name, float damage) : base(name, damage, Resources.Load<Sprite>("Sprites/cowboy")) // construimos padre
    {

    }

    public override float Attack()  // Metodo Attack que recibe de Character 
    {
        //if (hasHat) 
        //{ 
        //    return damage * 2;
        //}
        //else 
        //{
        //    return damage;
        //}
        //     la misma operacion pero de una manera reducida

        //Debug.Log("Cowboy ataca");
        return Random.Range(damage, damage * 1.5f);
    }

    public override float Heal()  // Metodo Heal que recibe de Character
    {
        //Debug.Log("Cowboy se cura");
        health += 10;
        base.Heal();
        return 10;
    }
}
