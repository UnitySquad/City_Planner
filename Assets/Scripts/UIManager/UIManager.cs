using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{

    public Transform build_panel;
    public Transform road_panel;
    public Transform shop_panel;
    public Transform production_panel;

    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void panelBarOnOff()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if(clickObject.name == "BuildingButton")
        {
            if(!isOn)
            {
                build_panel.localPosition = new Vector2(0, -Screen.height);
                build_panel.LeanMoveLocalY(-360, 0.5f).setEaseOutExpo().delay = 0.1f;
                isOn = true;
            }
            else
            {
                build_panel.LeanMoveLocalY(-590, 0.5f).setEaseInExpo();
                isOn = false;
            }
            
            
        }
        else if(clickObject.name == "RoadButton")
        {
            if (!isOn)
            {
                road_panel.localPosition = new Vector2(0, -Screen.height);
                road_panel.LeanMoveLocalY(-360, 0.5f).setEaseOutExpo().delay = 0.1f;
                isOn = true;
            }
            else
            {
                road_panel.LeanMoveLocalY(-590, 0.5f).setEaseInExpo();
                isOn = false;
            }
        }
        else if(clickObject.name == "ShopButton")
        {
            if (!isOn)
            {
                shop_panel.localPosition = new Vector2(0, -Screen.height);
                shop_panel.LeanMoveLocalY(-360, 0.5f).setEaseOutExpo().delay = 0.1f;
                isOn = true;
            }
            else
            {
                shop_panel.LeanMoveLocalY(-590, 0.5f).setEaseInExpo();
                isOn = false;
            }
        }
        else if(clickObject.name == "ProductionButton")
        {
            if (!isOn)
            {
                production_panel.localPosition = new Vector2(0, -Screen.height);
                production_panel.LeanMoveLocalY(-360, 0.5f).setEaseOutExpo().delay = 0.1f;
                isOn = true;
            }
            else
            {
                production_panel.LeanMoveLocalY(-590, 0.5f).setEaseInExpo();
                isOn = false;
            }
        }
    }

    

    
}
