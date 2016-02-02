using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainController : MonoBehaviour {



//	public GameObject BToggle;

	public GameObject DetailObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toggleClick(GameObject obj)
	{


		Debug.Log("tod " + obj + " " + obj.GetComponent<Toggle>().isOn + " " + obj.tag);
	
		DataController.instance.showOrHidDetail(obj,obj.GetComponent<Toggle>().isOn);

	
	}

	public void SaveItem(int tag)
	{

	}

	public void saveAllData()
	{
		DataController.instance.saveAllData();
	}
}
