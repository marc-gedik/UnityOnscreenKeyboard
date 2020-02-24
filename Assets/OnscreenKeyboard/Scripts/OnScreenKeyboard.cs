using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

namespace OnScreenKeyboard {

	public class ShiftEvent : UnityEvent<bool> {}
	public class OnScreenKeyboard : MonoBehaviour
	{
		public KeyboardLayout keyboardLayout = KeyboardLayout.Azerty;

		public InputField inputField;
		public GameObject keyboardWrapper;

		[Space (15)]
		public GameObject keyPrefab;
		public GameObject shiftKeyPrefab;
		public GameObject spaceKeyPrefab;
		public GameObject backSpaceKeyPrefab;
		public GameObject enterKeyPrefab;
		public GameObject rowPrefab;

		EventSystem eventSystem;
		ShiftEvent shiftEvent = new ShiftEvent();

		private GameObject firstKey;
		private bool open = false;

		void Start() {
			eventSystem = EventSystem.current;
			StartCoroutine(SetupKeys());
		}

		private void  Update() {
			StartCoroutine(CheckFocus());
		}

		private IEnumerator CheckFocus() {
			var selected = eventSystem.currentSelectedGameObject;

			if(!open) {
				open = selected != null && selected.GetComponent<InputField>() == inputField;
				if(open) {
					keyboardWrapper.SetActive(open);
					eventSystem.SetSelectedGameObject(null);
 					yield return new WaitForEndOfFrame();
					eventSystem.SetSelectedGameObject(firstKey);
					yield return new WaitForEndOfFrame();
				}
			} else {
				if(selected == null || (selected != null && selected.GetComponent<Key>() == null)) {
					open = false;
					keyboardWrapper.SetActive(open);
				}
			}
		}

    	public void OnKeyPressed(string letter) {
			inputField.text = inputField.text + letter;
    	}

    	public void OnShift(bool shifted) {
			shiftEvent.Invoke(shifted);
    	}
    	public void OnDelete() { inputField.text = inputField.text.Remove(inputField.text.Length - 1); }

		public void OnSubmit() {
			open = false;
			keyboardWrapper.SetActive(open);
		}

		private IEnumerator SetupKeys() {
			IKeyboardLayout layout = KeyboardLayoutList.GetLayout(keyboardLayout);

			// Hide everything before setting up the keys
			keyboardWrapper.SetActive(false);
			var keyDict = new Dictionary<string, Key>();
			KeyboardRow[] rows = layout.Rows();
			for (int i = 0; i < rows.Length; i++) {
				KeyboardKey[] keys = rows[i].Keys;
				GameObject row = (GameObject) Instantiate(rowPrefab, keyboardWrapper.transform);
				
				for(int j = 0; j < keys.Length; j++) {
					(Key key, GameObject obj) = 
						(keys[j] is LetterKeyboardKey o1) ? SetupKey(o1, row) : 
						(keys[j] is ShiftKeyboardKey o2) ? SetupKey(o2, row) :
						(keys[j] is BackSpaceKeyboardKey o3) ? SetupKey(o3, row) :
						(keys[j] is SpaceKeyboardKey o4) ? SetupKey(o4, row) :
						(keys[j] is EnterKeyboardKey o5) ? SetupKey(o5, row) : (null, null);
					keyDict.Add(obj.name, key);
					obj.SetActive (true);
					if(i == 0 && j == 0)
						firstKey = obj;	
				}
				row.SetActive(true);
			}
			foreach( var kvp in layout.Navigation() ) {
    			var button = keyDict[kvp.Key];
				(string top, string bottom, string left, string right) = kvp.Value;
				if(top != null) button.Top = keyDict[top];
				if(bottom != null) button.Bottom = keyDict[bottom];
				if(left != null) button.Left = keyDict[left];
				if(right != null) button.Right = keyDict[right];
			}

			// Reset visibility of canvas and keyboard
			keyboardWrapper.SetActive(open);

			yield return null;
		}
		private (Key, GameObject) SetupKey(EnterKeyboardKey o, GameObject row) {
			GameObject obj = (GameObject) Instantiate(enterKeyPrefab, row.transform);
			EnterKey key = obj.GetComponent<EnterKey> ();
			obj.name = "Enter";
			return (key, obj);
		}

		private (Key, GameObject) SetupKey(SpaceKeyboardKey o, GameObject row) {
			GameObject obj = (GameObject) Instantiate(spaceKeyPrefab, row.transform);

			SpaceKey key = obj.GetComponent<SpaceKey> ();

			obj.name = "Space";

			return (key, obj);
		}

		private (Key, GameObject) SetupKey(ShiftKeyboardKey o, GameObject row) {
			GameObject obj = (GameObject) Instantiate(shiftKeyPrefab, row.transform);

			ShiftKey key = obj.GetComponent<ShiftKey> ();

			obj.name = "Shift";

			return (key, obj);
		}
		private (Key, GameObject) SetupKey(BackSpaceKeyboardKey o, GameObject row) {
			GameObject obj = (GameObject) Instantiate(backSpaceKeyPrefab, row.transform);

			Key key = obj.GetComponent<BackSpaceKey> ();
			obj.name = "BackSpace";

			return (key, obj);

		}
		private (Key, GameObject) SetupKey(LetterKeyboardKey o, GameObject row) {
			GameObject obj = (GameObject) Instantiate(keyPrefab, row.transform);

			LetterKey key = obj.GetComponent<LetterKey> ();
			key.key = o;
			key.shifted = false;
			obj.name = o.Character;
			shiftEvent.AddListener(key.Shift);

			return (key, obj);
		}
	}

	


}