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
		
		public bool IsTop { get; set; }
        public override Selectable FindSelectableOnUp() {
            return IsTop ? this : base.FindSelectableOnUp();
        }

		public bool IsBottom { get; set; }
        public override Selectable FindSelectableOnDown() {
            return IsBottom ? this : base.FindSelectableOnDown();
        }

		public bool IsLeft { get; set; }
        public override Selectable FindSelectableOnLeft() {
            return IsLeft ? this : base.FindSelectableOnLeft();
        }

		public bool IsRight { get; set; }
        public override Selectable FindSelectableOnRight() {
            return IsRight ? this : base.FindSelectableOnRight();
        }

    }
}