using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }


    AndroidNotificationChannel notifChannel;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        AndroidNotificationCenter.CancelAllScheduledNotifications();


        var notifChannel = new AndroidNotificationChannel()
        {
            Id = "reminder_notif",
            Name = "Reminder Notification",
            Description = "Channel for Reminders Notifications",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notifChannel);

        /*
        var notification = new AndroidNotification();
        notification.Title = "Hay que Defender tu refugio";
        notification.Text = "Los enemigos no descansan!!";
        notification.SmallIcon = "Icon_reminder_s";
        notification.LargeIcon = "Icon_reminder_l";
        notification.FireTime = System.DateTime.Now.AddSeconds(10);
        */



        DisplayNotif("Hay que defender tu refugio", "Los enemigos no descansan!!", DateTime.Now.AddHours(10));
    }

    public int DisplayNotif(string title, string text, DateTime fireTime)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.SmallIcon = "Icon_reminder_s";
        notification.LargeIcon = "Icon_reminder_l";
        notification.FireTime = fireTime;

        return AndroidNotificationCenter.SendNotification(notification, notifChannel.Id);
    }

    public void CancelNotif(int id)
    {
        AndroidNotificationCenter.CancelScheduledNotification(id);
    }
}
