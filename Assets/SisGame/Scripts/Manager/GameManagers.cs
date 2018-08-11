﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SIS.Managers
{
	public static class GameManagers
	{
		//Allows for scriptable object resources to be used
		static ResourcesManager resourceManager;
		public static ResourcesManager ResourceManager
		{
			get
			{
				if (resourceManager == null)
				{
					resourceManager = Resources.Load("ResourcesManager") as ResourcesManager;
					resourceManager.Init();
				}
				return resourceManager;
			}
		}

		//CharacterStateManager
	}
}