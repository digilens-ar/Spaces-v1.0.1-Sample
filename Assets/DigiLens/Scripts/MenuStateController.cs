using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuStateController : MonoBehaviour
{

    [SerializeField]
    GameObject page1, page2, page3, next, prev;

    [SerializeField]
    GameObject voiceObj;

    [SerializeField]
    GameObject handMenu, scrollMenu, voiceMenu;

    [SerializeField]
    Text txtBtnTitle;

    Button btn1, btn2, btn3, prevBtn, nextBtn;

    /// <summary>
    /// States:
    /// 1 - page 1
    /// 2 - page 2
    /// 3 - page 3
    /// </summary>
    int currentState;
    int prevState;


    /// <summary>
    /// Initialize state and variables
    /// </summary>
    void Start()
    {
        prevState = 1;
        currentState = 1;
        InitVariables();
    }

    /// <summary>
    /// Initializes buttons
    /// </summary>
    void InitVariables()
    {
        btn1 = page1.GetComponent<Button>();
        btn2 = page2.GetComponent<Button>();
        btn3 = page3.GetComponent<Button>();
        nextBtn = next.GetComponent<Button>();
        prevBtn = prev.GetComponent<Button>();

    }

    /// <summary>
    /// Sets state to previous state
    /// </summary>
    public void OnPrevClick()
    {

        if (currentState > 1) //only decrease state if larger than 1, otherwise do nothing
        {
            currentState--;
            UpdateState(currentState);
        }

    }

    /// <summary>
    /// Sets state to the next state
    /// </summary>
    public void OnNextClick()
    {

        if (currentState < 3) //only increase state if current state is less than 3, otherwise do nothing
        {
            currentState++;
            UpdateState(currentState);
        }


    }

    /// <summary>
    /// Button 1 click event. Sets state to 1 and activates corresponding menus and objects
    /// </summary>
    public void OnBtn1Click()
    {
        currentState = 1;
        UpdateState(currentState);
    }

    /// <summary>
    /// Button 2 click event. Sets state to 2 and activates corresponding menus and objects
    /// </summary>
    public void OnBtn2Click()
    {
        currentState = 2;
        UpdateState(currentState);
    }

    /// <summary>
    /// Button 3 click event. Sets state to 3 and activates corresponding menus and objects
    /// </summary>
    public void OnBtn3Click()
    {
        currentState = 3;
        UpdateState(currentState);
    }

    /// <summary>
    /// Activates handtracking menu and visually indicates page 1 is active
    /// </summary>
    void ActivateHandMenu()
    {
        handMenu.SetActive(true);
        ResetSelectedColor(btn1, true);
        ResetSelectedColor(prevBtn, true);
        prevBtn.interactable = false;
        btn1.interactable = false;
        Debug.Log("Hand menu activated");
    }

    /// <summary>
    /// Deactivates handtracking menu and resets visuals
    /// </summary>
    void DeactivateHandMenu()
    {
        if (!handMenu.activeInHierarchy) //if already deactivated, skip
        {
            return;
        }

        handMenu.SetActive(false);
        ResetSelectedColor(btn1, false);
        ResetSelectedColor(prevBtn, false);
        prevBtn.interactable = true;
        btn1.interactable = true;
    }

    /// <summary>
    /// Activates scroll menu and visually indicates page 2 is active
    /// </summary>
    void ActivateScrollMenu()
    {
        scrollMenu.SetActive(true);
        ResetSelectedColor(btn2, true);
        btn2.interactable = false;

        Debug.Log("scroll menu activated");
    }

    /// <summary>
    /// Deactivates scroll menu and resets visuals
    /// </summary>
    void DeactivateScrollMenu()
    {
        if (!scrollMenu.activeInHierarchy)//if already deactivated, skip
        {
            return;
        }

        scrollMenu.SetActive(false);
        ResetSelectedColor(btn2, false);
        btn2.interactable = true;

    }

    /// <summary>
    /// Activates voice menu and visually indicates page 3 is active
    /// </summary>
    void ActivateVoiceMenu()
    {
        voiceMenu.SetActive(true);
        voiceObj.SetActive(true);
        ResetSelectedColor(btn3, true);
        ResetSelectedColor(nextBtn, true);
        nextBtn.interactable = false;
        btn3.interactable = false;

        Debug.Log("activated voice menu");
    }

    /// <summary>
    /// Deactivates voice menu and resets visuals
    /// </summary>
    void DeactivateVoiceMenu()
    {
        if (!voiceMenu.activeInHierarchy)//if already deactivated, skip
        {
            return;
        }

        voiceMenu.SetActive(false);
        ResetSelectedColor(btn3, false);
        ResetSelectedColor(nextBtn, false);
        nextBtn.interactable = true;
        btn3.interactable = true;
        voiceObj.SetActive(false);

    }

    /// <summary>
    /// Updates the state behaviors
    /// </summary>
    void UpdateState(int state)
    {
        if (state == prevState) //If no change, do nothing
        {
            Debug.Log("no change");
            return;
        }

        switch (state)
        {
            case 1:
                Debug.Log("case1");
                DeactivateScrollMenu();
                DeactivateVoiceMenu();
                ActivateHandMenu();
                txtBtnTitle.text = "MRTK Hand Tracking";

                break;
            case 2:
                Debug.Log("case2");
                DeactivateHandMenu();
                DeactivateVoiceMenu();
                ActivateScrollMenu();
                txtBtnTitle.text = "Scroll Wheel Demo";

                break;
            case 3:
                Debug.Log("case3");
                DeactivateHandMenu();
                DeactivateScrollMenu();
                ActivateVoiceMenu();
                txtBtnTitle.text = "Voice UI Demo";
                break;
            default:
                break;
        }

        Debug.Log("Page number " + state);
        prevState = currentState;
    }

    /// <summary>
    /// Changes button color to either interactable or non interactable
    /// </summary>
    /// <param name="btn"></param>
    /// <param name="interactable"></param>
    void ResetSelectedColor(Button btn, bool selected)
    {
        ///GameObject selectedBtn, defaultBtn;
        if (btn.interactable == selected)
        {
            btn.interactable = !selected;
        }

    }

}
