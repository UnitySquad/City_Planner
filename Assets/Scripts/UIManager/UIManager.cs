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
    public Transform build_button;
    public Transform road_button;
    public Transform shop_button;
    public Transform production_button;

    private bool buildisOn;
    private bool roadisOn;
    private bool shopisOn;
    private bool prdouctionisOn;

    // Start is called before the first frame update
    void Awake()
    {
        build_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
        road_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
        shop_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
        production_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
        build_button.LeanMoveLocalY(-515, 0.5f).setEaseInExpo();
        road_button.LeanMoveLocalY(-515, 0.5f).setEaseInExpo();
        shop_button.LeanMoveLocalY(-515, 0.5f).setEaseInExpo();
        production_button.LeanMoveLocalY(-515, 0.5f).setEaseInExpo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movebutton_on()
    {
        build_button.LeanMoveLocalY(-285, 0.5f).setEaseOutExpo();
        road_button.LeanMoveLocalY(-285, 0.5f).setEaseOutExpo();
        shop_button.LeanMoveLocalY(-285, 0.5f).setEaseOutExpo();
        production_button.LeanMoveLocalY(-285, 0.5f).setEaseOutExpo();
    }

    public void movebutton_off()
    {
        build_button.LeanMoveLocalY(-515, 0.5f).setEaseInExpo();
        road_button.LeanMoveLocalY(-515, 0.5f).setEaseInExpo();
        shop_button.LeanMoveLocalY(-515, 0.5f).setEaseInExpo();
        production_button.LeanMoveLocalY(-515, 0.5f).setEaseInExpo();
    }

    public void panelBarOnOff()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if(clickObject.name == "BuildingButton")
        {
            if(!buildisOn)
            {
                build_panel.LeanMoveLocalY(-420, 0.5f).setEaseOutExpo();
                movebutton_on();
                road_panel.LeanMoveLocalY(-650, 0.5f).setEaseInExpo();
                shop_panel.LeanMoveLocalY(-650, 0.5f).setEaseInExpo();
                production_panel.LeanMoveLocalY(-650, 0.5f).setEaseInExpo();

                buildisOn = true;
                roadisOn = false;
                shopisOn = false;
                prdouctionisOn = false;
            }
            else
            {
                build_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
                movebutton_off();
                buildisOn = false;
            }
            
            
        }
        else if(clickObject.name == "RoadButton")
        {
            if (!roadisOn)
            {
                road_panel.LeanMoveLocalY(-420, 0.5f).setEaseOutExpo();
                movebutton_on();
                build_panel.LeanMoveLocalY(-650, 0.5f).setEaseInExpo();
                shop_panel.LeanMoveLocalY(-650, 0.5f).setEaseInExpo();
                production_panel.LeanMoveLocalY(-650, 0.5f).setEaseInExpo();
                
                buildisOn = false;
                roadisOn = true;
                shopisOn = false;
                prdouctionisOn = false;
            }
            else
            {
                road_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
                movebutton_off();
                roadisOn = false;
            }
        }
        else if(clickObject.name == "ShopButton")
        {
            if (!shopisOn)
            {
                shop_panel.LeanMoveLocalY(-420, 0.5f).setEaseOutExpo();
                movebutton_on();
                build_panel.LeanMoveLocalY(-650, 0.5f).setEaseInExpo();
                road_panel.LeanMoveLocalY(-650, 0.5f).setEaseInExpo();
                production_panel.LeanMoveLocalY(-650, 0.5f).setEaseInExpo();

                buildisOn = false;
                roadisOn = false;
                shopisOn = true;
                prdouctionisOn = false;
            }
            else
            {
                shop_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
                movebutton_off();
                shopisOn = false;
            }
        }
        else if(clickObject.name == "ProductionButton")
        {
            if (!prdouctionisOn)
            {
                production_panel.LeanMoveLocalY(-420, 0.5f).setEaseOutExpo();
                movebutton_on();
                build_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
                road_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
                shop_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();

                buildisOn = false;
                roadisOn = false;
                shopisOn = false;
                prdouctionisOn = true;
            }
            else
            {
                production_panel.LeanMoveLocalY(-655, 0.5f).setEaseInExpo();
                movebutton_off();
                prdouctionisOn = false;
            }
        }
    }

    

    
}
