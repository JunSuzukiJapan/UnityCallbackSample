using UnityEngine;
using UnityEngine.UI;

public class Caller : MonoBehaviour {
	public InputField input;
	public Text text;
	public void Multiply(){
		string s = input.text;
		int result;
		if(int.TryParse(s, out result)){
			SampleCallback.CallPlugin(result, OnEndOfCalculate);
		}else{
			Debug.LogFormat("can't parse: {0}", s);
		}
	}

	void OnEndOfCalculate(int x){
		Debug.LogFormat("x: {0}", x);
		text.text = string.Format("{0}", x);
	}
}
