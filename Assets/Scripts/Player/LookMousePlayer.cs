using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMousePlayer : MonoBehaviour
{
    Animator anim;
    public new Camera camera;
    public Transform positionParent;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        ChangeAnimations();
    }

    void ChangeAnimations()
    {
        Vector3 direction = (mousePosition - new Vector2(positionParent.position.x, positionParent.position.y)).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (mousePosition.y > positionParent.position.y && angle > 35 && angle < 155)
        {
            anim.SetBool("IsUp", true);
            anim.SetBool("IsDown", false);
            anim.SetBool("IsRigth", false);
            anim.SetBool("IsLeft", false);
        }
        else if(mousePosition.y < positionParent.position.y && angle < -35 && angle > -155)
        {
            anim.SetBool("IsUp", false);
            anim.SetBool("IsDown", true);
            anim.SetBool("IsRigth", false);
            anim.SetBool("IsLeft", false);
        }else if (angle > -35 && angle < 35)
        {
            anim.SetBool("IsRigth", true);
            anim.SetBool("IsLeft", false);
            anim.SetBool("IsUp", false);
            anim.SetBool("IsDown", false);
        }
        else
        {
            anim.SetBool("IsRigth", false);
            anim.SetBool("IsLeft", true);
            anim.SetBool("IsUp", false);
            anim.SetBool("IsDown", false);
        }
    }
}
