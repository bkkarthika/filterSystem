using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FilterComponet : MonoBehaviour
{
    public GameObject filter;
    public GameObject _ShopScrollPanel;
    public TextMeshProUGUI helpTxt;
    public Toggle[] _gtoggles;
    public Toggle[] _ctoggles;
    private string ShopFor="Men";
    public int noOfSampleItem;
  
    private List<string> SampleShoppingData;
    private List<string> catevalues;
    public ShopItemManager _ShopItemManager;
 
    
   
   
    void OnEnable()
    {
        helpTxt.text = "";
         catevalues = new List<string>();
         SampleShoppingData = new List<string>();
        foreach (Toggle toggle in _gtoggles)
        {
            
            toggle.onValueChanged.AddListener(delegate {
                ShopForToggleValue(toggle);
            });
        }
        
        foreach (Toggle toggle in _ctoggles)
        {
            if (toggle.isOn)
            {
                 catevalues.Add(toggle.name);
            }
          toggle.onValueChanged.AddListener(delegate {
                CategoryToggleValue(toggle);
            });
        }
    }
   
    void ShopForToggleValue(Toggle toggle)
    {
        if (toggle.isOn)
        {
            Debug.Log(toggle.name);
            ShopFor = toggle.name;
          
        }
    }
    void CategoryToggleValue(Toggle toggle)
    {
        if (toggle.isOn)
        {
            helpTxt.text = "";
            catevalues.Add(toggle.name);
        }
        else{
            for (int i =0; i < catevalues.Count; i++)
            {
                if (catevalues[i]== toggle.name)
                {
                    catevalues.Remove(catevalues[i]);
                     Debug.Log("removed: "+toggle.name);
                     break;
                }
  
            }
        }
    }
    public void resetFilter(){
        bool resetval =true;
        foreach (Toggle toggle in _gtoggles)
        {
            if(resetval)
            toggle.isOn = true;
            else
             toggle.isOn = false;
           
            resetval = false;
        }
        resetval =true;
        foreach (Toggle toggle in _ctoggles)
        {
            if(resetval)
            toggle.isOn = true;
            else
             toggle.isOn = false;
            resetval = false;
        }
        for (int i =0; i < catevalues.Count; i++)
            {
                 catevalues.Remove(catevalues[i]);
             }
         ShopFor = "Men";
    }
    public void ApplyFilter(){

        if(catevalues.Count==0)
        {
            helpTxt.text = "Please Select Category ";
        }
        else{
            for (int i =0; i < catevalues.Count; i++)
            {
                for (int j =0;j<noOfSampleItem;j++){
                   SampleShoppingData.Add(ShopFor+" "+catevalues[i]+" "+j);
                   Debug.Log("data "+SampleShoppingData[j]);
                }
                 
             }
             filter.SetActive(false);
            // _ShopScrollPanel.SetShopData(SampleShoppingData);
            _ShopItemManager.items = SampleShoppingData;
            _ShopItemManager.updateData() ;
             _ShopScrollPanel.SetActive(true);
        }
    }
    public void closeFilter(){
        filter.SetActive(false);
    }
   void Start() {
    Debug.Log("start");
 }
    // Update is called once per frame
 
}
