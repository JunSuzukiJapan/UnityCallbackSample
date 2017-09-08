using System;
using System.Runtime.InteropServices;

public class SampleCallback {
	// 「コールバックしたいメソッドの型」を宣言
	public delegate void Callback (int x);
	// 「コールバックしたいメソッドの引数を並べて宣言」 + メソッドのハンドル
	public delegate void CallbackCaller(int x, IntPtr methodHandle);

	// 「コールバックしたいメソッドの引数を並べて宣言」 + メソッドのハンドル + コールバックを呼び出すためのstaticなメソッド()
	[DllImport("__Internal")]
	private static extern void _CallPlugin (int x, IntPtr methodHandle, CallbackCaller caller);

	public static void CallPlugin (int x, Callback callback) {
		// コールバック関数をGCされないようにAllocしてハンドルを取得する。
		IntPtr gcHandle = (IntPtr)GCHandle.Alloc(callback, GCHandleType.Normal);
		// 普通の引数 + コールバック関数のハンドル + コールバック関数を呼び出すためのstaticなメソッド
		_CallPlugin (x, gcHandle, CallCallback);
	}

	[AOT.MonoPInvokeCallbackAttribute(typeof(CallbackCaller))]
	static void CallCallback (int x, IntPtr methodHandle){
		GCHandle handle = (GCHandle)methodHandle;
		Callback callback = handle.Target as Callback;
		// 不要になったハンドルを解放する。
		handle.Free();

		callback(x);
	}
}
