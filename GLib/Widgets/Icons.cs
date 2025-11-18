using System.Numerics;

using Dalamud.Interface;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Utility.Raii;

namespace GLib.Widgets;

public static class Icons {
	// TODO: Document
	public static void DrawIcon(FontAwesomeIcon icon, uint? color = null) {
		// Workaround: FontAwesomeIcon.None now renders as a caravan instead of being invisible.
		if (icon == FontAwesomeIcon.None) {
			ImGui.Text(string.Empty);
			return;
		}
		
		using var _ = ImRaii.PushColor(ImGuiCol.Text, color ?? 0xFFFFFFFF /* White */, color.HasValue);
		using var __ = ImRaii.PushFont(UiBuilder.IconFont);
		
		ImGui.Text(icon.ToIconString());
	}

	// TODO: Document
	public static Vector2 CalcIconSize(FontAwesomeIcon icon) {
		using var _ = ImRaii.PushFont(UiBuilder.IconFont);
		var result = ImGui.CalcTextSize(icon.ToIconString());

		return result * ImGuiHelpers.GlobalScale;
	}
}
