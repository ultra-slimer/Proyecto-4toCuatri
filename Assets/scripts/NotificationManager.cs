using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class NotificationManager : MonoBehaviour
{
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

        var notification = new AndroidNotification();
        notification.Title = "Hay que Defender tu refugio";
        notification.Text = "Los enemigos no descansan!!";
        notification.SmallIcon = "Icon_reminder_s";
        notification.LargeIcon = "Icon_reminder_l";
        notification.FireTime = DateTime.Now.AddSeconds(15);

        AndroidNotificationCenter.SendNotification(notification, "reminder_notif");
    }
}
