﻿using System.Collections;
using SimpleJson;
using UnityEngine;
using System.Collections.Generic;

public class ConfigCode
{
	private Dictionary<int, ConfigItemCode> codeDict = new Dictionary<int, ConfigItemCode> ();

	public Dictionary<int, ConfigItemCode> GetConfig ()
	{
		return this.codeDict;
	}

	public void Clear ()
	{
		this.codeDict.Clear ();
	}

	public void LoadFromJson (JsonObject data)
	{
		this.Clear ();

		if (data == null) {
			Debug.Log ("json读取错误");
			return;
		} else {
			for (int i = 0; i < data.Count; i++) {
				ConfigItemCode node = new ConfigItemCode ();
				JsonObject item = (JsonObject)data [i];
				node.LoadFromJson (item);
				this.codeDict.Add (node.Id, node);
			}
		}
	}

	public ConfigItemCode GetItem (int id)
	{
		if (!this.codeDict.ContainsKey (id)) {
			return null;
		}

		return (ConfigItemCode)this.codeDict [id];
	}

	public ConfigItemCode GetItemByIndex (int index)
	{
		if (index >= this.codeDict.Count) {
			return null;
		}

		List<int> listKey = new List<int> (this.codeDict.Keys);
		return this.GetItem (listKey [index]);
	}
}