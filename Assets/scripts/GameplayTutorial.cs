using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTutorial : MonoBehaviour
{
    public List<GameplayTutorialMessage> tutorialMessage = new List<GameplayTutorialMessage>();
    public GameplayTutorialMessage current;
    public Text notifMessage;
    private ScreenManager screenManager;
    private int currentScreen = 0;
    public Canvas HUD;
    // Start is called before the first frame update
    void Start()
    {
        screenManager = ScreenManager.instance;
        current = tutorialMessage[currentScreen];
        current.ON = delegate {
            Time.timeScale = 0;
            
        };
        current.ON();
    }
    //las acciones de los botones de la siguiente escena se configuran en este switch
    //activa interactabilidad en canvas en on y desactivar en off
    // el off del message deberia llamar al ON de nextMessage
    void showScreenPreparations(int screen)
    {
        var current = tutorialMessage[screen];
        if (screen < tutorialMessage.Count)
        {
            var next = tutorialMessage[screen + 1];
        }
        switch (screen)
        {
            case 0:
                Time.timeScale = 0;
                break;
            default:
                break;
        }
    }
}
