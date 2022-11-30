using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class StaminaSystem : MonoBehaviour
{
    [SerializeField]
    public static StaminaSystem instance;

    public ScreenMessage pressResponseMessage;

    [SerializeField] public int maxStamina = 10;
    [SerializeField] float timeToRecharge = 10f;
    public static int staminaAmmount;
    bool restoring;

  
    public static bool HaveStamina { get => staminaAmmount > 0; }

    DateTime nextStaminaTime;
    DateTime lastStaminaTime;

    [SerializeField] TextMeshProUGUI staminaText = null;
    [SerializeField] TextMeshProUGUI timerText = null;
    [SerializeField] TextMeshProUGUI fullTimeText = null;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("currentStamina"))
            PlayerPrefs.SetInt("currentStamina", maxStamina);

        LoadTime();
        StartCoroutine(RestoreEnergy());
    }

    IEnumerator RestoreEnergy()
    {
        UpdateStamina();
        restoring = true;
        while (staminaAmmount < maxStamina)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = nextStaminaTime;
            bool staminaAdd = false;

            while (currentDateTime > nextDateTime)
            {
                if (staminaAmmount < maxStamina)
                {
                    staminaAmmount += 1;
                    staminaAdd = true;
                    UpdateStamina();
                    DateTime timeToAdd = DateTime.Now;
                    if (lastStaminaTime > nextDateTime)
                        timeToAdd = lastStaminaTime;
                    else
                        timeToAdd = nextDateTime;

                    nextDateTime = AddDuration(timeToAdd, timeToRecharge);
                }
                else
                {
                    break;
                }
            }

            if (staminaAdd)
            {
                lastStaminaTime = DateTime.Now;
                nextStaminaTime = nextDateTime;
            }

            UpdateTimer();
            UpdateStamina();
            SaveTime();
            yield return new WaitForEndOfFrame();
        }

        restoring = false;
    }

    DateTime AddDuration(DateTime date, float duration)
    {
        return date.AddSeconds(duration);
    }

    public void UseEnergy(int energyAmmount)
    {
        if (staminaAmmount - energyAmmount >= 0)
        {
            staminaAmmount -= energyAmmount;
            UpdateStamina();

            if (!restoring)
            {
                nextStaminaTime = AddDuration(DateTime.Now, timeToRecharge);
                StartCoroutine(RestoreEnergy());
            }
        }
        else
        {
            FullRecharge();
            Debug.Log("No tenés stamina!!!!");
        }
    }

    public void UpdateStamina()
    {
        staminaText.text = staminaAmmount.ToString() + " / " + maxStamina.ToString();
    }

    public void UpdateTimer()
    {
        if (staminaAmmount >= maxStamina)
        {
            timerText.text = "";
            fullTimeText.text = "Stamina Full!";
            return;
        }

        fullTimeText.text = "Timer:";
        TimeSpan timer = nextStaminaTime - DateTime.Now;

        timerText.text = timer.Minutes.ToString() + ":" + timer.Seconds.ToString();
    }

    void LoadTime()
    {
        staminaAmmount = PlayerPrefs.GetInt("currentStamina");
        nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("nextStaminaTime"));
        lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("lastStaminaTime"));
    }

    void SaveTime()
    {
        PlayerPrefs.SetInt("currentStamina", staminaAmmount);
        PlayerPrefs.SetString("nextStaminaTime", nextStaminaTime.ToString());
        PlayerPrefs.SetString("lastStaminaTime", lastStaminaTime.ToString());
    }

    DateTime StringToDateTime(string timeString)
    {
        if (string.IsNullOrEmpty(timeString))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(timeString);
        }
    }

    public void FullRecharge()
    {

        if (!HaveStamina)
        {
            if (pressResponseMessage.GetComponent<Confirmation>())
            {
                var a = pressResponseMessage.GetComponent<Confirmation>();
                a.Yes = delegate { if (15  <= GemManager._Gems) { GemManager.AddGems(-15); AudioManager.Instance().Play("Positive"); staminaAmmount = maxStamina; UpdateStamina(); UpdateTimer(); ScreenManager.instance.CloseAll();} else { pressResponseMessage.nextScreen.GetComponent<ErrorMessage>().errorMessageText = "Insufficient Gems"; ScreenManager.instance.Push(pressResponseMessage.nextScreen); AudioManager.Instance().Play("Negative"); } GameManager.Trigger("SaveRemotely"); /*Store.instance.ReloadGems();*/ };
                a.No = delegate { AudioManager.Instance().Play("Neutral"); ScreenManager.instance.Pop(); };
            }
            AudioManager.Instance().Play("Neutral");
            ScreenManager.instance.Push(pressResponseMessage);
            //staminaAmmount = maxStamina;
        }
       /*
        if (pressResponseMessage.GetComponent<Confirmation>())
            {
                var a = pressResponseMessage.GetComponent<Confirmation>();
                a.Yes = delegate { if (StoreObject.Instance.price <= GemManager._Gems) { GemManager.AddGems(-StoreObject.Instance.price); AudioManager.Instance().Play("Positive"); Store.Buy(StoreObject.Instance.purchaseID); ScreenManager.instance.CloseAll(); staminaAmmount = maxStamina; } else { pressResponseMessage.nextScreen.GetComponent<ErrorMessage>().errorMessageText = "Insufficient Gems"; ScreenManager.instance.Push(pressResponseMessage.nextScreen); AudioManager.Instance().Play("Negative"); } GameManager.Trigger("SaveRemotely"); Store.instance.ReloadGems(); };
                a.No = delegate { AudioManager.Instance().Play("Neutral"); ScreenManager.instance.Pop(); };
            }
            AudioManager.Instance().Play("Neutral");
            ScreenManager.instance.Push(pressResponseMessage);
            //staminaAmmount = maxStamina;
            */
  
       
    }
}
