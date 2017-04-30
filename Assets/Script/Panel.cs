using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, IPointerDownHandler {

	private static Transform FindPanels() {
		GameObject panels = GameObject.Find("Canvas/Panels");
		if (panels == null) {
			GameObject canvas = GameObject.Find("Canvas");
			GameObject prefab = GameManager.instance.prefabs["Panels"];
			if (canvas == null || prefab == null) {
				return null;
			}
			panels = Instantiate(prefab);
			panels.name = prefab.name;
			panels.transform.SetParent(canvas.transform, false);
		}
		return panels.transform;
	}

	public static bool IsOpened(string name) {
		Transform panels = FindPanels();
		if (panels == null) return false;
		Transform transform = panels.Find(name);
		return transform != null;
	}

	public static Panel Open(GameObject prefab) {
		Transform panels = FindPanels();
		if (panels == null) return null;
		Transform transform = panels.Find(prefab.name);
		if (transform == null) {
			transform = Instantiate(prefab).transform;
			transform.gameObject.name = prefab.name;
			transform.SetParent(panels, false);
		}
		transform.gameObject.SetActive(false);
		Panel panel = transform.GetComponent<Panel>();
		panel.Open();
		return panel;
	}

	public static Panel Open(string name) {
		Transform panels = FindPanels();
		if (panels == null) return null;
		Transform transform = panels.Find(name);
		if (transform == null) {
			if (!GameManager.instance.prefabs.ContainsKey(name)) return null;
			GameObject prefab = GameManager.instance.prefabs[name];
			transform = Instantiate(prefab).transform;
			transform.gameObject.name = prefab.name;
			transform.SetParent(panels, false);
		}
		transform.gameObject.SetActive(false);
		Panel panel = transform.GetComponent<Panel>();
		panel.Open();
		return panel;
	}

	public static void Close(string name) {
		Transform panels = FindPanels();
		if (panels == null) return;
		Transform transform = panels.Find(name);
		if (transform != null) {
			Panel panel = transform.GetComponent<Panel>();
			panel.Close();
		}
	}

	public static bool CloseByBack() {
		Transform panels = FindPanels();
		if (panels == null) return false;
		for (int i = panels.childCount - 1; i >= 0; --i) {
			Panel panel = panels.GetChild(i).GetComponent<Panel>();
			if (panel.IsOpened() && panel.closeByBack) {
				panel.Close();
				return true;
			}
		}
		return false;
	}

	public bool destoryOnClosed = true;
	public bool closeByBack = true;
	public bool closeByClickBlank = false;

	void Awake() {
		OnAwake();
	}

	// Use this for initialization
	void Start() {
		OnStart();
	}

	// Update is called once per frame
	void Update() {
		OnUpdate();
	}

	protected virtual void OnAwake() {
	}

	protected virtual void OnStart() {
	}

	protected virtual void OnUpdate() {
	}

	public virtual bool IsOpened() {
		return gameObject.activeSelf;
	}

	public virtual void Open() {
		if (!IsOpened()) {
			OnOpen();
			gameObject.SetActive(true);
		}
	}

	public virtual void Close() {
		if (IsOpened()) {
			OnClose();
			if (destoryOnClosed) {
				Destroy(gameObject);
			} else {
				gameObject.SetActive(false);
			}
		}
	}

	public virtual void Cancel() {
		if (IsOpened()) {
			OnCancel();
			Close();
		}
	}

	protected virtual void OnOpen() {
		
	}

	protected virtual void OnClose() {
		
	}

	protected virtual void OnCancel() {
		OnClick("Cancel");
	}

	public void OnClick(string button) {
		
	}

	public virtual void OnPointerDown(PointerEventData eventData) {
		if (closeByClickBlank && eventData.pointerEnter == gameObject) {
			Cancel();
		}
	}
}
