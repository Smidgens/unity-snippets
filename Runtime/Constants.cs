// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	// magic constants, lt.dan
	internal static class Constants
	{
		public static class Docs
		{
			public const string
			URL_UNITY = "https://docs.unity3d.com/ScriptReference/{0}.html",
			URL_WIKIPEDIA = "https://en.wikipedia.org/wiki/{0}",
			URL_CSHARP = "https://learn.microsoft.com/en-us/dotnet/api/{0}";

			public const string
			LABEL_UNITY = "About @ Unity",
			LABEL_WIKIPEDIA = "About @ Wikipedia",
			LABEL_CSHARP = "About @ Microsoft";
		}


		// AddComponentMenu paths
		public static class ACM
		{
			public const string ROOT =
			nameof(Smidgenomics) + "/"
			+ nameof(Snippets) + "/";

			private static class Prefix
			{
				public const string MATH = ROOT + "Math/";
			}

			public const string SCENE = ROOT + "Scene/Scene : ";
			public const string APPLICATION = ROOT + "Application/Application : ";

			public const string
			VARIABLE = ROOT + "Variable/Variable : ";

			public const string
			EVENT_ROOT = ROOT + "Event/";

			public const string
			EVENT_ON_APPLICATION = EVENT_ROOT + "Application/Application : On Application ",
			EVENT_ON_SCENE = EVENT_ROOT + "Scene Manager/Scene : ",
			EVENT_ON_TRIGGER = EVENT_ROOT + "Collider/Trigger/Collider : On Trigger ",
			EVENT_ON_COLLISION = EVENT_ROOT + "Collider/Collision/Collider : On Collision ",
			EVENT_UPDATE = EVENT_ROOT + "Update/Update : ",
			EVENT_ON_ANIMATOR = EVENT_ROOT + "Animator/Animator : ",
			EVENT_ON_RENDERER = EVENT_ROOT + "Renderer/Renderer : ",
			EVENT_ON_MOUSE = EVENT_ROOT + "Collider/Mouse/Collider : On Mouse ",
			EVENT_ON_TRANSFORM = EVENT_ROOT + "Transform/Transform : On Transform ",
			EVENT_AUDIO = EVENT_ROOT + "Audio/Audio : ",
			EVENT_INIT = EVENT_ROOT + "Init/Init : ",
			EVENT_CLEANUP = EVENT_ROOT + "Cleanup/Cleanup : ",
			EVENT_ON_GIZMOS = EVENT_ROOT + "Gizmos/Gizmos : On Draw Gizmos",
			EVENT_CUSTOM = EVENT_ROOT + "Custom/Custom Event : ",
			EVENT_ON_PHYSICS = EVENT_ROOT + "Physics/Physics : ",
			EVENT_ON_GUI = EVENT_ROOT + "IMGUI/IMGUI : ";

			public const string
			GAMEOBJECT = ROOT + "Game Object/Game Object : ";

			public const string
			TRANSFORM = ROOT + "Transform/Transform : ";

			public const string
			ANIMATION_SMR = ROOT + "Animation/Skinned Mesh/SMR : ",
			ANIMATION = ROOT + "Animation/";

			// value generators
			public const string
			FILE_READ = ROOT + "File/Read/File : ",
			RANDOM = ROOT + "Random/Random : ",
			VALUE_TIME = ROOT + "Time/Time : ",
			VALUE = ROOT + "Value/";

			// value casting
			public const string
			CONVERT_INT = ROOT + "Cast/Int/Cast : Int ",
			CONVERT_SCENE = ROOT + "Cast/Scene/Cast : Scene ",
			CONVERT_VECTOR2 = ROOT + "Cast/Vector2/Cast : Vector2 ",
			CAST_STRING = ROOT + "Cast/String/Cast : String ",
			CAST_INT = ROOT + "Cast/Int/Cast : Int ",
			CAST = ROOT + "Cast/";

			// debug scripts
			public const string
			DEBUG_GIZMO = ROOT + "Debug/Gizmo/Gizmo : ",
			DEBUG_PRINT = ROOT + "Debug/Print/Print : ",
			DEBUG = ROOT + "Debug/";

			// input processors
			public const string
			INPUT_KEY = ROOT + "Input/Key/Input : ",
			INPUT_AXIS = ROOT + "Input/Axis/Input : ",
			INPUT = ROOT + "Input/";

			// asset loading
			public const string
			ASSETBUNDLE = ROOT + "Assets/Asset Bundle/Asset Bundle : ",
			ASSETS = ROOT + "Assets/";

			// math
			public const string
			MATH_FUNCTION = Prefix.MATH + "Function/Math : ",
			MATH_OPERATOR = Prefix.MATH + "Operator/Math : ",
			MATH = ROOT + "Math/";

			// flow
			public const string
			FLOW_TIMING = ROOT + "Flow/Timing/Timing : ",
			FLOW_CONDITIONAL = ROOT + "Flow/Conditional/Conditional : ",
			FOR_EACH = ROOT + "Flow/Loop/For Each : ",
			FLOW_CONTROL = ROOT + "Flow/Control/Control : ",
			FLOW = ROOT + "Flow/Flow : ";

			// player
			public const string
			PLAYER_PREFS = ROOT + "Player/Player Prefs/Player Prefs : ",
			PLAYER_PREFS_VALUE = ROOT + "Player/Player Prefs/Value/";
			public const string
			PLAYER_PREFS_STRING = ROOT + "Player/Player Prefs/Value/String/Player Prefs : ",
			PLAYER_PREFS_INT = ROOT + "Player/Player Prefs/Value/Int/Player Prefs : ",
			PLAYER_PREFS_FLOAT = ROOT + "Player/Player Prefs/Value/Float/Player Prefs : ";

		}
	}
}