using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health_Manager : MonoBehaviour
{
    public float health;
    private float lerpTimer;

    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public static Player_Health_Manager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
     //   UpdateHealthUI();
    }

   /* private void UpdateHealthUI()
    {
        float fillF = Player_Get_Buttons.instance.healthFrontFill.fillAmount;
        float fillB = Player_Get_Buttons.instance.healthBackFill.fillAmount;
        float hFrection = health / maxHealth;

        if(fillB > hFrection)
        {
            Player_Get_Buttons.instance.healthFrontFill.fillAmount = hFrection;
            Player_Get_Buttons.instance.healthBackFill.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentCompleted = lerpTimer / chipSpeed;
            percentCompleted = percentCompleted * percentCompleted;
            Player_Get_Buttons.instance.healthBackFill.fillAmount = Mathf.Lerp(fillB,hFrection,percentCompleted);
        }

        if (fillF < hFrection)
        {
            Player_Get_Buttons.instance.healthBackFill.color = Color.green;
            Player_Get_Buttons.instance.healthBackFill.fillAmount = hFrection;
            lerpTimer += Time.deltaTime;
            float percentCompleted = lerpTimer / chipSpeed;
            percentCompleted = percentCompleted * percentCompleted;
            Player_Get_Buttons.instance.healthFrontFill.fillAmount = Mathf.Lerp(fillF, Player_Get_Buttons.instance.healthBackFill.fillAmount, percentCompleted);
        }
    }
*/
    public void TackDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f; 
    }
}
