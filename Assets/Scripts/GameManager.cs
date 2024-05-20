using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // La instancia de la clase
    public KeyCode Escape;
    public AudioClip enterClip, exitClip;

    // enum = para facilitar la lectura del codigo 
    private float time;
    //public Human capitan;
    public Character character;
    private string _name;

    private void Awake() // primer metodo que se ejecuta en Unity 
    {
        // Singleton dos caracteristicas: - Solo existe una instancia de esa clase
        //                                - Accesible para todo el mundo
        if (!instance) // Isma entra a la fiesta. Si no hay nadie guapo, él es la persona mas guapa (Si el GM entra en la escena y no hay otra GM, él se vuelve principal)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject); // No se destruye al cambiar de escena
        }
        else // si instance tiene informacion
        { 
            Destroy(gameObject); // se destruye el gameObject, para que no haya dos o mas GM
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        character = new Wizard("def", 20, 2);
        // var input = gameObject.GetComponent<TMP_InputField>();
        //var name = new TMP_InputField.SubmitEvent();
        //name.AddListener(InputName);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Escape))    // Al presionar el boton de Escape te permite volver al menu desde cualquier escena 
        {
            SceneManager.LoadScene("Menu");
            AudioManager.instance.ClearAudios();
        }
        
    }
    // Getter = para obtener el valor de una variable 
    public float GetTime() // obtiene el tiempo
    {
        return time;
    }

    //public void ResetTime() 
    //{ 
    //    time = 0;
    //}

    // callback == funcion que se va a llamar en el on click de los botones 
    public void LoadScene(string SceneName) // Te lleva a la escena que te selecciones como la primera
    {
        Debug.Log("Play!");
        //AudioManager.instance.PlayAudio(enterClip, "enterClip");
        SceneManager.LoadScene(SceneName);
        // Limpia todos los sonidos que estan sonando 
        //AudioManager.instance.ClearAudios();
    }

    public void ExitGame() // Te permite salir del menu del juego 
    {
        Debug.Log("Exit!");
        //AudioManager.instance.PlayAudio(exitClip, "exitClip");
        Application.Quit();
    }

    public void SelectCharacter(int value, string name) //es el dropdown que hace que selecciones personaje
    { 
        if (value == 0)//0 saldria cualquiera
        {
            character = null;
        } 
        else if (value == 1) //sale mago
        {
            character = new Wizard(name, 20, 2);
        }
        if (value == 2) //sale cowboy
        {
            character = new Cowboy(name, 15);
        }
        if (value == 3)//sale Panda
        {
            character = new Diablillo(name);
        }

    }
}
