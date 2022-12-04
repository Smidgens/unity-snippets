// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	// magic constants, lt.dan
	internal static class Constants
	{
		// AddComponentMenu paths
		public static class ACM
		{
			public const string ROOT =
			nameof(Smidgenomics) + "/"
			+ nameof(Snippets) + "/";

			public const string
			EVENT_SCRIPT = ROOT + "Event/Script/Script : ",
			EVENT_APPLICATION = ROOT + "Event/Script/Application : ",
			EVENT_SCENE = ROOT + "Event/Scene/Scene : ",
			EVENT_TRIGGER = ROOT + "Event/Collider/Trigger/Collider : ",
			EVENT_COLLISION = ROOT + "Event/Collider/Collision/Collider : ",
			EVENT_UPDATE = ROOT + "Event/Update/Update : ",
			EVENT_ANIMATOR = ROOT + "Event/Animator/Animator : ",
			EVENT_RENDERER = ROOT + "Event/Renderer/Renderer : ",
			EVENT_COLLIDER_MOUSE = ROOT + "Event/Collider/Mouse/Collider : ",
			EVENT_TRANSFORM = ROOT + "Event/Transform/Transform : ",
			EVENT_AUDIO = ROOT + "Event/Audio/Audio : ",
			EVENT_INIT = ROOT + "Event/Init/Init : ",
			EVENT_CLEANUP = ROOT + "Event/Cleanup/Cleanup : ",
			EVENT_GIZMOS = ROOT + "Event/Gizmos/Gizmos : ",
			EVENT_CUSTOM = ROOT + "Event/Custom/Custom Event : ",
			EVENT_PHYSICS = ROOT + "Event/Physics/Physics : ",
			EVENT = ROOT + "Event/";

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

			// flow scripts
			public const string
			MATH_AUDIO = ROOT + "Math/Audio/Math : ",
			MATH_UNARY = ROOT + "Math/Unary/Math : ",
			MATH = ROOT + "Math/";

			// flow scripts
			public const string
			FLOW_TIMING = ROOT + "Flow/Timing/Timing : ",
			FLOW_CONDITIONAL = ROOT + "Flow/Conditional/Conditional : ",
			FOR_EACH = ROOT + "Flow/For Each/For Each : ",
			FLOW = ROOT + "Flow/Flow : ";

			// user store
			public const string
			STORAGE_PREFS = ROOT + "Storage/Player Prefs/";

		}
	}
}