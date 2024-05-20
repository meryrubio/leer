using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character 
{
    public float health = 100;
    private Sprite _sprite;
    private string name;
    protected float damage;
    //protected float JumpForce;

    public Character(string name, float damage, Sprite _sprite)
    {
        this.name = name;
        this.damage = damage;
        this._sprite = _sprite;
    }

    public string GetName() { return name; }
    public float GetDamage() { return damage; }
    public Sprite GetSprite() { return _sprite; }

    //public float GetJumpForce() { return JumpForce; }
    //protected void SetJumpForce(float jF)
    //{
    //    if (jF > 0)
    //        this.JumpForce = jF;
    //}

    public abstract float Attack(); // Metodo abstracto que heredan los objetos

    public virtual float Heal()
    {
        //if(health > 100) 
        //{
        //    return 100;
        //} 
        //else if (health < 0) 
        //{
        //    return 0;
        //}
        //else 
        //{ 
        //    return health;
        //}

        health = Mathf.Clamp(health, 0, 100); // Clamp = te devuelve el valor entre el min y el max
        return health;
    }
    // permite sobrescribir el metodo sin que sea abstracto

    // publicos: son accessibles dentro de la clase, de las clases hijas y de fuera de la clase
    // parametros privados, solo son accesibles dentro de la clase, no fuera de la clase ni en las clases hijas
                            // protected hace que sea accesible dentro de la clase y de las hijas, pero no de fuera de la clase

}
