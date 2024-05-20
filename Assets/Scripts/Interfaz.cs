
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour
{
    public TMP_Text accionpersonaje,accionenemigo,nombrevidapersonaje,nombrevidaenemigo;
    public Slider sliderPlayer, sliderEnemy;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SliderEnemy(float time) // El tiempo de el Slider del enemigo 
    {
        sliderEnemy.value = time;
    }
    public void SliderPlayer(float time) // El tiempo de el Slider del personaje 
    {
        sliderPlayer.value = time;
    }
    public void ShowName(string name) // Muestra el nombre y la vida de el personaje     \n = salto de linea
    {
        nombrevidapersonaje.text = "Name: " + GameManager.instance.character.GetName() + "\n" + "Vida " + GameManager.instance.character.health;
    }

    public void ShowNameEnemy(Character enemy)  // Muestra el nombre y la vida de el enemigo
    {
        nombrevidaenemigo.text = "Name :" + enemy.GetName() + "\n" + "Vida :" + enemy.health;
    }
    public  void ShowDamage(float dmg)  // Muestra el daño que hace el personaje
    {
        accionpersonaje.text = GameManager.instance.character.GetName() + " ha hecho " + dmg.ToString() + " de daño";    
    }

    public void ShowHeal(float heal) // Muestra la curacion que hace el personaje 
    { 
        accionpersonaje.text = GameManager.instance.character.GetName() + " se cura " + heal.ToString() + " puntos de vida";     
    }

    public void ShowDamageEnemy(string name, float dmg) // Muestra el daño que hace el enemigo 
    {     
       accionenemigo.text = name + " hace " + dmg.ToString() + " de daño";     
    }
    public void ShowHealEnemy(string name, float heal)   // Muestra la curacion que realiza el enemigo
    { 
        accionenemigo.text = name + " se cura " + heal.ToString() + " puntos de vida";     
    }
    
}
