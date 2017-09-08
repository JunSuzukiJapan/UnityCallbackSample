using UnityEngine;

public class Caller : MonoBehaviour {
	void Start () {
		SampleCallback.CallPlugin(8, OnEndOfCalculate);
	}

	void OnEndOfCalculate(int x){
		Debug.LogFormat("x: {0}", x);
	}
}
