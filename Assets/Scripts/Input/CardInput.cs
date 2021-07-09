using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInput : MonoBehaviour
{

    public RectTransform rectTransform;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    public Vector3 defaultPosition;
    public Vector3 GetDefaultPosition {get {return defaultPosition;}}
    public Vector3 SetDefaultPosition {set {defaultPosition = value;}}

    private Vector3 screenPoint;
    private Vector3 offset;

    void Awake() {
        defaultPosition = rectTransform.localPosition;
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = false;
        //Debug.Log("not kinematic");
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
 
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
 
    }

    void OnMouseUpAsButton() {
        ResetPosition();
    }

    void OnMouseOver() {
        spriteRenderer.color = Color.grey;
        Scale(0.65f);
    }

    void OnMouseExit() {
        spriteRenderer.color = Color.white;
        Scale(0.6f);
        
    }

    void Scale(float newscale) { 
        rectTransform.localScale = new Vector3(newscale,newscale,1f);
    }

    public void ResetPosition() {
        rectTransform.localPosition = defaultPosition;
    }
}
