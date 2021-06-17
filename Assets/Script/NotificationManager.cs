using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    // // Start is called before the first frame update
    // private double shortDelay = 10; // 10s
    // private double longDelay = 60;  // 60s
    // void Start()
    // {
    //     SendNotification_func( null ,shortDelay , "is my FKing game" , "is 10s send");
    //     SendNotification_func( "29/04/2021 21:39" ,longDelay , "Yea!!!" , "is 1min send");
    // }

    // public void SendNotification_func(string date_ , double send_Timer = 0.0f , string title_ = "Test Notification" , string text_ = "Hello World" ){

    //     var c = new AndroidNotificationChannel() {
    //         Id = "channel_id",
    //         Name = "Default Channel",
    //         Importance = Importance.High,
    //         Description = "Generic notifications"
    //     };
    //     AndroidNotificationCenter.RegisterNotificationChannel(c);

    //     var notification = new AndroidNotification();
    //         notification.Title = title_;
    //         notification.Text = text_;
    //     if(date_ !=null){
    //         // notification.FireTime = System.DateTime.TryParseExact( date_ ) ; // "MM/dd/yyyy HH:mm" =  01/02/2077 21:39
                    
    //     }else{
    //         notification.FireTime = System.DateTime.Now.AddSeconds(send_Timer);
    //     }
        
    //     AndroidNotificationCenter.SendNotification(notification, "channel_id");
    // }

}
