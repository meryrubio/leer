using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Character
{
       //constructor        herencia que recibe de la clase Character
    public Goblin() : base("Goblin", 10, Resources.Load<Sprite>("Sprites/goblin")) 
    {
    }
    public override float Attack()      // Metodo Attack que recibe de Character
    {
        if(health <= 20)    
        {
            damage *= 3;
        }
        return damage;
    }

    public override float Heal()        // Metodo Heal que recibe de Character 
    {
        health += damage * 0.5f;
        base.Heal();
        return health;
    }
}
