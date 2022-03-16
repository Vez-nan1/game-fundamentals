
using UnityEngine;

public class weponHolder : MonoBehaviour
{
    public int selectedWepon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWepon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWepon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWepon >= transform.childCount - 1)
                selectedWepon = 0;
            else
                selectedWepon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWepon <= 0)
                selectedWepon = transform.childCount - 1;
            else
                selectedWepon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWepon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWepon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWepon = 2;
        }

        if (previousSelectedWeapon != selectedWepon)
        {
            SelectWepon();
        }
    }

    void SelectWepon()
    {
        int i = 0;
        foreach (Transform wepon in transform)
        {
            if (i == selectedWepon)
                wepon.gameObject.SetActive(true);
            else
                wepon.gameObject.SetActive(false);
            i++;
        }
    }
}
