using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatController : MonoBehaviour
{
    public Interfaz interfaz;
    public float enemyAttack = 0;
    public float playerAttack = 0;
    private Character enemy;
    private GameObject enemyObj;
    private float enemyTime = 6f, playerTime = 3f;
    public KeyCode Attack = KeyCode.Mouse0, Heal = KeyCode.Mouse1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false; // Al comienzo del Script, se deshabilita el script del PlayerMovement
        interfaz = FindObjectOfType<Interfaz>();                   // Busca el componente Interfaz 
        interfaz.ShowName(name);
        interfaz.ShowNameEnemy(enemy);
        StartCoroutine(PlayerTurn());
        StartCoroutine(EnemyTurn());
    }

    private void Update()
    {
        enemyAttack += Time.deltaTime;
        playerAttack += Time.deltaTime;
        interfaz.SliderEnemy(enemyAttack/enemyTime);
        interfaz.SliderPlayer(playerAttack/playerTime);
    }

    IEnumerator PlayerTurn()        // Comienza la corrutina que controla el turno del jugador
    {
        while (true)                
        {

            if (Input.GetKeyDown(Attack))   // Con el click izq o drch, se puede elegir entre atacar y curarse
            {
                float dmgDone = GameManager.instance.character.Attack();//recoge el daño que hace el jugador
                enemy.health -= dmgDone;//el enemigo recibe el daño
                print("Attack con " + dmgDone + " puntos de daño");
                playerAttack = 0;//cuando pulsas el timer se resetea 
                interfaz.ShowDamage(dmgDone);//sale el daño que has hecho en la interfaz
                interfaz.ShowNameEnemy(enemy);//se muestra la vida del enemigo

                if (enemy.health <= 0)
                {
                    print("ENEMIGO MUERTO ABONO PA MI HUERTO");
                    GetComponent<PlayerMovement>().enabled = true;
                    Destroy(enemyObj);
                    Destroy(this);
                }
                yield return new WaitForSeconds(3f);//cooldonw 3 segundos
            }
            else if (Input.GetKeyDown(Heal))//curar
            {
                float healDone = GameManager.instance.character.Heal();//recoge la cura que hace el jugador
                print("Heal con" + healDone + "puntos de vida");
                playerAttack = 0;//cuando pulsas el timer se resetea 
                interfaz.ShowHeal(healDone);//muestras la vida que te curas
                interfaz.ShowName(name);//muestras la vida total que tienes
                yield return new WaitForSeconds(3f);//cooldown 3 segundos
            }
            yield return null;
        }
    }

    IEnumerator EnemyTurn()  // el enemigo hace un random para decidir si ataca o se cura
    {
        while (true)
        {
            if (Random.Range(1, 3) == 1)
            {
                float dmgDone = enemy.Attack();//recoge el daño que hace el enemigo
                GameManager.instance.character.health -= dmgDone;//el jugador recibe el daño
                print("el enemigo ataca con " + dmgDone + " de daño");
                enemyAttack = 0;//el timer se resetea
                if (GameManager.instance.character.health <= 0)
                {
                    SceneManager.LoadScene("Menu");//si mueres te mandan al menú
                }
                interfaz.ShowDamageEnemy(enemy.GetName(), dmgDone);//muestra el daño que hace el enemigo
                interfaz.ShowName(name);//muestra la vida
                yield return new WaitForSeconds(6f);//cooldown 6 segudnos
            }
            else
            {
                float healDone = enemy.Heal();
                interfaz.ShowNameEnemy(enemy);
                print("el enemigo se cura" + healDone + " puntos de vida");
                enemyAttack = 0;
                interfaz.ShowHealEnemy(enemy.GetName(), healDone);
                yield return new WaitForSeconds(6f);
            }
            yield return null;
        }

    }
    public void SetEnemy(Character enemy) // Settea el enemy de EnemySpawn
    {
        this.enemy = enemy;
    }

    public void SetEnemyObj(GameObject enemyObj)
    {
        this.enemyObj = enemyObj;
    }


}
