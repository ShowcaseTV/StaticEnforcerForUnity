using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

// staticオブジェクトの再インポート時に、追加されたメッシュなどの部分のGameObjectだけstaticが外れてしまう現象への対策。
// モデル修正後に、配下の全GameObjectをstaticの状態で維持したいケース場合に、親オブジェクト（Prefabのインスタンス）にアタッチする。
// 親オブジェクトが非staticの場合は何も起こらない。
// StaticEnforcePostprocesser.csと連携して実行される。

// 2017/10/2 modified to set dirty flag properly, not to lose static flag on quitting unity.

[ExecuteInEditMode]
public class StaticEnforcer : MonoBehaviour {
#if UNITY_EDITOR
	private bool enforceStaticRequested = false;

	void Update() {
		if (enforceStaticRequested) {
			EnforceStatic ();
			enforceStaticRequested = false;
		}
	}

	void SetStaticRecursively(Transform trans) {
		if (!trans.gameObject.isStatic) {
			// set dirty flag and also undo-able
			Undo.RecordObject (trans.gameObject, "enforced static");
			trans.gameObject.isStatic = true;
		}
		foreach (Transform childTrans in trans) {
			SetStaticRecursively (childTrans);
		}
	}

	public void EnforceStatic() {
		if (Application.isEditor) {
			if (gameObject.isStatic) {
				Debug.Log ("StaticEnforcer: enforcing static to: "+name);
				EnforceStaticInternal();
			}
		}
	}

	void EnforceStaticInternal() {
		SetStaticRecursively (transform);
	}

	public void RequestEnforceStatic() {
		enforceStaticRequested = true;
	}
#endif
}
