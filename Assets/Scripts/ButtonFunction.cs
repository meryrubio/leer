using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    public void ExitGame() // Permite presionar el boton de Exit aunque el GM haya sido destruido 
    { 
        GameManager.instance.ExitGame();
    } 
    public void LoadScene(string name)  // Permite presionar el boton de Play aunque el GM sido destruido 
    { 
        GameManager.instance.LoadScene(name);
    }

    public void SelectCharacter() 
    {
        TMP_Dropdown dropdown = FindAnyObjectByType<TMP_Dropdown>();
        TMP_InputField inputField = FindAnyObjectByType< TMP_InputField>();
        GameManager.instance.SelectCharacter(dropdown.value, inputField.text);
    }
}
