using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooledMonoBehaviour 
{
	void OnCreate();
	void OnGet();
	void OnRecycle();
}