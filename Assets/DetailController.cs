using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DetailController : MonoBehaviour {

	public GameObject XObj;
	public GameObject YObj;
	public GameObject WObj;
	public GameObject HObj;
	public GameObject NomorObj;
	public GameObject HeithObj;
	public GameObject ZDObj;

	private string xString;
	private string yString;
	private string wString;
	private string hString;
	private string noString;
	private string HeString;

	public GameObject panControll;

	public GameObject tips;

	public GameObject tagObj;

	public static DetailController instance = null;

	void Awake()
	{
		instance = this;

	}
	void Start()
	{

	}



	public void SaveClick()
	{
	
		DetalItem item = new DetalItem();

		xString = XObj.gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>().text;
		yString = YObj.gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>().text;
		wString = WObj.gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>().text;
		hString = HObj.gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>().text;;

		item.centerX =	xString;
		item.centerY =	yString;
		item.sizeW =    wString;
		item.sizeH =	hString;

		item.normollStr = NomorObj.gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>().text;;
		item.HeightStr = HeithObj.gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>().text;;
		item.sound = ZDObj.gameObject.GetComponent<Toggle>().isOn;

//	try {
//		
//		} catch (System.Exception ex) {
//		
//		}

		float x = 0.0f , y =0.0f , w= 0.0f, h = 0.0f;

		if ((float.TryParse(item.centerX , out x) &&   x<= 0.0f) || (float.TryParse(item.centerX, out y) && y  >= 2208.0f) ||((float.TryParse(item.centerY, out w) && w <= 0.0f) || (float.TryParse(item.centerY, out h) && h >= 1242.0f))) {
			Debug.Log("error");
//			tips.SetActive(true);
			GameObject.Find("tips").gameObject.transform.GetComponent<Text>().text = "位置输入错误!!!";
//			tips.transform.GetComponent<Text>().text = "位置输入错误!!!";
			return;
		}	else {
//			tips.SetActive(false);
			GameObject.Find("tips").gameObject.transform.GetComponent<Text>().text  = "";
		}

		Debug.Log("item " + item.centerX + " " + item.centerY +" " + item.sizeW + " h " + item.sizeH + " sunde " + item.sound+ " n " + item.normollStr + " h " + item.HeightStr);


		Debug.Log("SaveClick" + xString);

		DataController.instance.saveItemData(item);
		DataController.instance.hideDetail();
	}

	public void CancelClick()
	{
		Debug.Log("CancelClick");
	}

	public void setTitle()
	{

	}
}
