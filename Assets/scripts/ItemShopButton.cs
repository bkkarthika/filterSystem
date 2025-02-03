using UnityEngine;
using TMPro;

public class ItemShopButton : MonoBehaviour
{
   public TextMeshProUGUI buttonText;
   public string itemName;

   public void SetText()
   {
    buttonText.text = itemName;
   }
   public void ButtonPressed(){
    Debug.Log("u have selected"+itemName);
   }
}
