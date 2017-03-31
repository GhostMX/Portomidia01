/*********************************************************
* Author: Justin Williamson
* CubeScript for simple pass through script. 
* Create your character two emptygameObjects and tag them ("TopTrigger")("BottomTrigger")
* getComponent these emptygameObjects box colliders
* check the isTrigger box for both box colliders
* TopTrigger Should be the length of the gameObject "player" and the BottomTrigger
* should be small and at the bottom of the gameObject.
* getComponent your ground blocks rigidbodies and uncheck useGravity
* drop this script into your ground blocks and poof, jump through blocks.
* only error, hits his head on second jump first time. Small Glitch.
* ********************************************************/

using UnityEngine;
using System.Collections;

public class CubeTriggerScript : MonoBehaviour {
}