// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System;
	using UnityEngine;


	

	[Serializable]
	internal class WrappedValue<T, VT>
	where VT : Variable<T>
	{
		public WrappedValue(T defaultValue = default)
		{
			_staticValue = defaultValue;
		}

		public T GetValue()
		{
			if (!_useVariable || !_variable) { return _staticValue; }
			return _variable.Value;
		}

		public T StaticValue
		{
			get => _staticValue;
			set => _staticValue = value;
		}

		public static implicit operator WrappedValue<T, VT>(T staticValue)
		{
			return new WrappedValue<T, VT>(staticValue);
		}

		public static implicit operator T(WrappedValue<T, VT> wv)
		{
			return wv.GetValue();
		}


		[SerializeField] internal bool _useVariable = false;
		[SerializeField] internal VT _variable = default;
		[SerializeField] internal T _staticValue = default;
		
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;
	using SP = UnityEditor.SerializedProperty;

	[CustomPropertyDrawer(typeof(WrappedValue<,>), true)]
	internal class _WrappedValue : PropertyDrawer
	{
		public override void OnGUI(Rect pos, SP prop, GUIContent l)
		{
			// label not blank and item not inside array
			if (l != GUIContent.none && !fieldInfo.FieldType.IsArray)
			{
				pos = EditorGUI.PrefixLabel(pos, l);
			}

			SP isVariable = prop.FindPropertyRelative(nameof(WrappedValue<float,Variable_Float>._useVariable));

			
			Rect popupRect = pos.SliceRight(70f);
			pos.SliceRight(2f);

			isVariable.boolValue = BoolPopup(popupRect, isVariable.boolValue);

			SP value = prop.FindPropertyRelative
			(
				isVariable.boolValue
				? nameof(WrappedValue<float, Variable_Float>._variable)
				: nameof(WrappedValue<float, Variable_Float>._staticValue)
			);


			EditorGUI.PropertyField(pos, value, GUIContent.none);

		}

		private static bool BoolPopup(in Rect pos, bool v)
		{
			int i = v ? 1 : 0;
			i = EditorGUI.Popup(pos, i, _LABELS);
			return i == 0 ? false : true;
		}

		private static readonly string[] _LABELS = { "Static", "Variable" };

	}
}

#endif