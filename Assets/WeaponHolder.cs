using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public int selectedWeapon = 0;
    public GameObject currWeapon;


    void Start()
    {
        selectWeapon();    
    }

    void Update()
    {
        int prevSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
            }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if(prevSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
        }
    }

    public void selectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                currWeapon = weapon.gameObject;
            }
            else
            {
            weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public GameObject getWeapon()
    {
        return currWeapon;
    }

}
