using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StaticEnforcer))]
public class StaticEnforcerEditor : Editor {
	public override void OnInspectorGUI() {
		var message = "This component propagates static flag of this object on importing, to all of this children, including indirect children under the object tree. This component needs to be added to the root object of imported model.";
		EditorGUILayout.HelpBox(message, MessageType.None);
	}
}
