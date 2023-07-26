using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTips : MonoBehaviour
{
    [SerializeField]
    private GameObject popupCanvasObject;
    [SerializeField]
    private RectTransform popupObject;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float padding;

    private Canvas popupCanvas;

    public Text nameText;
    public Text detailText;

    private void Awake()
    {

        popupCanvas = popupCanvasObject.GetComponent<Canvas>();


    }

    public void Start()
    {
        gameObject.SetActive(false);

    }
    private void Update()
    {
        SetPosition();
    }
    public void ShowTooltip()
    {
        gameObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
    public void UpdateTooltip(string _detailText)
    {
        detailText.text = _detailText;
    }
    public void UpdateTooltipName(string _nameText)
    {
        nameText.text = _nameText;
    }
    public void SetPosition()
    {
        if (!popupCanvasObject.activeSelf) { return; }

        Vector3 newPos = Input.mousePosition + offset;
        newPos.z = 0f;
        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + popupObject.rect.width * popupCanvas.scaleFactor / 2) - padding;
        if (rightEdgeToScreenEdgeDistance < 0)
        {

            newPos.x += rightEdgeToScreenEdgeDistance;
        }
        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - popupObject.rect.width * popupCanvas.scaleFactor / 2) + padding;
        if (leftEdgeToScreenEdgeDistance > 0)
        {

            newPos.x += leftEdgeToScreenEdgeDistance;
        }
        float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + popupObject.rect.height * popupCanvas.scaleFactor) - padding;
        if (topEdgeToScreenEdgeDistance < 0)
        {

            newPos.y += topEdgeToScreenEdgeDistance;
        }
        popupObject.transform.position = newPos;

        //transform.localPosition = _pos;
    }
}
