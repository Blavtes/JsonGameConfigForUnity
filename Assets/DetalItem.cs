using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetalItem  {


	public string  centerX;
	public string centerY;
	public string sizeW;
	public string sizeH;
	public string normollStr;
	public string HeightStr;
	public bool sound = false;
	public bool show = true;
	public string alpha = "1";
}
public class ConfigJsonData {
	
	
	public string errMsg = "0";
	public int errCode = 0;
	public string version = "1.0";
	public Config[] config;
}

public class InfoConfig 
{ 
	public	DetalItem aBt;
	public	DetalItem bBt;
	public	DetalItem cBt;
	public	DetalItem dBt;
	public	DetalItem eBt;
	public	DetalItem fBt;
	public	DetalItem gBt;
	public	DetalItem hBt;
	public	DetalItem jBt;
	public	DetalItem iBt;
	public	DetalItem kBt;
	public	DetalItem lBt;
	public	DetalItem mBt;
	public	DetalItem nBt;
	public	DetalItem oBt;
	public	DetalItem pBt;
	public	DetalItem archeryView;
	public	DetalItem padControll;
	public	DetalItem backgroundImageView;
	public	DetalItem angryBotsLeftView;
	public	DetalItem angryBotsRightView;
	public	DetalItem leftOneBt;
	public	DetalItem leftTwoBt;
	public	DetalItem controlDirectionImage;
}

public class Config
{
	public bool gyroscopeEnabled = false;
	public bool  bluetoothEnabled = false;
	public bool accelerometerEnabled = false;
	public string packageName;
//	public dic infoConfig;

	public Dictionary<string,DetalItem>infoConfig = new Dictionary<string,DetalItem>();
}