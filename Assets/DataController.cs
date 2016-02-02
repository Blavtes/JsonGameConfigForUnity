using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using LitJson;
using FullSerializer;

public class DataController : MonoBehaviour {


	public GameObject PackageInputObj;
	public GameObject VersionInputObj;
	
	public GameObject BluethObj;
	
	public GameObject JiashujiObj;
	public GameObject TuoluoyiObj;
	
	public GameObject YaoganObj;
	public GameObject FXPObj;
	
	public GameObject AToggle;
	public GameObject BToggle;
	
	public GameObject CToggle;
	public GameObject DToggle;
	public GameObject EToggle;
	public GameObject FToggle;
	public GameObject GToggle;
	public GameObject HToggle;
	public GameObject IToggle;
	public GameObject JToggle;
	public GameObject KToggle;
	public GameObject LToggle;
	public GameObject MToggle;
	public GameObject NToggle;
	public GameObject OToggle;
	public GameObject PToggle;
	public GameObject DetailObj;

	public static DataController instance = null;

	public GameObject TempObj;

	public GameObject titleObj;

	public Dictionary<string,DetalItem>myDict =new Dictionary<string,DetalItem>();

	struct SerializedStruct {
		public int Field;
		
		public Dictionary<string, string> DictionaryAutoProperty { get; set; }
		
