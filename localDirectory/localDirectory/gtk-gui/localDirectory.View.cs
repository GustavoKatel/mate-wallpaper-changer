
// This file has been generated by the GUI designer. Do not modify.
namespace localDirectory
{
	public partial class View
	{
		private global::Gtk.HBox hbox1;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView list;
		private global::Gtk.VBox vbox1;
		private global::Gtk.Button btAdd;
		private global::Gtk.Button btRemove;
		private global::Gtk.Button btClear;
		private global::Gtk.CheckButton cbRecursive;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget localDirectory.View
			global::Stetic.BinContainer.Attach (this);
			this.Name = "localDirectory.View";
			// Container child localDirectory.View.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.list = new global::Gtk.TreeView ();
			this.list.CanFocus = true;
			this.list.Name = "list";
			this.GtkScrolledWindow.Add (this.list);
			this.hbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.btAdd = new global::Gtk.Button ();
			this.btAdd.CanFocus = true;
			this.btAdd.Name = "btAdd";
			this.btAdd.UseStock = true;
			this.btAdd.UseUnderline = true;
			this.btAdd.Label = "gtk-add";
			this.vbox1.Add (this.btAdd);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.btAdd]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.btRemove = new global::Gtk.Button ();
			this.btRemove.CanFocus = true;
			this.btRemove.Name = "btRemove";
			this.btRemove.UseStock = true;
			this.btRemove.UseUnderline = true;
			this.btRemove.Label = "gtk-remove";
			this.vbox1.Add (this.btRemove);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.btRemove]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.btClear = new global::Gtk.Button ();
			this.btClear.CanFocus = true;
			this.btClear.Name = "btClear";
			this.btClear.UseStock = true;
			this.btClear.UseUnderline = true;
			this.btClear.Label = "gtk-clear";
			this.vbox1.Add (this.btClear);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.btClear]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.cbRecursive = new global::Gtk.CheckButton ();
			this.cbRecursive.CanFocus = true;
			this.cbRecursive.Name = "cbRecursive";
			this.cbRecursive.Label = global::Mono.Unix.Catalog.GetString ("Recursivo");
			this.cbRecursive.DrawIndicator = true;
			this.cbRecursive.UseUnderline = true;
			this.vbox1.Add (this.cbRecursive);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.cbRecursive]));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			this.hbox1.Add (this.vbox1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox1]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.btAdd.Clicked += new global::System.EventHandler (this.onAdd);
			this.btRemove.Clicked += new global::System.EventHandler (this.OnRemove);
			this.btClear.Clicked += new global::System.EventHandler (this.onClear);
			this.cbRecursive.Toggled += new global::System.EventHandler (this.onRecursiveToggled);
		}
	}
}
