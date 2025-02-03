using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopItemManager : MonoBehaviour
{
   
   public List<string>  items;
   public GameObject btnPrefab;
   public GameObject btnContainer;
   public GameObject shopPanel;
   private List<GameObject>  btnObj;

    void Start(){
        
   
   }
   public void updateData(){
        btnObj = new List<GameObject>();
          Debug.Log("listtt "+items.Count);
        for (int i =0; i < items.Count; i++)
        {
            GameObject go = Instantiate(btnPrefab);
            go.transform.SetParent(btnContainer.transform);
            go.GetComponent<ItemShopButton>().itemName = items[i];
            go.GetComponent<ItemShopButton>().SetText();
            btnObj.Add(go);
        }       
   }
    public void closeShopPanel(){
        for (int i =0; i < items.Count; i++)
        {
            items.Remove(items[i]);
            Destroy(btnObj[i]);
        }
        shopPanel.SetActive(false);
    }
   

}
