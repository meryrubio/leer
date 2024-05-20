using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    private int minNumber = 0;
    private int maxNumber = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())  //si el personakje colisiona los arbustos  y ocurre :(lo de abajo)        
        {

            if (Random.Range(minNumber, maxNumber) == 4) // Si colision con el jugador, hace un random entre el 0 y el 3
            { int spanw = Random.Range(0, 3);
                Character enemy;
                if ( spanw== 0) //si spawn es igual a 0 sale goblin
                {
                    enemy = new Goblin();
                }
                else if(spanw==1)//si es igual a 1 sale sukamon
                {
                    enemy = new Sukamon();
                }
                else//si sale 2 es teemo
                {
                    enemy = new Teemo();//sale teemo
                }

                GameObject enemyObj = Instantiate(enemyPrefab, transform.position, Quaternion.identity); // Tras elegirse el enemigo, se instacia su sprite
                enemyObj.GetComponent<SpriteRenderer>().sprite = enemy.GetSprite();
                CombatController cc = collision.gameObject.AddComponent<CombatController>();  // Se le añade el script CombatController al objeto con el que colisiona (Player)
                cc.SetEnemy(enemy);         // Se settea el enemigo en el combatController
                cc.SetEnemyObj(enemyObj);//setea el prefab del enemigo
            }   
        }
    }
}
