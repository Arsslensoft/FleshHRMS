using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;

namespace DevExpress.XtraEditors.Controls {
    public class ButtonsPanel : IDisposable {
        public ButtonsPanel() {
            Buttons = new List<EditorButton>();
            Indent = 10;
            Appearance = new AppearanceObject();
            Appearance.BackColor = SystemColors.Control;
            Appearance.ForeColor = SystemColors.ControlText;
            LookAndFeel = new UserLookAndFeel(this);
            HAlignment = HorzAlignment.Far;
            VAlignment = VertAlignment.Center;
            Padding = Padding.Empty;
        }
        public virtual void Dispose() {
            SetContext(null);
        }
        public Padding Padding { get; set; }
        public HorzAlignment HAlignment { get; set; }
        public VertAlignment VAlignment { get; set; }
        public UserLookAndFeel LookAndFeel { get; set; }
        public AppearanceObject Appearance { get; set; }
        public int Indent { get; set; }
        public List<EditorButton> Buttons { get; set; }
        public ButtonsPanelInfo Init() {
            var viewInfo = new ButtonsPanelInfo();
            viewInfo.Painter = EditorButtonHelper.GetPainter(BorderStyles.Default, LookAndFeel);
            foreach(var button in Buttons) {
                var bi = new EditorButtonObjectInfoArgs(button, Appearance.Clone() as AppearanceObject, true);
                bi.BuiltIn = false;
                bi.FillBackground = true;
                viewInfo.ButtonsInfo.Add(bi);
            }
            return viewInfo;
        }
        public void SetContext(object context) {
            foreach(EditorButton button in Buttons) {
                button.Tag = context;
            }
        }
        public ButtonsPanelInfo Prepare(Graphics g, ButtonsPanelInfo viewInfo, Rectangle bounds) {
            if(viewInfo.Bounds == bounds && viewInfo.IsReady) {
                return viewInfo;
            }
            if(viewInfo.ButtonsInfo.Count == 0) {
                viewInfo.Bounds = Rectangle.Empty;
                viewInfo.IsReady = false;
                return viewInfo;
            }
            var maxSize = Size.Empty;
            viewInfo.Bounds = bounds;
            foreach(var button in viewInfo.ButtonsInfo) {
                var bi = PrepareButton(viewInfo, g, bounds, button);
                maxSize.Width = Math.Max(maxSize.Width, bi.Bounds.Width);
                maxSize.Height = Math.Max(maxSize.Height, bi.Bounds.Height);
            }

            var centerY = bounds.Y + Padding.Top;
            var totalWidth = 0;
            var lastX = bounds.X + Padding.Left;
            foreach(var button in viewInfo.ButtonsInfo) {
                var bb = button.Bounds;
                bb.Height = maxSize.Height;
                if(button.Button.Width < 1) {
                    bb.Width = maxSize.Width;
                }
                bb.Y = centerY;
                bb.X = lastX;
                button.Bounds = bb;
                viewInfo.Painter.CalcObjectBounds(button);
                lastX = bb.Right + Indent;
                totalWidth += bb.Width;
            }
            totalWidth += (viewInfo.ButtonsInfo.Count - 1) * Indent + Padding.Horizontal;
            viewInfo.Width = totalWidth;
            viewInfo.Height = maxSize.Height + Padding.Vertical;
            UpdateAlignment(viewInfo);
            viewInfo.IsReady = true;
            return viewInfo;
        }

