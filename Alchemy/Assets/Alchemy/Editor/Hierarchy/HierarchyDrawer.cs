using UnityEditor;
using UnityEngine;

namespace Alchemy.Editor
{
    /// <summary>
    /// Base class for adding custom drawing processing to hierarchy items.
    /// </summary>
    public abstract class HierarchyDrawer
    {
        public abstract void OnGUI(EntityId entityId, Rect selectionRect);

        protected static Rect GetBackgroundRect(Rect selectionRect)
        {
            return selectionRect.AddXMax(20f);
        }

        protected static void DrawBackground(EntityId entityId, Rect selectionRect)
        {
            var backgroundRect = GetBackgroundRect(selectionRect);

            Color backgroundColor;
            var e = Event.current;
            var isHover = backgroundRect.Contains(e.mousePosition);

            if (Selection.Contains(entityId))
            {
                backgroundColor = EditorColors.HighlightBackground;
            }
            else if (isHover)
            {
                backgroundColor = EditorColors.HighlightBackgroundInactive;
            }
            else
            {
                backgroundColor = EditorColors.WindowBackground;
            }

            EditorGUI.DrawRect(backgroundRect, backgroundColor);
        }
    }
}
