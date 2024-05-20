using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teemo : Character
{//constructor             herencia que recibe de la clase Character
    public Teemo() : base("Teemo", 1000, Resources.Load<Sprite>("Sprites/beemo"))
    {

    }
    public override float Attack()  // Metodo Attack que recibe de Character
    {
        return damage;
    }
    public override float Heal()  // Metodo Heal que recibe de Character
    {
        health += 1000f * damage;
        base.Heal();
        return health;
    }


}