        protected virtual void UpdateAlignment(ButtonsPanelInfo viewInfo) {
            if(viewInfo.ButtonsInfo.Count == 0 || viewInfo.Height < 1) {
                return;
            }
            var delta = Point.Empty;
            if(viewInfo.Width < viewInfo.Bounds.Width) {
                if(HAlignment == HorzAlignment.Center) {
                    delta.X = RectangleHelper.GetCenterBounds(viewInfo.Bounds, new Size(viewInfo.Width, 1)).X - viewInfo.Bounds.X;
                }
                if(HAlignment == HorzAlignment.Far) {
                    delta.X = viewInfo.Bounds.Width - viewInfo.Width;
                }
            }
            if(viewInfo.Height < viewInfo.Bounds.Height) {
                if(VAlignment == VertAlignment.Center) {
                    delta.Y = RectangleHelper.GetCenterBounds(viewInfo.Bounds, new Size(1, viewInfo.Height)).Y - viewInfo.Bounds.Y;
                }
                if(VAlignment == VertAlignment.Bottom) {
                    delta.Y = viewInfo.Bounds.Height - viewInfo.Height;
                }
            }
            if(!delta.IsEmpty) {
                foreach(var b in viewInfo.ButtonsInfo) {
                    b.OffsetContent(delta.X, delta.Y);
                }
            }
        }
        protected virtual EditorButtonObjectInfoArgs PrepareButton(ButtonsPanelInfo viewInfo, Graphics g, Rectangle bounds, EditorButtonObjectInfoArgs button) {
            g = GraphicsInfo.Default.AddGraphics(g);
            try {
                var min = ObjectPainter.CalcObjectMinBounds(g, viewInfo.Painter, button);
                button.Bounds = min;
            } finally {
                GraphicsInfo.Default.ReleaseGraphics();
            }
            return button;
        }
        public void Draw(GraphicsCache cache, ButtonsPanelInfo viewInfo) {
            viewInfo.Draw(cache);
        }
    }
    public class ButtonsPanelInfoEventsProvider : IDisposable {
        ButtonsPanelInfo info;
        Control control;
        public ButtonsPanelInfoEventsProvider(ButtonsPanelInfo info, Control control) {
            this.control = control;
            this.info = info;
        }
        public virtual void Dispose() {
            if(control != null) {
                UnhandleEvents();
                control = null;
            }
        }
        public ButtonsPanelInfo Info {
            get {
                return info;
            }
            set {
                if(Info == value) {
                    return;
                }
                if(Info != null) {
                    UnhandleEvents();
                }
                info = value;
                if(Info != null) {
                    HandleEvents();
                }
            }
        }

        public void UnhandleEvents() {
            control.MouseMove -= controlOnMouseMove;
            control.MouseDown -= controlOnMouseDown;
            control.MouseUp -= controlOnMouseUp;
            control.MouseLeave -= controlOnMouseLeave;
            control.MouseEnter -= controlOnMouseEnter;
        }
        public virtual void HandleEvents() {
            control.MouseMove += controlOnMouseMove;
            control.MouseDown += controlOnMouseDown;
            control.MouseUp += controlOnMouseUp;
            control.MouseLeave += controlOnMouseLeave;
            control.MouseEnter += controlOnMouseEnter;
        }

        void controlOnMouseLeave(object sender, EventArgs e) {
            var ee = DXMouseEventArgs.GetMouseArgs(control, e);
            if(Info.ProcessMouse(EventType.MouseLeave, ee)) {
                Invalidate();
            }
        }
        void controlOnMouseEnter(object sender, EventArgs e) {
            var ee = DXMouseEventArgs.GetMouseArgs(control, e);
            if(Info.ProcessMouse(EventType.MouseEnter, ee)) {
                Invalidate();
            }
        }
        public void Invalidate() {
            if(control == null) {
                return;
            }
            control.Invalidate(Info.Bounds);
        }

        void controlOnMouseUp(object sender, MouseEventArgs e) {
            if(Info.ProcessMouse(EventType.MouseUp, DXMouseEventArgs.GetMouseArgs(e))) {
                Invalidate();
            }
        }
        void controlOnMouseDown(object sender, MouseEventArgs e) {
            if(Info.ProcessMouse(EventType.MouseDown, DXMouseEventArgs.GetMouseArgs(e))) {
                Invalidate();
            }
        }

