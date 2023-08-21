using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipPop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private ToolTips toolTips;

    public BuildData buildData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTips.ShowTooltip();
        toolTips.UpdateTooltipName(buildData.BuildDataName);
        toolTips.UpdateTooltip(buildData.BuildDataDes);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTips.HideTooltip();
        toolTips.UpdateTooltipName("");
        toolTips.UpdateTooltip("");
    }
}
