using UnityEngine;
using System.Collections;

public static class GameTime {
	public static bool paused = true;

	public static int stepsSinceStartup = 0;


	public static void Step() {
		if(!paused) stepsSinceStartup++;
		Messenger.Broadcast("step");
	}


}
