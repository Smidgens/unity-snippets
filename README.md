# Unity Snippets

A collection of modular snippet scripts for Unity. Each script handles some specifc task and is designed to be chained together or combined with your own game scripts directly in Unity's inspector in a manner similar to built-in Unity components, allowing you to quickly wire together more complex behaviours outside of code.

Using these scripts you can skip a lot of common boilerplate logic (listening to collisions, input, timed function calls etc.) and instead focus on features specific to your game. You can also easily replace these scripts later as you see fit (as would be advisable anyway post-prototype stage).

---

For a full list of available scripts, see [script folder](https://github.com/Smidgens/unitysnippets/tree/master/Assets/SnippetScripts/Scripts).

---


**Notes**:

* If you're using optimizations like code stripping, you'll want to utilize Unity's [Preserve](https://docs.unity3d.com/ScriptReference/Scripting.PreserveAttribute.html) attribute to make sure that methods or properties you've bound in the inspector don't get removed in the build, as the generics are largely Reflection based ([UnityEvent](https://docs.unity3d.com/Manual/UnityEvents.html)).