        void controlOnMouseMove(object sender, MouseEventArgs e) {
            if(Info.ProcessMouse(EventType.MouseMove, DXMouseEventArgs.GetMouseArgs(e))) {
                Invalidate();
            }
        }
    }
    public class ButtonsPanelInfo {
        Rectangle bounds;
        bool boundsChanged = false;
        public ButtonsPanelInfo() {
            ButtonsInfo = new List<EditorButtonObjectInfoArgs>();
            bounds = Rectangle.Empty;
        }
        public List<EditorButtonObjectInfoArgs> ButtonsInfo;
        public Rectangle Bounds {
            get {
                return bounds;
            }
            set {
                if(Bounds == value) {
                    return;
                }
                bounds = value;
                boundsChanged = true;
            }
        }
        public bool IsReady { get; set; }
        public bool BoundsChanged {
            get {
                return boundsChanged;
            }
            set {
                boundsChanged = value;
            }
        }
        public EditorButtonPainter Painter { get; set; }
        public virtual bool OnMouseMove(MouseEventArgs e) {
            return ProcessMouse(EventType.MouseMove, DXMouseEventArgs.GetMouseArgs(e));
        }
        public void Draw(GraphicsCache cache) {
            GraphicsClipState clip = null;
            if(Bounds.Width < Width) {
                clip = cache.ClipInfo.SaveAndSetClip(bounds);
            }
            foreach(var button in ButtonsInfo) {
                DrawButton(cache, button);
            }
            if(clip != null) {
                cache.ClipInfo.RestoreClipRelease(clip);
            }
        }
        void DrawButton(GraphicsCache cache, EditorButtonObjectInfoArgs button) {
            var state = ObjectState.Normal;
            if(!button.Button.Enabled) {
                state = ObjectState.Disabled;
            } else {
                if(HotButton == button.Button) {
                    state |= ObjectState.Hot;
                }
                if(PressedButton == button.Button) {
                    state |= ObjectState.Pressed;
                }
            }
            button.State = state;
            ObjectPainter.DrawObject(cache, Painter, button);
        }
        public virtual bool OnMouseDown(MouseEventArgs e) {
            var dx = DXMouseEventArgs.GetMouseArgs(e);
            return ProcessMouse(EventType.MouseDown, dx);
        }
        public virtual bool OnMouseEnter(MouseEventArgs e) {
            return ProcessMouse(EventType.MouseMove, DXMouseEventArgs.GetMouseArgs(e));
        }
        public virtual bool OnMouseLeave(MouseEventArgs e) {
            return ProcessMouse(EventType.MouseMove, DXMouseEventArgs.GetMouseArgs(e));
        }
        protected EditorButton PressedButton {
            get;
            set;
        }
        protected EditorButton HotButton {
            get;
            set;
        }
        protected EditorButtonObjectInfoArgs ByPoint(int x, int y) {
            return ByPoint(new Point(x, y));
        }
        protected EditorButtonObjectInfoArgs ByPoint(Point point) {
            return ButtonsInfo.FirstOrDefault(q => q.Bounds.Contains(point.X, point.Y) && q.Button.Enabled);
        }
        public bool ProcessMouse(EventType eventType, DXMouseEventArgs e) {
            if(!IsReady) {
                return false;
            }
            var byPointInfo = ByPoint(e.X, e.Y);
            var byPoint = byPointInfo == null ? null : byPointInfo.Button;
            if(eventType == EventType.MouseUp) {
                var invalidate = byPoint != null || HotButton != null || PressedButton != null;
                if(PressedButton != null) {
                    if(byPoint == PressedButton) {
                        OnClick(byPoint);
                    }
                }
                PressedButton = null;
                e.Handled = invalidate;
                return invalidate;
            }
            if(eventType == EventType.MouseDown) {
                var invalidate = byPoint != null || HotButton != null || PressedButton != null;
                HotButton = PressedButton = byPoint;
                e.Handled = invalidate;
                return invalidate;
            }
            if(HotButton != byPoint) {
                HotButton = byPoint;
                return true;
            }
            return false;
        }

        protected virtual void OnClick(EditorButton button) {
            button.RaiseClick();
        }

        bool PressButton(EditorButtonObjectInfoArgs button) {
            PressedButton = button.Button;
            return true;
        }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
