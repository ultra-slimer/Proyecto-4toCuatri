using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTutorial : MonoBehaviour
{
    public List<GameplayTutorialMessage> tutorialMessage = new List<GameplayTutorialMessage>();
    public GameplayTutorialMessage current;
    public Text notifMessage;
    private int currentScreen = 0;
    public Canvas HUD;
    // Start is called before the first frame update
    void Start()
    {
        current = tutorialMessage[currentScreen];
        showScreenPreparations();
        currentScreen = 0;
        current.ON();
    }
    //las acciones de los botones de la siguiente escena se configuran en este switch
    //activa interactabilidad en canvas en on y desactivar en off
    // el off del message deberia llamar al ON de nextMessage
    void showScreenPreparations()
    {
        for(int i = 0; i < tutorialMessage.Count; i++)
        {
            switch (i)
            {
                case 0:
                    current.ON += delegate {
                        Time.timeScale = 0;
                    };
                    break;
                case 1:
                    current.ON += delegate
                    {
                        HUD.sortingOrder = 1;
                    };
                    current.OFF += delegate
                    {
                        HUD.sortingOrder = -1;
                    };
                    break;
                default:
                    break;
            }
        }
    }

    public void SwitchMessage()
    {
        tutorialMessage[currentScreen].OFF();
        tutorialMessage[currentScreen++].ON();
        current = tutorialMessage[currentScreen];
    }
    public void SwitchMessageSpecific(int desiredScreen)
    {
        tutorialMessage[currentScreen].OFF();
        tutorialMessage[desiredScreen].ON();
        current = tutorialMessage[desiredScreen];
        currentScreen = desiredScreen;
    }
}
