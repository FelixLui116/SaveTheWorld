using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class ShootingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
 [Serializable]
    public struct Interval
    {
        public float lower;
        public float upper;
    }

    [Serializable]
    public struct HoldTimeSetting
    {
        public float HoldTime;
        public Interval intervalsToDo;  //default --- lower = 1f, upper = 1.5f
    }

    [SerializeField] private float PressDownTimer; //按下幾秒觸發

    [SerializeField] private HoldTimeSetting DoTimeSetting;

    private bool PressDown; //是否按下
    
    public bool PressDown_GET
    {
        get => PressDown;
        set => PressDown = value;
    }


    //開啟Inspector觸發事件
    //長按後，觸發執行的功能
    public UnityAction OnLongClick { get; set; }

    //短按後，觸發執行的功能
    public UnityAction OnShortClick { get; set; }

    public UnityAction Action_Interval { get; set; }

    public UnityAction Action_End { get; set; }

    //按下按鈕
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("PressDown");
        PressDown = true;
    }

    //按鈕彈起
    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("PressUp");
        if (PressDownTimer > 0 && PressDownTimer < DoTimeSetting.HoldTime)
        {
            OnShortClick?.Invoke();
            Action_End?.Invoke();
        }
        Reset();
    }

    //當按下按鈕 PressDown = true 時計時
    void Update()
    {
        if (!PressDown) return;
        PressDownTimer += Time.deltaTime;

        // if (IsInterval()) 
        //     Action_Interval?.Invoke();
            
        // if (PressDownTimer >= DoTimeSetting.HoldTime)
        // {
        //     OnLongClick?.Invoke();
        //     Action_End?.Invoke();
        //     Reset();
        //     PressDownTimer += Time.deltaTime;
        // }
    }

    //當PressUp的時候重製計算時間
    private void Reset()
    {
        PressDown = false;
        PressDownTimer = 0;
    }

    //檢查是否符合間隙時間
    private bool IsInterval() {
        //default --- lower = 1f, upper = 1.5f
        return PressDownTimer > DoTimeSetting.intervalsToDo.lower && PressDownTimer < DoTimeSetting.intervalsToDo.upper;
    }
}
