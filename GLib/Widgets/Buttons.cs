using System.Numerics;

using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Utility.Raii;

namespace GLib.Widgets;

public static class Buttons {
	public static float CalcSize() => (UiBuilder.DefaultFontSizePx + ImGui.GetStyle().CellPadding.X * 2) * ImGuiHelpers.GlobalScale;
	
	public static bool IconButton(FontAwesomeIcon icon, Vector2? size = null) {
		if (size == null) {
			var newSize = CalcSize();
			size = new Vector2(newSize, newSize);
		}

		using var _ = ImRaii.PushFont(UiBuilder.IconFont);
		return ImGui.Button(icon.ToIconString(), size.Value);
	}

	public static bool IconButtonTooltip(FontAwesomeIcon icon, string tooltip, Vector2? size = null) {
		var result = IconButton(icon, size);
		if (ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenDisabled)) {
			using var _ = ImRaii.Tooltip();
			ImGui.Text(tooltip);
		}
		return result;
	}
}
