using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

// 再インポート時にモデルツリー全体がStaticを維持するようにする。
// 3Dモデルの根本のインスタンス(GameObject)にStaticEnforcerコンポーネントがAttachされているモデルがターゲットになる。

public class StaticEnforcePostprocessor : AssetPostprocessor {
	void OnPostprocessModel (GameObject obj) {
		var instances = FindAllPrefabInstancesOfName(obj.name);
		// モデルのインポート完了後、各インスタンスにStaticを強制するように要求する。
		foreach (var instance in instances) {
			StaticEnforcer enforcer = instance.GetComponent<StaticEnforcer> ();
			if (enforcer != null) {
				enforcer.RequestEnforceStatic ();
			}
		}
	}
    
	List<GameObject> FindAllPrefabInstancesOfName(string prefabName) {
		var result = new List<GameObject>();
		var allObjects = GameObject.FindObjectsOfType<GameObject>();
		foreach(var go in allObjects) {
			if (PrefabUtility.GetPrefabType(go) == PrefabType.ModelPrefabInstance) {
				UnityEngine.Object go_prefab = PrefabUtility.GetPrefabParent(go);
				if (prefabName == go_prefab.name) {
					result.Add(go);
				}
			}
		}
		return result;
	}
}