		[SerializeField]
		private int PrivateField;
	}

	
	//  Use this for initialization
	void Start () {
		instance = this;
		PackageInputObj = GameObject.Find("package").gameObject;
		VersionInputObj = GameObject.Find("VersionInputField").gameObject;
		BluethObj = GameObject.Find("lanya").gameObject;
		JiashujiObj = GameObject.Find("jiashuji").gameObject;
		TuoluoyiObj = GameObject.Find("tuoluoyi").gameObject;
		YaoganObj = GameObject.Find("YaoganToggle").gameObject;
		FXPObj = GameObject.Find("FXPToggle").gameObject;
		AToggle = GameObject.Find("AToggle").gameObject;
		BToggle = GameObject.Find("BToggle").gameObject;
		CToggle = GameObject.Find("CToggle").gameObject;
		DToggle = GameObject.Find("DToggle").gameObject;
		EToggle = GameObject.Find("EToggle").gameObject;
		FToggle = GameObject.Find("FToggle").gameObject;
		GToggle = GameObject.Find("GToggle").gameObject;
		HToggle = GameObject.Find("HToggle").gameObject;

		IToggle = GameObject.Find("IToggle").gameObject;
		JToggle = GameObject.Find("JToggle").gameObject;
		KToggle = GameObject.Find("KToggle").gameObject;
		LToggle = GameObject.Find("LToggle").gameObject;
		MToggle = GameObject.Find("MToggle").gameObject;
		NToggle = GameObject.Find("NToggle").gameObject;
		OToggle = GameObject.Find("OToggle").gameObject;
		PToggle = GameObject.Find("PToggle").gameObject;
		titleObj = GameObject.Find("titleText").gameObject;

		DetailObj = GameObject.Find("DetailPanel").gameObject;
		DetailObj.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showOrHidDetail(GameObject obj,bool show)
	{
		DetailObj.SetActive(show);
	
		TempObj = obj;
		titleObj.SetActive(show);
		if (show) {
			titleObj.GetComponent<Text>().text = "配置按钮："+ DataController.instance.TempObj.tag;
		} else {
			titleObj.GetComponent<Text>().text = "";
		}

	}

	public void hideDetail()
	{
		DetailObj.SetActive(false);
	}


	public void saveItemData(DetalItem item)
	{
		titleObj.GetComponent<Text>().text = "";
		if (TempObj.tag == "padControll") {
			item.normollStr = "";
			item.HeightStr = "";
			item.sound = false;
			item.sizeH = "0";
			item.sizeW = "0";
			item.centerX = ""+ float.Parse(item.centerX) / 2204.0f * 2;
			item.centerY = "" +float.Parse(item.centerY) /  1242.0f *2;

		}
		item.sizeH = "" + float.Parse(item.sizeW) / float.Parse(item.sizeH);

		Debug.Log(" item " + item + TempObj.tag);
		if (myDict.ContainsKey(TempObj.tag)) {
			myDict.Remove(TempObj.tag);
		}
		myDict.Add(TempObj.tag,item);

	}


	public void saveAllData()
	{
		Debug.Log(" saveAll" + myDict);
		foreach (string item in myDict.Keys) {
			 DetalItem ite1;
			myDict.TryGetValue(item,out ite1);
			Debug.Log(" string key " + item + " value " + ite1.centerX);
		}

//		Dictionary<string,ConfigJsonData>dict =new Dictionary<string,ConfigJsonData>();

		ConfigJsonData jsonData = new ConfigJsonData();
		jsonData.errMsg = "";
		jsonData.errCode = 0;
		jsonData.version = VersionInputObj.transform.FindChild("Text").gameObject.GetComponent<Text>().text;



		Config config = new Config();


		config.bluetoothEnabled = BluethObj.GetComponent<Toggle>().isOn;
		config.accelerometerEnabled = JiashujiObj.GetComponent<Toggle>().isOn;
		config.gyroscopeEnabled = TuoluoyiObj.GetComponent<Toggle>().isOn;
		config.packageName = PackageInputObj.transform.FindChild("Text").gameObject.GetComponent<Text>().text;

		InfoConfig info = new InfoConfig();


	

	

		if (YaoganObj.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(YaoganObj.tag, out info.padControll);
//			config.infoConfig.set((object)info.padControll,YaoganObj.tag);
			config.infoConfig.Add(YaoganObj.tag,info.padControll);
		}

		if (AToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(AToggle.tag, out info.aBt);
//			jsonData.config.SetValue(info.aBt, AToggle.tag);
			config.infoConfig.Add(AToggle.tag, info.aBt);
		}
		if (BToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(BToggle.tag, out info.bBt);
//			jsonData.config.SetValue(info.bBt, BToggle.tag);
			config.infoConfig.Add(BToggle.tag,info.bBt);
		}

		if (CToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(CToggle.tag, out info.cBt);
//			jsonData.config.SetValue((object)info.cBt, CToggle.tag);
			config.infoConfig.Add(CToggle.tag, info.cBt);
		}

		if (DToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(DToggle.tag, out info.dBt);
//			jsonData.config.SetValue((object)info.dBt, DToggle.tag);
			config.infoConfig.Add(DToggle.tag,info.dBt);

		}
		if (EToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(EToggle.tag, out info.eBt);
//			jsonData.config.SetValue((object)info.eBt, EToggle.tag);
			config.infoConfig.Add(EToggle.tag, info.eBt);
		}
		if (FToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(FToggle.tag, out info.fBt);
//			jsonData.config.SetValue((object)info.fBt, FToggle.tag);
			config.infoConfig.Add(FToggle.tag, info.fBt);
		}
		if (GToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(GToggle.tag, out info.gBt);
//			jsonData.config.SetValue((object)info.gBt, GToggle.tag);
			config.infoConfig.Add(GToggle.tag, info.gBt);
		}
		if (HToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(HToggle.tag, out info.hBt);
//			jsonData.config.SetValue((object)info.hBt, HToggle.tag);
			config.infoConfig.Add(HToggle.tag, info.hBt);
		}
		if (IToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(IToggle.tag, out info.iBt);
//			jsonData.config.SetValue((object)info.iBt, IToggle.tag);
			config.infoConfig.Add(IToggle.tag,info.iBt);
		}
		if (LToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(LToggle.tag, out info.lBt);
//			jsonData.config.SetValue((object)info.lBt, LToggle.tag);
			config.infoConfig.Add(LToggle.tag, info.lBt);
		}
		if (MToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(MToggle.tag, out info.mBt);
			config.infoConfig.Add(MToggle.tag,info.mBt);
		}
		if (NToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(NToggle.tag, out info.iBt);
			config.infoConfig.Add(NToggle.tag, info.iBt);
		}
		if (OToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(OToggle.tag, out info.oBt);
			config.infoConfig.Add(OToggle.tag, info.oBt);
		}
		if (PToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(PToggle.tag, out info.pBt);
			config.infoConfig.Add(PToggle.tag, info.pBt);
		}
		if (JToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(JToggle.tag, out info.jBt);
			config.infoConfig.Add( JToggle.tag, info.jBt);
		}
		if (KToggle.GetComponent<Toggle>().isOn) {
			myDict.TryGetValue(KToggle.tag, out info.kBt);
			config.infoConfig.Add( KToggle.tag, info.kBt);
		}

//		config.infoConfig = info;

		jsonData.config = new Config[1];
		jsonData.config[0] = config;

		JsonData map = JsonMapper.ToJson(jsonData);

//		fsDirectConverter con = new fsDirectConverter();
//		con.TrySerialize();




		Debug.Log(" save "+ myDict.ToString() + " " + jsonData   + map);
	}

}
