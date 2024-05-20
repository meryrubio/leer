using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sukamon : Character
{
       //constructor        herencia que recibe de la clase Character
    public Sukamon() : base("Sukamon", 1, Resources.Load<Sprite>("Sprites/sukamon"))
    {
    }

    public override float Attack()  // Metodo Attack que recibe de Character
    {
        if(health <= 5) 
        {
            damage = 100f;
        }
        return damage;
    }

    public override float Heal()  // Metodo Heal que recibe de Character
    {
        health += 0.3f * damage;//se cura 0,3 por el daño o un tercio de su daño
        base.Heal();
        return health;
    }
}
