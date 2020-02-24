using UnityEngine;
using UnityEngine.UI;

namespace OnScreenKeyboard {

	/// <summary>
	/// An individual key in the VR keyboard.
	/// </summary>
	public class Key :  Button {

		[Space (15)]
		public OnScreenKeyboard keyboard;

		public Text label;

		public virtual void HandleClick() { }

		public void OnClick() {
			HandleClick();
		}
		
		public Key Top { get; set; }
        public override Selectable FindSelectableOnUp() {
            return Top;
        }

		public Key Bottom { get; set; }
        public override Selectable FindSelectableOnDown() {
            return Bottom;
        }

		public Key Left { get; set; }
        public override Selectable FindSelectableOnLeft() {
            return Left;
        }

		public Key Right { get; set; }
        public override Selectable FindSelectableOnRight() {
            return Right;
        }

    }
}